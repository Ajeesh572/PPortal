// <copyright file="IDTBy.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Selenium
{
    using System;
    using System.Globalization;
    using System.Reflection;
    using Euro.Core.Automation.Utilities;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;

    internal class IDTBy
    {
        /// <summary>
        /// Gets an instance of the <see cref="By"/> class based on the specified attribute.
        /// </summary>
        /// <param name="attribute">The <see cref="IDTFindByAttribute"/> describing how to find the element.</param>
        /// <returns>An instance of the <see cref="By"/> class.</returns>
        internal static By From(IDTFindByAttribute attribute)
        {
            var how = attribute.How;
            var usingValue = attribute.Using;
            var file = attribute.File;
            var locator = attribute.Locator;

            if (file != null && locator != null)
            {
                return Utils.GetByLocator(file, locator);
            }
            else
            {
                switch (how)
                {
                    case How.Id:
                        return By.Id(usingValue);
                    case How.Name:
                        return By.Name(usingValue);
                    case How.TagName:
                        return By.TagName(usingValue);
                    case How.ClassName:
                        return By.ClassName(usingValue);
                    case How.CssSelector:
                        return By.CssSelector(usingValue);
                    case How.LinkText:
                        return By.LinkText(usingValue);
                    case How.PartialLinkText:
                        return By.PartialLinkText(usingValue);
                    case How.XPath:
                        return By.XPath(usingValue);
                    case How.Custom:
                        if (attribute.CustomFinderType == null)
                        {
                            throw new ArgumentException("Cannot use How.Custom without supplying a custom finder type");
                        }

                        if (!attribute.CustomFinderType.IsSubclassOf(typeof(By)))
                        {
                            throw new ArgumentException("Custom finder type must be a descendent of the By class");
                        }

                        ConstructorInfo ctor = attribute.CustomFinderType.GetConstructor(new Type[] { typeof(string) });
                        if (ctor == null)
                        {
                            throw new ArgumentException("Custom finder type must expose a public constructor with a string argument");
                        }

                        By finder = ctor.Invoke(new object[] { usingValue }) as By;
                        return finder;
                }
            }

            throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "Did not know how to construct How from how {0}, using {1}", how, usingValue));
        }
    }
}
