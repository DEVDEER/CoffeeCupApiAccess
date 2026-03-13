namespace devdeer.CoffeeCupApiAccess.Logic.Models.Responses
{
    using System;
    using System.Linq;
    using System.Text.Json.Serialization;

    using DataModels;

    /// <summary>
    /// Represents the response of the CoffeeCup API when the expense-categories endpoint is called.
    /// </summary>
    public class ExpenseCategoryResponse : BaseResponse
    {
        #region properties

        /// <summary>
        /// The list of colors.
        /// </summary>
        [JsonPropertyName("expenseCategories")]
        public ExpenseCategory[] ExpenseCategories { get; set; } = default!;

        #endregion
    }
}