// <copyright file="DialogMessageHelper.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Utilities.Helpers.DialogModalMessageHelper
{
    using Euro.Core.Automation.Utilities.CommonAction;
    using OpenQA.Selenium;

    /// <summary>
    /// This class contains the fields and the methods that will be used to handle the Dialog Modal Message.
    /// </summary>
    public class DialogMessageHelper
    {
        private static string modalInbox = $"div.modal-inbox[style='display: block;']";
        private static string closeModal = $"#message-details button.close";

        /// <summary>
        /// Closes the Message modal if it is opened.
        /// </summary>
        public static void CloseMessageDetailsModalOpened()
        {
            By btnCloseModal = By.CssSelector(closeModal);
            if (CommonActions.IsElementDisplayed(btnCloseModal))
            {
                CommonActions.ClickElementByLocator(btnCloseModal);

                // Wait until the modal box is not this blocked.
                CommonActions.WaitUntilElementIsInvisible(By.CssSelector(modalInbox));
            }
        }
    }
}
