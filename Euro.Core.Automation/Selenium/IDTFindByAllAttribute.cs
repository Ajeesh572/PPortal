// <copyright file="IDTFindByAllAttribute.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Selenium
{
    using System;

    /// <summary>
    /// Marks elements to indicate that found elements should match the criteria of
    /// all <see cref="IDTFindByAttribute"/> on the field or property.
    /// </summary>
    /// <remarks>
    /// <para>
    /// When used with a set of <see cref="IDTFindByAttribute"/>, all criteria must be
    /// matched to be returned. The criteria are used in sequence according to the
    /// Priority property. Note that the behavior when setting multiple
    /// <see cref="IDTFindByAttribute"/> Priority properties to the same value, or not
    /// specifying a Priority value, is undefined.
    /// </para>
    /// <para>
    /// <code>
    /// // Will find the element with the tag name "input" that also has an ID
    /// // attribute matching "elementId".
    /// [FindsByAll]
    /// [FindsBy(How = How.TagName, Using = "input", Priority = 0)]
    /// [FindsBy(File = "FileName", Locator = "KeyValue"]
    /// [FindsBy(How = How.Id, Using = "elementId", Priority = 1)]
    /// public IWebElement thisElement;
    /// </code>
    /// </para>
    /// </remarks>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    internal class IDTFindByAllAttribute : Attribute
    {
    }
}
