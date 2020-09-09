// <copyright file="CommonTrasformation.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Transformation
{
    using Euro.Core.Automation.Entities;
    using Euro.Core.Automation.Transformation.Models;
    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    /// <summary>
    /// This class used for common step argument transformation
    /// </summary>
    [Binding]
    public class CommonTrasformation
    {
        private readonly Transform transform;

        public CommonTrasformation()
        {
            transform = new Transform();
        }

        /// <summary>
        /// Transform string.
        /// <param name="text">Text for transform.</param>
        /// <returns>Transformed string object.</returns>
        /// </summary>
        [StepArgumentTransformation]
        public StringValue GetStringValue(string text)
        {
            return new StringValue(transform.TransformStringValue(text));
        }

        /// <summary>
        /// Transform string.
        /// <param name="table">Table for transform in entity.</param>
        /// <returns>Transformed entity.</returns>
        /// </summary>
        [StepArgumentTransformation]
        public LoginEntity GetLoginEntity(Table table)
        {
            return transform.TransformEntity(table.CreateInstance<LoginEntity>());
        }
    }
}
