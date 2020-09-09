// <copyright file="User.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>
namespace Euro.Core.Automation.Utilities.JsonManager
{
    /// <summary>
    /// User Entity used for Environment.json file.
    /// </summary>
    public class User
    {

        /// <summary>
        /// Gets or sets get/Set Type.
        /// Returns/sets the Type.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets get/Set Name.
        /// Returns/sets the Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets get/Set Password.
        /// Returns/sets the Password.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets get/Set Pin.
        /// Returns/sets the Pin.
        /// </summary>
        public string Pin { get; set; }

        /// <summary>
        /// Gets or sets get/Set Store Name.
        /// Returns/sets the Store Name.
        /// </summary>
        public string StoreName { get; set; }
    }
}
