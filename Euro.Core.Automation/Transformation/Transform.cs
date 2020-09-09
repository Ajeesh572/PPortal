// <copyright file="Transform.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Transformation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using Euro.Core.Automation.Entities;
    using Euro.Core.Automation.Utilities;

    /// <summary>
    /// This class used for processed common step argument transformation
    /// For example translate text or execute function
    /// </summary>
    public class Transform
    {
        private static readonly Regex FunctionRegex = new Regex(@"@(?<function>\w+)\((?<params>[^;]*)\)");
        private static readonly Regex ParameterRegex = new Regex(@"(\s?:?\s?'?'[^,]+\(.+?\)''?)|([^,]+)");

        private static readonly List<Type> ClassesWhereMethodsCanBeLocated = new List<Type>() { typeof(CommonFunctions) };

        /// <summary>
        /// Add class where located static functions for execute.
        /// Recommend use this method in CommonHooks (with attribute Before)
        /// </summary>
        /// <param name="classType">Static class where located functions for execute</param>
        public static void AddClassForTransformation(Type classType)
        {
            ClassesWhereMethodsCanBeLocated.Add(classType);
        }

        /// <summary>
        /// Transform Entity.
        /// </summary>
        /// <typeparam name="T">Type of entity</typeparam>
        /// <param name="entity">Entity for transform.</param>
        /// <returns>Transformed entity.</returns>
        public T TransformEntity<T>(T entity)
            where T : BaseEntity
        {
            entity.GetPropertyNames().ForEach(name => entity[name] = ((string)entity[name]) == null ? null : TransformStringValue((string)entity[name]));
            return entity;
        }

        /// <summary>
        /// Get text in english and translate this text in the language for execution.
        /// </summary>
        /// <param name="text">Text in english language.</param>
        /// <returns>Translated text in the language for execution.</returns>
        public string TranslateTextIfNeed(string text)
        {
            return LanguageManager.Instance.TranslateTextIfNeed(text);
        }

        /// <summary>
        /// If the string matches the function template(@FuncName(parameter1, parameter2, ...)), the function is executed
        /// and then the string is translated into the desired language if necessary.
        /// If the simple string returned input string.
        /// </summary>
        /// <param name="value">Value which can be transformed.</param>
        /// <returns>Transformated string(it is may be translated string, or function result,
        /// or input string(if string have not option for translate and do not match with function template))</returns>
        public string TransformStringValue(string value)
        {
            string transformValue = value;
            if (FunctionRegex.IsMatch(value))
            {
                transformValue = ExecuteFunction(value);
            }

            return TranslateTextIfNeed(transformValue);
        }

        private string ExecuteFunction(string functionExpression)
        {
            var methodName = FunctionRegex.Match(functionExpression).Groups["function"].Value;
            var parameters = ExecuteParameters(ParseParameters(FunctionRegex.Match(functionExpression).Groups["params"].Value));
            var classWhereMethodLocated = GetClassWhereMethodLocated(methodName);
            var method = classWhereMethodLocated.GetMethod(methodName);
            var parametersInfo = method.GetParameters();
            return (string)method.Invoke(classWhereMethodLocated, parameters);
        }

        private Type GetClassWhereMethodLocated(string methodName)
        {
            return ClassesWhereMethodsCanBeLocated.First(classType => classType.GetMethod(methodName) != null);
        }

        private string[] ParseParameters(string nonParsedParameters)
        {
            return ParameterRegex.Matches(nonParsedParameters).Cast<Match>()
                .Select(item => item.Value.Trim().TrimStart('\'').TrimEnd('\'')).ToArray<string>();
        }

        private string[] ExecuteParameters(string[] parameters)
        {
            for (var index = 0; index < parameters.Length; index++)
            {
                if (FunctionRegex.IsMatch(parameters[index]))
                {
                    parameters[index] = ExecuteFunction(parameters[index]);
                }
            }

            return parameters;
        }
    }
}
