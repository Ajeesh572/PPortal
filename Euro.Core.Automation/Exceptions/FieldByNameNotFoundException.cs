// <copyright file="FieldByNameNotFoundException.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Exceptions
{
    using System;

    /// <summary>
    /// Field By Name Not Found Exception Class.
    /// </summary>
    public class FieldByNameNotFoundException : Exception
    {
        public FieldByNameNotFoundException(string message)
            : base(message)
        {
        }
    }
}
