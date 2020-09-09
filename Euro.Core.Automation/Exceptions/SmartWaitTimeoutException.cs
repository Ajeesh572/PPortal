// <copyright file="SmartWaitTimeoutException.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Exceptions
{
    using System;

    public class SmartWaitTimeoutException : Exception
    {
        public SmartWaitTimeoutException(string message = "Smart wait timeout error")
            : base(message)
        {
        }
    }
}
