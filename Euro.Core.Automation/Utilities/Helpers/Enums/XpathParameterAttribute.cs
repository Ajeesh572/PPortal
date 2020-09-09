// <copyright file="XpathParameterAttribute.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Utilities.Helpers.Enums
{
    using System;

    /// <summary>
    /// Class of a XpathParameter attribute.
    /// </summary>
    public class XpathParameterAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="XpathParameterAttribute"/> class.
        /// Method to set a XpathParameter attribute.
        /// </summary>
        /// <param name="xpathParameter">Incomming xpath parameter value.</param>
        public XpathParameterAttribute(string xpathParameter)
        {
            XpathParameter = xpathParameter;
        }

        /// <summary>
        /// Xpath parameter.
        /// </summary>
        public string XpathParameter { get; }
    }
}
