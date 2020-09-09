// <copyright file="DataBase.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Utilities.JsonManager
{
    /// <summary>
    /// Class that contains the properties that need to connect to the data base
    /// </summary>
    public class DataBase
    {
        /// <summary>
        /// Gets or sets get/Set Name.
        /// Returns/sets the Name used for authenticating to the data base.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets get/Set Server.
        /// Returns/sets the Server used for authenticating to the data base.
        /// </summary>
        public string Server { get; set; }

        /// <summary>
        /// Gets or sets get/Set Host.
        /// Returns/sets the Host used for authenticating to the data base.
        /// </summary>
        public string Host { get; set; }

        /// <summary>
        /// Gets or sets get/Set User.
        /// Returns/sets the User used for authenticating to the data base.
        /// </summary>
        public string User { get; set; }

        /// <summary>
        /// Gets or sets get/Set Password.
        /// Returns/sets the Password used for authenticating to the data base.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets get/Set Port.
        /// Returns/sets the Port used for authenticating to the data base.
        /// </summary>
        public string Port { get; set; }

        /// <summary>
        /// Gets or sets get/Set ServiceName.
        /// Returns/sets the ServiceName used for authenticating to the data base.
        /// </summary>
        public string ServiceName { get; set; }

        /// <summary>
        /// Gets or sets Data base type.
        /// Returns Data base type.
        /// </summary>
        public string Type { get; set; }
    }
}
