// <copyright file="RetailerLoginPage.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Portals.Pages.Common.LoginPages
{
    using System;

    /// <summary>
    /// This class handles the Login Exception.
    /// </summary>
    public class LoginExecption : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LoginExecption"/> class.
        /// </summary>
        /// <param name="message">The custom message that descibes the login exception.</param>
        public LoginExecption(string message) : base(message)
        {
            CustomMessage = message;
        }

        /// <summary>
        /// Gets the custom message that descibes the login exception.
        /// </summary>
        public string CustomMessage { get; }
    }
}
