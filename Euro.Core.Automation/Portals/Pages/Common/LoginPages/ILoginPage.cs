// <copyright file="ILoginPage.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Portals.Pages.Common.LoginPages
{
    /// <summary>
    /// This interface handles the methods to implement in the class of the type Login Page.
    /// </summary>
    public interface ILoginPage
    {
        /// <summary>
        /// Logs in according to the given user type.
        /// </summary>
        /// <param name="userType">Type of user required.</param>
        void LoginAsUserType(UserType userType, PortalWeb portal);

        /// <summary>
        /// Verifies if login in Portal Web.
        /// </summary>
        /// <returns>True if login in Portal Web</returns>
        bool IsLoginPage();
    }
}
