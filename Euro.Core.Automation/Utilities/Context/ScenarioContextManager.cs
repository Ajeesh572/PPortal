// <copyright file="ScenarioContextManager.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Utilities.Context
{
    using Entities;
    using Euro.Core.Automation.Exceptions;
    using TechTalk.SpecFlow;

    /// <summary>
    /// Class to manage ScenarioContext.
    /// </summary>
    public class ScenarioContextManager
    {
        /// <summary>
        ///  Method helps to get ScenarioContext.Current['Entity'] stored object.
        /// </summary>
        /// <returns>Entity object.</returns>
        public static T GetScenarioContextEntity<T>()
            where T : BaseEntity
        {
            return GetScenarioContextEntity<T>(typeof(T).Name);
        }

        /// <summary>
        ///  Method helps to set ScenarioContext.Current['Entity'] stored object.
        /// </summary>
        /// <param name="entity">Entity you want to set.</param>
        public static void SetScenarioContextEntity<T>(T entity)
        {
            SetScenarioContextEntity(entity, typeof(T).Name);
        }

        /// <summary>
        ///  Method helps to get ScenarioContext.Current['Entity'] stored object.
        /// </summary>
        /// <param name="keyName">Key name for save in context.</param>
        /// <returns>Entity object.</returns>
        public static T GetScenarioContextEntity<T>(string keyName)
            where T : BaseEntity
        {
            CheckKeyExistOrNot(keyName);
            return (T)ScenarioContext.Current[keyName];
        }

        /// <summary>
        ///  Method helps to set ScenarioContext.Current['Entity'] stored object.
        /// </summary>
        /// <param name="entity">Entity you want to set.</param>
        /// <param name="keyName">Key name for save in context.</param>
        public static void SetScenarioContextEntity<T>(T entity, string keyName)
        {
            ScenarioContext.Current[keyName] = entity;
        }

        /// <summary>
        /// Get string value from ScenarioContext by key .
        /// </summary>
        /// <param name="key">Key for value</param>
        /// <returns>Value from ScenarioContext.</returns>
        public static string GetStringValue(string key)
        {
            return GetValue<string>(key);
        }

        /// <summary>
        /// Set string value for ScenarioContext by key .
        /// </summary>
        /// <param name="key">Key for save value.</param>
        /// <param name="value">Value for save.</param>
        public static void SetStringValue(string key, string value)
        {
            SetValue(key, value);
        }

        /// <summary>
        /// Set value for ScenarioContext by key .
        /// </summary>
        /// <param name="key">Key for save value.</param>
        /// <param name="value">Value for save.</param>
        public static void SetValue<T>(string key, T value)
        {
            ScenarioContext.Current[key] = value;
        }

        /// <summary>
        /// Get value from ScenarioContext.
        /// </summary>
        /// <param name="key">Key of value.</param>
        public static T GetValue<T>(string key)
        {
            CheckKeyExistOrNot(key);
            return (T)ScenarioContext.Current[key];
        }

        /// <summary>
        /// Remove value from ScenarioContext.
        /// </summary>
        /// <param name="key">Key of value.</param>
        public static void Remove(string key)
        {
            ScenarioContext.Current.Remove(key);
        }

        /// <summary>
        /// Check exist key or not in ScenarioContext.
        /// </summary>
        /// <param name="key">Key for value</param>
        /// <returns>Bool value true if exist.</returns>
        public static bool IsKeyExist(string key)
        {
            return ScenarioContext.Current.ContainsKey(key);
        }

        private static void CheckKeyExistOrNot(string key)
        {
            if (!ScenarioContext.Current.ContainsKey(key))
            {
                throw new ScenarioContextKeyNotFoundException($"The key with name '{key}' is not found in ScenarioContext");
            }
        }
    }
}
