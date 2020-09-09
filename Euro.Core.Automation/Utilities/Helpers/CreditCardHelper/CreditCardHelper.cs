// <copyright file="CreditCardHelper.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Utilities.Helpers.CreditCardHelper
{
    using System.Text;

    /// <summary>
    /// Class that helps working with credit card.
    /// </summary>
    public class CreditCardHelper
    {
        /// <summary>
        /// Masks credit card number with symbol * .
        /// </summary>
        /// <param name="creditCardNumber">Credit card number to mask</param>
        /// <param name="startIndexToMask">Start index to mask with *</param>
        /// <param name="quantityOfSymbolsToMask">Quantity of symbols to mask with *</param>
        /// <param name="maskPattern">What kind of mask is used</param>
        /// <returns>Masked credit card number as string</returns>
        public static string MaskCreditCard(string creditCardNumber, int startIndexToMask = 0, int quantityOfSymbolsToMask = 12, string maskPattern = "*")
        {
            var stringBuilder = new StringBuilder(creditCardNumber);
            var maskedCreditCard = stringBuilder.Remove(startIndexToMask, quantityOfSymbolsToMask)
                                                .Insert(startIndexToMask, maskPattern, quantityOfSymbolsToMask);

            return maskedCreditCard.ToString();
        }
    }
}
