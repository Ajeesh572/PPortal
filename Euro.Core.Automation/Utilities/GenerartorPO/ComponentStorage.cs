// <copyright file="ComponentStorage.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>
namespace Euro.Core.Automation.Utilities.GeneratePO
{
    using System.Collections.Generic;

    /// <summary>
    /// Class containing and operating the list of components and projects.
    /// </summary>
    public class ComponentStorage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ComponentStorage"/> class.
        /// </summary>
        public ComponentStorage()
        {
            this.Components = new List<Component>();
            this.Projects = new List<string>();
            this.AddDataToList();
            this.AddDataToProjectList();
        }

        /// <summary>
        /// Gets components.
        /// </summary>
        public List<Component> Components { get; }

        /// <summary>
        /// Gets projects.
        /// </summary>
        public List<string> Projects { get; }

        /// <summary>
        /// Add the required Components.
        /// </summary>
        private void AddDataToList()
        {
            this.Components.Add(new Component("Txt", "SendKeys", "Set"));
            this.Components.Add(new Component("Cbo", "SelectComboBox", "Click"));
            this.Components.Add(new Component("Btn", "ClickElement", "Click"));
            this.Components.Add(new Component("Lkn", "ClickElement", "Click"));
            this.Components.Add(new Component("Chk", "ClickElement", "Click"));
        }

        /// <summary>
        /// Add current projects.
        /// </summary>
        private void AddDataToProjectList()
        {
            this.Projects.Add("Euro.XGen");
            this.Projects.Add("Euro.Pinless");
            this.Projects.Add("Euro.MVNO");
            this.Projects.Add("Euro.MoneyTransfer");
        }
    }
}
