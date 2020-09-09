// <copyright file="Component.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>
namespace Euro.Core.Automation.Utilities.GeneratePO
{
    /// <summary>
    /// Class that defines the Component
    /// </summary>
    public class Component
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Component"/> class.
        /// </summary>
        public Component()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Component"/> class.
        /// </summary>
        /// <param name="abbreviation">the prefix</param>
        /// <param name="commonAction">common action of utilities</param>
        /// <param name="commonMethod">prefix of Action method</param>
        public Component(string abbreviation, string commonAction, string commonMethod)
        {
            this.Abbreviation = abbreviation;
            this.CommonAction = commonAction;
            this.CommonMethod = commonMethod;
        }

        /// <summary>
        /// Gets or sets Abbreviation.
        /// </summary>
        public string Abbreviation { get; set; }

        /// <summary>
        /// Gets or sets commonAction.
        /// </summary>
        public string CommonAction { get; set; }

        /// <summary>
        /// Gets or sets commonMethod
        /// </summary>
        public string CommonMethod { get; set; }
    }
}
