// <copyright file="StringValue.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Transformation.Models
{
    /// <summary>
    /// This class used instead string for transform value
    /// because specflow does not support string transformation.
    /// </summary>
    public class StringValue
    {
        public string Value { get; set; }

        public StringValue(string value)
        {
            this.Value = value;
        }
    }
}
