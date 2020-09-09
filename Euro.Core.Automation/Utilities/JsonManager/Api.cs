// <copyright file="Api.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Utilities.JsonManager
{
    /// <summary>
    /// Class that contains the properties that need to connect to the APIs.
    /// </summary>
    public class Api
    {
        /// <summary>
        /// Gets or sets name of the API.
        /// Returns/sets the Name used for the API.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the URL of the API.
        /// Returns/sets the URL of the API used.
        /// </summary>
        public string Url { get; set; }
    }
}
