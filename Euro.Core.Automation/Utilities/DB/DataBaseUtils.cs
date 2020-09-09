// <copyright file="DataBaseUtils.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Utilities.DB
{
    using Euro.Core.Automation.Utilities.JsonManager;
    using Oracle.ManagedDataAccess.Client;

    /// <summary>
    /// Class that contains util methods related to data base eoperations.
    /// </summary>
    public class DataBaseUtils
    {
        /// <summary>
        /// Refreshes OneApp data base.
        /// </summary>
        public static void RefreshOneAppDataBase()
        {
            if (EnvironmentManager.GetEnvironmentName().Equals("QA"))
            {
                OracleCommand command = new OracleCommand("begin debit.refresh_rts_for_today('C'); end;", new OracleConnection(DBConnection.GetStringConnection("OneApp")));

                // TODO look for a better way to ensure that DB was updated sucessfully
                for (int i = 0; i < 3; i++)
                {
                    command.Connection.Open();
                    var test = command.ExecuteNonQuery();
                    command.Connection.Close();
                }
            }
        }
    }
}
