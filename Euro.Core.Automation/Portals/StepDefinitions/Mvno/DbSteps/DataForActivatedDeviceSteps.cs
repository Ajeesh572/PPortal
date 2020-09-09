// <copyright file="DataForActivatedDeviceSteps.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Portals.StepDefinitions.Mvno.DbSteps
{
    using Euro.Core.Automation.Assert;
    using Euro.Core.Automation.Entities;
    using Euro.Core.Automation.Utilities.Context;
    using Euro.Core.Automation.Utilities.DB.Queries.Mvno;
    using Euro.Core.Automation.Utilities.Helpers.DataBaseHelper.Mvno;
    using TechTalk.SpecFlow;

    [Binding]
    public class DataForActivatedDeviceSteps
    {
        [Then(@"""(.*)"" value for ""(.*)"" column in ""(.*)"" table is presented in DB for ""(.*)"" number")]
        public void ValueForColumnInTableIsPresentedInDbForNumber(string expectedValue, string columnName, string tableName, string typeOfFlow)
        {
            var phoneNumber = FeatureContextManager.GetFeatureContextEntity<AccountEntity>().PhoneNumber;
            var queryForGettingDataFromDb = string.Empty;
            if ("psf.mobile_transaction".Equals(tableName))
            {
                queryForGettingDataFromDb = MvnoActivationQueries.GetInfoFromPsfMobileTransaction;
            }
            else if ("ppr.customer_products".Equals(tableName))
            {
                queryForGettingDataFromDb = MvnoActivationQueries.GetInfoFromPprCustomerProducts;
            }
            else if ("debit.partitioned_pintab".Equals(tableName))
            {
                queryForGettingDataFromDb = MvnoActivationQueries.GetDataFromPintabTabelForActivatedNumber;
            }

            var actualValueInDb = MvnoDataBaseRequestHelper.GetDataFromDbViaPhoneNumber(queryForGettingDataFromDb, columnName, phoneNumber);

            SoftAssert.AreEquals(actualValueInDb, expectedValue, $"The actual value is '{actualValueInDb}' for column name '{columnName}' in table '{tableName}' but expected is '{expectedValue}'. \n The '{typeOfFlow}' phone number is '{phoneNumber}'");
        }
    }
}
