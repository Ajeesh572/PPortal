// <copyright file="ActionWithShadowElement.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Utilities.CommonAction
{
    using OpenQA.Selenium;

    /// <summary>
    /// Class that handles all common actions in the framework
    /// </summary>
    public static partial class CommonActions
    {
        /// <summary>
        /// Get shadow element.
        /// </summary>
        /// <param name="selector">Element selector which have shadowRoot</param>
        /// <returns>Return shadow element.</returns>
        public static IWebElement GetShadowElementBySelector(string selector)
        {
            return ExecuteScript<IWebElement>($"return document.querySelector('{selector}').shadowRoot");
        }

        /// <summary>
        /// Get shadow element.
        /// </summary>
        /// <param name="parentElement">Parent element</param>
        /// <param name="selector">Element selector which have shadowRoot</param>
        /// <returns>Return shadow element.</returns>
        public static IWebElement GetShadowElementBySelector(this IWebElement parentElement, string selector)
        {
            return ExecuteScript<IWebElement>($"return arguments[0].querySelector('{selector}').shadowRoot", parentElement);
        }

        /// <summary>
        /// Get element.
        /// </summary>
        /// <param name="parentElement">Parent element</param>
        /// <param name="selector">Element selector inside in parent element</param>
        /// <returns>Return element.</returns>
        public static IWebElement GetElementBySelector(this IWebElement parentElement, string selector)
        {
            return ExecuteScript<IWebElement>($"return arguments[0].querySelector('{selector}')", parentElement);
        }
    }
}
