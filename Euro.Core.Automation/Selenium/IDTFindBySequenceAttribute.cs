// <copyright file="IDTFindBySequenceAttribute.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Selenium
{
    using System;

    /// <summary>
    /// Marks elements to indicate that each <see cref="IDTFindByAttribute"/> on the field or
    /// property should be used in sequence to find the appropriate element.
    /// </summary>
    /// <remarks>
    /// <para>
    /// When used with a set of <see cref="IDTFindByAttribute"/>, the criteria are used
    /// in sequence according to the Priority property to find child elements. Note that
    /// the behavior when setting multiple <see cref="IDTFindByAttribute"/> Priority
    /// properties to the same value, or not specifying a Priority value, is undefined.
    /// </para>
    /// <para>
    /// <code>
    /// // Will find the element with the ID attribute matching "elementId", then will find
    /// // a child element with the ID attribute matching "childElementId".
    /// [FindsBySequence]
    /// [FindsBy(How = How.Id, Using = "elementId", Priority = 0)]
    /// [FindsBy(How = How.Id, Using = "childElementId", Priority = 1)]
    /// public IWebElement thisElement;
    /// </code>
    /// </para>
    /// </remarks>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    internal class IDTFindBySequenceAttribute : Attribute
    {
    }
}
