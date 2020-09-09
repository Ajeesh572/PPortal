// <copyright file="EnumsHelper.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Utilities.Helpers.Enums
{
    using System;
    using System.Linq;
    using Euro.Core.Automation.Exceptions;

    /// <summary>
    /// Helper class for enums.
    /// </summary>
    public static class EnumsHelper
    {
        /// <summary>
        /// Provide an ability to get String description of Enum.
        /// </summary>
        /// <param name="value">Enum value.</param>
        /// <returns>String description of an Enum.</returns>
        /// <exception cref="Exception">Exception is thrown on error.</exception>
        public static string GetStringValue(this Enum value)
        {
            return GetStringOfEnum<StringValueAttribute>(value).Value;
        }

        /// <summary>
        /// Provide an ability to get Xpath parameter of Enum.
        /// </summary>
        /// <param name="value">Enum value.</param>
        /// <returns>Xpath parameter of an Enum.</returns>
        /// <exception cref="Exception">Exception is thrown on error.</exception>
        public static string GetXpathParameter(this Enum value)
        {
            return GetStringOfEnum<XpathParameterAttribute>(value).XpathParameter;
        }

        /// <summary>
        /// Provide an ability to get Locator Name of Enum
        /// </summary>
        /// <param name="value">Enum Value</param>
        /// <returns> Locator name of an Enum.</returns>
        public static string GetLocatorName(this Enum value)
        {
            return GetStringOfEnum<LocatorNameAttribute>(value).LocatorName;
        }

        /// <summary>
        /// Return T enum by a String description.
        /// </summary>
        /// <param name="description">String description.</param>
        /// <typeparam name="T">Enum type.</typeparam>
        /// <returns>Enum with a correct description.</returns>
        public static Enum GetEnumByStringValue<T>(this string description)
            where T : struct
        {
            try
            {
                return (T)typeof(T)
                    .GetFields()
                    .First(f => f.GetCustomAttributes(typeof(StringValueAttribute), false)
                        .Cast<StringValueAttribute>()
                        .Any(a => a.Value.Equals(description, StringComparison.OrdinalIgnoreCase)))
                    .GetValue(null) as Enum;
            }
            catch (InvalidOperationException)
            {
                return default(T) as Enum;
            }
        }

        /// <summary>
        /// Return Reflection class of Enum by a String description.
        /// </summary>
        /// <param name="description">String description.</param>
        /// <typeparam name="T">Enum type.</typeparam>
        /// <returns>Enum with a correct description.</returns>
        public static string GetReflectionClassByStringValue<T>(this string description)
            where T : struct
        {
            var foundEnum = description.GetEnumByStringValue<T>();
            return GetStringOfEnum<ReflectionClassAttribute>(foundEnum).Value;
        }

        /// <summary>
        /// Provide an ability to get Refclection Class description of Enum.
        /// </summary>
        /// <param name="value">Enum value.</param>
        /// <returns>Refclection Class description of an Enum.</returns>
        /// <exception cref="Exception">Exception is thrown on error.</exception>
        public static string GetReflectionClassValue(this Enum value)
        {
            return GetStringOfEnum<ReflectionClassAttribute>(value).Value;
        }

        /// <summary>
        /// Provide an ability to get First necessary attribute description of provided Enum.
        /// </summary>
        /// <param name="value">Enum value.</param>
        /// <typeparam name="T">Enum`s Attribute.</typeparam>
        /// <returns>Returns a first of default attribute of Enum.</returns>
        /// <exception cref="Exception">Exception is thrown on error.</exception>
        private static T GetStringOfEnum<T>(Enum value)
            where T : Attribute
        {
            if (value == null)
            {
                return null;
            }

            var type = value.GetType();

            var fi = type.GetField(value.ToString());
            var attrs = fi.GetCustomAttributes(typeof(T), false) as T[];

            if (attrs == null || attrs.Count() == 0)
            {
                throw new AttributeForEnumNotFoundException($"Attribute '{typeof(T)}' for enum '{value.GetType()}' with value '{value}' not found!");
            }

            return attrs.FirstOrDefault();
        }
    }
}
