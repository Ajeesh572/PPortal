// <copyright file="MvnoActivationQueries.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Utilities.DB.Queries.Mvno
{
    /// <summary>
    /// Class to store DB queries
    /// </summary>
    public static class MvnoActivationQueries
    {
        public const string GetDataFromPintabTabelForActivatedNumber = "select * from debit.partitioned_pintab@debitdb01 where pin='{0}'";
        public const string GetInfoFromPsfMobileTransaction = "select * from psf.mobile_transaction where mobile_number in ('{0}')";
        public const string GetInfoFromPprCustomerProducts = "select * from ppr.customer_products where source_id in (select to_char(ctlnum) from debit.PARTITIONED_PINTAB@debitdb01 where PIN in ('{0}'))";
        public const string GetPhoneNumber = "select * from psf.MOBILE_TRANSACTION t where MOBILE_NUMBER='{0}'";
        public const string GetInfoFromFromTable = "select * from ppr.customers where {0}";
        public const string GetSecurityCodeForNumber = "select security_code from debit.partitioned_pintab@debitdb01 where pin='{0}'";
    }
}
