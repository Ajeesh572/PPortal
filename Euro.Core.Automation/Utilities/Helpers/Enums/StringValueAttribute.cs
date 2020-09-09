// <copyright file="StringValueAttribute.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Utilities.Helpers.Enums
{
    using System;

    /// <summary>
    /// Class of a StringValue attribute.
    /// </summary>
    public class StringValueAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StringValueAttribute"/> class.
        /// Method to set a StringValue attribute.
        /// </summary>
        /// <param name="value">Incomming string value.</param>
        public StringValueAttribute(string value)
        {
            Value = value;
        }

        /// <summary>
        /// String value.
        /// </summary>
        public string Value { get; }
    }
}
