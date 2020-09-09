// <copyright file="FeatureContextManager.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Utilities.Context
{
    using Euro.Core.Automation.Entities;
    using TechTalk.SpecFlow;

    /// <summary>
    /// Class to manage FeatureContext.
    /// </summary>
    public class FeatureContextManager
    {
        /// <summary>
        ///  Method helps to get FeatureContext.Current['Entity'] stored object.
        /// </summary>
        /// <returns>Entity object.</returns>
        public static T GetFeatureContextEntity<T>()
            where T : BaseEntity
        {
            return (T)FeatureContext.Current[typeof(T).Name];
        }

        /// <summary>
        ///  Method helps to set FeatureContext.Current['Entity'] stored object.
        /// </summary>
        /// <param name="entity">Entity you want to set.</param>
        public static void SetFeatureContextEntity<T>(T entity)
        {
            FeatureContext.Current[typeof(T).Name] = entity;
        }
    }
}
