// <copyright file="Project.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>
namespace Euro.Core.Automation.Utilities.JsonManager
{
    using System.Collections.Generic;

    /// <summary>
    /// Class that contains the properties of Project.
    /// </summary>
    public class Project
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Project"/> class.
        /// </summary>
        public Project()
        {
            Portals = new List<Portal>();
            DBs = new List<DataBase>();
            APIs = new List<Api>();
            CreditCard = new List<CreditCard>();
        }

        /// <summary>
        /// Gets or sets get/Set Name.
        /// Returns/sets the Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets get/Set Portals.
        /// Returns/sets the Portals.
        /// </summary>
        public List<Portal> Portals { get; set; }

        /// <summary>
        /// Gets or sets get/Set DBs.
        /// Returns/sets the DBs.
        /// </summary>
        public List<DataBase> DBs { get; set; }

        /// <summary>
        /// Gets or sets API Clients.
        /// Returns/sets the API Clients.
        /// </summary>
        public List<Api> APIs { get; set; }

        /// <summary>
        /// Gets or sets get/Set CreditCard.
        /// Returns/sets the CreditCard.
        /// </summary>
        public List<CreditCard> CreditCard { get; set; }
    }
}
