// <copyright file="ListProject.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>
namespace Euro.Core.Automation.Utilities.JsonManager
{
    using System.Collections.Generic;

    /// <summary>
    /// Class that contains the properties and the list of projects
    /// </summary>
    public class ListProject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ListProject"/> class.
        /// </summary>
        public ListProject()
        {
            Projects = new List<Project>();
        }

        /// <summary>
        /// Gets or sets get/Set Projects.
        /// Returns/sets the Projects.
        /// </summary>
        public List<Project> Projects { get; set; }
    }
}
