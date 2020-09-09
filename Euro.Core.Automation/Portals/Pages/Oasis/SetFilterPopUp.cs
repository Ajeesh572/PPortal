// <copyright file="SetFilterPopUp.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Portals.Pages.Oasis
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Euro.Core.Automation.Page.Base;
    using Euro.Core.Automation.Selenium;
    using Euro.Core.Automation.Utilities.CommonAction;
    using Euro.Core.Automation.WebDriver;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;

    /// <summary>
    /// Handles web elements in Set Filter pop up.
    /// </summary>
    public class SetFilterPopUp : BasePage
    {
        [IDTFindBy(How = How.CssSelector, Using = "input[name = 'tnum']")]
        private IWebElement TxtInvoiceCm;

        [IDTFindBy(How = How.CssSelector, Using = "[type = 'submit'][value = 'Set Filter']")]
        private IWebElement BtnSetFilter;

        private string ParentWindowHandle;

        public SetFilterPopUp()
        {
            ParentWindowHandle = WebDriverManager.Instance.GetCurrentWindow();
            WebDriverManager.Instance.GetWebDriver.SwitchTo().Window(WebDriverManager.Instance.GetWebDriver.WindowHandles.Last());
        }

        /// <summary>
        /// Fills Invoice CM text field.
        /// </summary>
        /// <param name="invoiceTNum">Is the invoice Tnum.</param>
        /// <returns>An instance of<see cref="SetFilterPopUp"/>.</returns>
        public SetFilterPopUp FillTxtInvoiceCm(string invoiceTNum)
        {
            CommonActions.SendKeys(TxtInvoiceCm, invoiceTNum);
            return this;
        }

        /// <summary>
        /// Fills fields in the form according received data.
        /// </summary>
        /// <param name="filters">The <see cref="Dictionary{TKey, TValue}"/> Contains data to fill the form.</param>
        public void FillFilterForm(Dictionary<string, string> filters)
        {
            new List<string>(filters.Keys).ForEach(key => GetStrategyStepMap(filters)[key].Invoke());
            CommonActions.ClickElement(BtnSetFilter);
            WebDriverManager.Instance.GetWebDriver.SwitchTo().Window(ParentWindowHandle);
        }

        /// <summary>
        /// Obtains the map with the functions to fill the <see cref="BillerForm"/>.
        /// </summary>
        /// <param name="dictionary"><see cref="Dictionary{SenderEnum, String}"/></param>
        /// <returns><see cref="Dictionary<BillerEnum, Func<SenderForm>>"/></returns>
        private Dictionary<string, Func<SetFilterPopUp>> GetStrategyStepMap(Dictionary<string, string> dictionary)
        {
            Dictionary<string, Func<SetFilterPopUp>> strategyMap = new Dictionary<string, Func<SetFilterPopUp>>();
            strategyMap.Add("InvoiceCM", () => FillTxtInvoiceCm(dictionary["InvoiceCM"]));
            return strategyMap;
        }
    }
}
