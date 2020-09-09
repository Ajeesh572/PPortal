// <copyright file="EnvironmentManager.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Utilities.JsonManager
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using Euro.Core.Automation.Utilities.Logger;
    using Newtonsoft.Json;
    using NUnit.Framework;

    /// <summary>
    /// Static class containing the methods that operate with the configuration file
    /// </summary>
    public static class EnvironmentManager
    {
        /// <summary>
        /// Gets  the assembly directory path.
        /// </summary>
        public static string AssemblyDirectoryPath
        {
            get
            {
                var codeBase = Assembly.GetExecutingAssembly().CodeBase;
                var uri = new UriBuilder(codeBase);
                var path = Uri.UnescapeDataString(uri.Path);
                return Path.GetDirectoryName(path);
            }
        }

        /// <summary>
        /// Method that gets an entity with the information of the database.
        /// </summary>
        /// <param name="dbName">name of database</param>
        /// <returns>Entity DataBase</returns>
        public static DataBase GetDBInfo(string dbName)
        {
            try
            {
                ListProject listProject = GetListOfProjects();
                return listProject.Projects.Where(p => p.Name == GetEnvironmentName())
                    .Select(p => p.DBs.FirstOrDefault(up => up.Name == dbName)).FirstOrDefault();
            }
            catch (Exception)
            {
                Logging.Error($"Something went wrong on getting a DB.\n");
                return null;
            }
        }

        /// <summary>
        /// Method that gets an entity with the information of the CreditCard
        /// </summary>
        /// <param name="type">type of credit card</param>
        /// <returns>Entity CreditCard</returns>
        public static CreditCard GetCreditCardInfo(string type)
        {
            try
            {
                ListProject listProject = GetListOfProjects();
                return listProject.Projects.Where(p => p.Name == GetEnvironmentName())
                    .Select(p => p.CreditCard.FirstOrDefault(up => up.Type == type)).FirstOrDefault();
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Method that gets an entity with the portal information
        /// </summary>
        /// <param name="portal">name of portal</param>
        /// <returns>Entity Portal</returns>
        public static Portal GetPortal(string portal)
        {
            try
            {
                Logging.Debug("Get Environment portal variable");
                ListProject listProject = GetListOfProjects();
                var portalUrl = listProject.Projects.Where(p => p.Name == GetEnvironmentName())
                   .Select(p => p.Portals.FirstOrDefault(up => up.Name == portal)).FirstOrDefault();
                Logging.Debug($"Portal URL is '{portalUrl?.Name}'");
                return portalUrl;
            }
            catch (Exception exception)
            {
                Logging.Error($"Something went wrong on getting a Portal URL.\n{exception.Message}");
                return null;
            }
        }

        /// <summary>
        /// Gets a list of portals according to environment selected
        /// </summary>
        /// <returns>List of Portals</returns>
        public static List<Portal> GetPortals()
        {
            try
            {
                Logging.Debug("Get a Dictionary of Portals by Environment");

                List<Portal> listPortals = GetListOfPortals(GetEnvironmentName());
                Logging.Debug($"List of Portals are: '{listPortals}'");
                return listPortals;
            }
            catch (Exception exception)
            {
                Logging.Error($"Something went wrong on getting the list of portals Portal.\n{exception.Message}");
                return null;
            }
        }

        /// <summary>
        /// Method that gets an entity with user information
        /// </summary>
        /// <param name="portal">name of portal</param>
        /// <param name="type">type of user</param>
        /// <returns>Entity User</returns>
        public static User GetUser(string portal, string type)
        {
            try
            {
                return GetPortal(portal).Users.Where(p => p.Type == type).FirstOrDefault();
            }
            catch (Exception)
            {
                Logging.Error($"Something went wrong on getting a User.\n");
                return null;
            }
        }

        /// <summary>
        /// Gets a list of portals accordign to the Environment
        /// </summary>
        /// <param name="environment">Name of Enviroment</param>
        /// <returns>Entity List of Portals</returns>
        private static List<Portal> GetListOfPortals(string environment)
        {
            try
            {
                Logging.Debug("Get List of portals");
                string stringJson = System.IO.File.ReadAllText(GetPath());
                Logging.Debug("Deserialize JSON file for list of projects");
                ListProject listProject = JsonConvert.DeserializeObject<ListProject>(stringJson);
                var portals = listProject.Projects.Where(p => p.Name == environment).FirstOrDefault().Portals;
                return portals;
            }
            catch (Exception)
            {
                Logging.Error("Error on getting list of Portals. Returning null");
                return null;
            }
        }

        /// <summary>
        /// Gets the name of Environment
        /// </summary>
        /// <returns>string name</returns>
        public static string GetEnvironmentName() => GetEnvironmentVariable("environment");

        /// <summary>
        /// Gets the browser name.
        /// </summary>
        /// <returns>Browser name (i.e. Chrome, IE, FF, etc).</returns>
        public static string GetBrowser()
        {
            return GetEnvironmentVariable("browser");
        }

        /// <summary>
        /// Gets the Width of Browser.
        /// </summary>
        /// <returns>string of Width</returns>
        public static string GetWidthOfBrowser()
        {
            return GetEnvironmentVariable("width");
        }

        /// <summary>
        /// Gets the Height of Browser.
        /// </summary>
        /// <returns>string of Height</returns>
        public static string GetHeightOfBrowser()
        {
            return GetEnvironmentVariable("height");
        }

        /// <summary>
        /// Gets the force's value from environment file.
        /// </summary>
        /// <returns>The force's value</returns>
        public static string GetForceToExecution()
        {
            return GetEnvironmentVariable("force");
        }

        /// <summary>
        /// Gets the ID of TestRail run
        /// </summary>
        /// <returns>string id</returns>
        public static int GetTestRailRunId()
        {
            var runId = GetEnvironmentVariable("testrail_run_id");
            try
            {
                Logging.Debug("Parsing a TestRail Run ID");
                var intId = int.Parse(runId);
                Logging.Debug($"TestRail run ID is '{intId}'");
                return intId;
            }
            catch (Exception e)
            {
                Logging.Error($"Error on TestRail ID parsing. Incoming ID is '{runId}'. Error '{e.Message}'. Sending '-1' in order not to create a new Test Run");
                return -1;
            }
        }

        /// <summary>
        /// Gets the name of Database Environment.
        /// </summary>
        /// <returns>string database name</returns>
        public static string GetDatabaseName()
        {
            return GetEnvironmentVariable("DBs");
        }

        /// <summary>
        /// Method that gets the rout from where it's running
        /// </summary>
        /// <returns>string path</returns>
        public static string GetPath()
        {
            try
            {
                Logging.Debug("Get Path for running file..");
                string commonPath = "Environment.json";
                var fullPath = AssemblyDirectoryPath + "\\" + commonPath;
                Logging.Debug($"Path is '{fullPath}'");
                return fullPath;
            }
            catch (Exception exception)
            {
                Logging.Error($"Something went wrong on getting a path.\n{exception.Message}");
                return string.Empty;
            }
        }

        /// <summary>
        /// Method that gets an entity with the information of the API.
        /// </summary>
        /// <param name="nameAPi">name of API</param>
        /// <returns>Entity API</returns>
        public static Api GetApiInfo(string nameAPi)
        {
            try
            {
                ListProject listProject = GetListOfProjects();
                return listProject.Projects.Where(p => p.Name == GetEnvironmentName())
                    .Select(p => p.APIs.FirstOrDefault(api => api.Name == nameAPi)).FirstOrDefault();
            }
            catch (Exception exception)
            {
                Logging.Error($"Something went wrong on getting a API.\n{exception.Message}");
                return null;
            }
        }

        /// <summary>
        /// Gets the variable of Environment.
        /// </summary>
        /// <param name="environmentVariable">The variable to find.</param>
        /// <returns>string variable</returns>
        private static string GetEnvironmentVariable(string environmentVariable)
        {
            try
            {
                string variable = TestContext.Parameters.Get(environmentVariable);
                if (variable != null)
                {
                    return variable;
                }

                return ConfigurationManager.AppSettings[environmentVariable];
            }
            catch (Exception)
            {
                Logging.Error("Something went wrong on getting a Environment Variable.\n");
                return string.Empty;
            }
        }

        /// <summary>
        /// Method that gets an entity with the list of projects
        /// </summary>
        /// <returns>Entity ListProjects</returns>
        private static ListProject GetListOfProjects()
        {
            try
            {
                Logging.Debug("Get List of projects");
                string stringJson = System.IO.File.ReadAllText(GetPath());
                Logging.Debug("Deserialize JSON file for list of projects");
                ListProject listProject = JsonConvert.DeserializeObject<ListProject>(stringJson);
                return listProject;
            }
            catch (Exception)
            {
                Logging.Error("Error on getting list of Projects. Returning null");
                return null;
            }
        }
    }
}
