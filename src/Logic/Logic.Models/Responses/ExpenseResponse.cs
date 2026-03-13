namespace devdeer.CoffeeCupApiAccess.Logic.Models.Responses
{
    using System;
    using System.Linq;
    using System.Text.Json.Serialization;

    using DataModels;

    /// <summary>
    /// Represents the response of the CoffeeCup API when the expenses endpoint is called.
    /// </summary>
    public class ExpenseResponse : BaseResponse
    {
        #region properties

        /// <summary>
        /// The list of expenses.
        /// </summary>
        [JsonPropertyName("expenses")]
        public Expense[] Expenses { get; set; } = default!;

        #endregion
    }
}