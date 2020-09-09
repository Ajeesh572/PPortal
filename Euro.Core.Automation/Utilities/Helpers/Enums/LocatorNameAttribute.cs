// <copyright file="LocatorNameAttribute.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Utilities.Helpers.Enums
{
    using System;

    /// <summary>
    /// Class of a Locator name attribute.
    /// </summary>
    public class LocatorNameAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LocatorNameAttribute"/> class.
        /// Method to set a Locator name attribute.
        /// </summary>
        /// <param name="value">Incomming string value.</param>
        public LocatorNameAttribute(string value)
        {
            LocatorName = value;
        }

        /// <summary>
        /// Locator name.
        /// </summary>
        public string LocatorName { get; }
    }
}
