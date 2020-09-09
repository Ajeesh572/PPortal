// <copyright file="ReflectionClassAttribute.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Utilities.Helpers.Enums
{
    using System;

    /// <summary>
    /// Class of a ReflectionClass attribute.
    /// </summary>
    public class ReflectionClassAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReflectionClassAttribute"/> class.
        /// Method to set a ReflectionClass attribute.
        /// </summary>
        /// <param name="value">Incomming string value.</param>
        public ReflectionClassAttribute(string value)
        {
            Value = value;
        }

        /// <summary>
        /// String value.
        /// </summary>
        public string Value { get; }
    }
}
