// <copyright file="IAssertableComponent.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Assert
{
    /// <summary>
    /// Page interface which contains methods used for custom asserts.
    /// Should be implemented for project base page.
    /// </summary>
    public interface IAssertableComponent
    {
        /// <summary>
        /// Verifies that element is displayed on the page.
        /// </summary>
        /// <param name="elementName">Element name</param>>
        /// <returns>True if element is displayed, false otherwise</returns>
        bool IsElementDisplayed(string elementName);

        /// <summary>
        /// Gets text from webElement.
        /// </summary>
        /// <param name="elementName">Element name</param>
        /// <returns>Text from webElement</returns>
        string GetText(string elementName);

        /// <summary>
        /// Gets quantity of elements on UI.
        /// </summary>
        /// <param name="elementName">Element name</param>
        /// <returns>Text from webElement</returns>
        int GetQuantityOfElementsOnUi(string elementName);

        /// <summary>
        /// Gets attribute value of element of given name.
        /// </summary>
        /// <param name="element">The name of element</param>
        /// <param name="attributeName">Attribute name for which we are getting value</param>
        /// <returns>Value of element attribute as string</returns>
        string GetAttributeValue(string element, string attributeName);
    }
}
