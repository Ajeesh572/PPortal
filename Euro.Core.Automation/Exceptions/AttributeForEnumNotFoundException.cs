// <copyright file="AttributeForEnumNotFoundException.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Exceptions
{
    using System;

    /// <summary>
    /// Attribute For Enum Not Found Exception Class.
    /// </summary>
    public class AttributeForEnumNotFoundException : Exception
    {
        public AttributeForEnumNotFoundException(string message)
            : base(message)
        {
        }
    }
}
