// <copyright file="DBConnection.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>
namespace Euro.Core.Automation.Utilities.DB
{
    using System;
    using System.Data;
    using JsonManager;
    using MySql.Data.MySqlClient;
    using Oracle.ManagedDataAccess.Client;
    using Euro.Core.Automation.Utilities.Logger;

    /// <summary>
    /// Class to manage connection to database
    /// </summary>
    public class DBConnection
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DBConnection"/> class.
        /// </summary>
        public DBConnection()
        {
        }

        /// <summary>
        /// Gets values of db using an specific query.
        /// </summary>
        /// <param name="query">the query to get values of db</param>
        /// <param name="dbName">name of the database that looking in the configuration manager</param>
        /// <returns>the table with values related to query</returns>
        public static DataTable GetData(string dbName, string query)
        {
            var dataBase = EnvironmentManager.GetDBInfo(dbName);
            switch (dataBase.Type)
            {
                case "Oracle":
                    return GetOracleData(dbName, query);
                case "MySql":
                    return GetMySqlData(dbName, query);
                default:
                    throw new ArgumentException($"Invalid Data Base Type: {dataBase.Type}");
            }
        }

        /// <summary>
        /// Connects to Oracle DB
        /// </summary>
        /// <param name="dbName">name of the database that looking in the configuration manager</param>
        /// <param name="query">the query to get values of db</param>
        /// <returns>he table with values related to query</returns>
        public static DataTable GetOracleData(string dbName, string query)
        {
            DataTable table = new DataTable();
            using (var connection = GetConnection(GetStringConnection(dbName)))
            {
                var cmd = new OracleCommand(query, connection);
                new OracleDataAdapter(cmd).Fill(table);
            }

            return table;
        }

        /// <summary>
        /// Connects to MySQL DB
        /// </summary>
        /// <param name="dbName">name of the database that looking in the configuration manager</param>
        /// <param name="query">the query to get values of db</param>
        /// <returns>he table with values related to query</returns>
        public static DataTable GetMySqlData(string dbName, string query)
        {
            DataTable table = new DataTable();
            using (var connection = new MySqlConnection(GetStringConnection(dbName)))
            {
                var cmd = new MySqlCommand(query, connection);
                try
                {
                    new MySqlDataAdapter(cmd).Fill(table);
                }
                catch (MySqlException mysqle)
                {
                    string errorMessage = $"Exception is generated when trying to connect to DB: {mysqle.Message}";
                    Logging.Error(errorMessage);
                    throw new Exception(errorMessage);
                }
            }

            return table;
        }

        /// <summary>
        /// Gets the oracle db connection.
        /// </summary>
        /// <param name="stringConnection">the parameters to connect with db</param>
        /// <returns>the oracle connection</returns>
        public static OracleConnection GetConnection(string stringConnection)
        {
            OracleConnection connection = new OracleConnection(stringConnection);
            return connection;
        }

        /// <summary>
        /// Get the info to perform the connection to data base.
        /// </summary>
        /// <param name="dbName">name of the database that looking in the configuration manager</param>
        /// <returns>the data connection</returns>
        public static string GetStringConnection(string dbName)
        {
            DataBase dataBase = EnvironmentManager.GetDBInfo(dbName);
            switch (dataBase.Type)
            {
                case "Oracle":
                    return string.Format(
                        "user id={0};password={1};data source=" + "(DESCRIPTION=(ADDRESS=(PROTOCOL=tcp)" + "(HOST={2})(PORT={3}))(CONNECT_DATA=" + "(SERVICE_NAME={4})))",
                        dataBase.User,
                        dataBase.Password,
                        dataBase.Host,
                        dataBase.Port,
                        dataBase.ServiceName);
                case "MySql":
                    return $"Server={dataBase.Server};Database={dataBase.ServiceName};Uid={dataBase.User};Pwd={dataBase.Password};";
                default:
                    throw new ArgumentException($"Invalid Data Base Type: {dataBase.Type}");
            }

        }
    }
}
