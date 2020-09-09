// <copyright file="ReflectionHelper.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Utilities.Helpers.Reflection
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Euro.Core.Automation.Exceptions;
    using Euro.Core.Automation.Selenium;

    /// <summary>
    /// Reflection Helper Class.
    /// </summary>
    public static class ReflectionHelper
    {
        private static readonly Assembly[] Assemblies;

        static ReflectionHelper()
        {
            Assemblies = AppDomain.CurrentDomain.GetAssemblies();
        }

        /// <summary>
        /// Provide an ability to get an instance of a class by reflection.
        /// </summary>
        /// <param name="className">String class name.</param>
        /// <returns>Instance of a class.</returns>
        public static object GetClassInstanceByItsName(string className)
        {
            var type = Assemblies
                .SelectMany(x => x.GetTypes())
                .FirstOrDefault(x => x.Name == className);

            if (type != null)
            {
                var instance = Activator.CreateInstance(type);
                return instance;
            }

            throw new Exception($"{className} cannot be activated cause its type has not been found");
        }

        /// <summary>
        /// Get field or property of class instance by value of attribute IDTFieldNameAttribute.
        /// </summary>
        /// <param name="obj">Instance of class.</param>
        /// <param name="fieldName">Field name.</param>
        /// <returns>Field of class</returns>
        public static T GetFieldByFieldName<T>(object obj, string fieldName)
        {
            var bindingFlags = BindingFlags.NonPublic | BindingFlags.Instance;
            var propertiesAndFields = new List<MemberInfo>(obj.GetType().GetProperties());
            propertiesAndFields.AddRange(obj.GetType().GetFields(bindingFlags));
            var findedElement = propertiesAndFields
                    .FirstOrDefault(field => field.GetCustomAttributes(typeof(IDTFieldNameAttribute), false)
                        .Cast<IDTFieldNameAttribute>()
                        .Any(fieldNameAttribute => fieldNameAttribute.FieldName.Equals(fieldName, StringComparison.OrdinalIgnoreCase)));
            if (findedElement == null)
            {
                throw new FieldByNameNotFoundException($"Field by field name '{fieldName}' is not found in class '{obj.GetType().Name}'");
            }

            return (T)(findedElement is PropertyInfo ? (findedElement as PropertyInfo).GetValue(obj) : (findedElement as FieldInfo).GetValue(obj));
        }

        /// <summary>
        /// Get field or property of class instance by value of attribute IDTFieldNameAttribute.
        /// </summary>
        /// <param name="obj">Instance of class.</param>
        /// <param name="fieldName">Field name.</param>
        /// <param name="typeConstraint">When searching base classes for 'obj', this is the highest base class to traverse up to</param>
        /// <returns>Field of class</returns>
        public static T GetFieldByFieldName<T>(object obj, string fieldName, Type typeConstraint)
        {
            var bindingFlags = BindingFlags.NonPublic | BindingFlags.Instance;
            var propertiesAndFields = new List<MemberInfo>();
            var type = obj.GetType();
            MemberInfo findedElement = null;

            do
            {
                propertiesAndFields.AddRange(type.GetProperties());
                propertiesAndFields.AddRange(type.GetFields(bindingFlags));

                findedElement = propertiesAndFields
                                .FirstOrDefault(field => field.GetCustomAttributes(typeof(IDTFieldNameAttribute), false)
                                .Cast<IDTFieldNameAttribute>()
                                .Any(fieldNameAttribute => fieldNameAttribute.FieldName.Equals(fieldName, StringComparison.OrdinalIgnoreCase)));

                if (findedElement == null)
                {
                    type = type.BaseType;
                }

            } while (!type.Equals(typeConstraint) && findedElement == null);

            if (findedElement == null)
            {
                throw new FieldByNameNotFoundException($"Field by field name '{fieldName}' is not found in class '{obj.GetType().Name}'");
            }

            return (T)(findedElement is PropertyInfo ? (findedElement as PropertyInfo).GetValue(obj) : (findedElement as FieldInfo).GetValue(obj));
        }
    }
}
