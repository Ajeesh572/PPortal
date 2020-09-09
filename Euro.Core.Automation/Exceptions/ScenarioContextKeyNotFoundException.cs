// <copyright file="ScenarioContextKeyNotFoundException.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Exceptions
{
    using System;

    public class ScenarioContextKeyNotFoundException : Exception
    {
        public ScenarioContextKeyNotFoundException(string message)
            : base(message)
        {
        }
    }
}
