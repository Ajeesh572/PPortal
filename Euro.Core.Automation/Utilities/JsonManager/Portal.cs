// <copyright file="Portal.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>
namespace Euro.Core.Automation.Utilities.JsonManager
{
    using System.Collections.Generic;

    /// <summary>
    /// Class that contains the properties of Portal
    /// </summary>
    public class Portal
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Portal"/> class.
        /// </summary>
        public Portal()
        {
            Users = new List<User>();
        }

        /// <summary>
        /// Gets or sets get/Set Name.
        /// Returns/sets the Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets get/Set Url.
        /// Returns/sets the Url.
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets get/Set BaseUrl.
        /// Returns/sets the BaseUrl.
        /// </summary>
        public string BaseUrl { get; set; }

        /// <summary>
        /// Gets or sets get/Set Users.
        /// Returns/sets the Users.
        /// </summary>
        public List<User> Users { get; set; }
    }
}
