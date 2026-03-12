namespace devdeer.CoffeeCupApiAccess.Logic.Models.DataModels
{
    using System;
    using System.Linq;
    using System.Text.Json.Serialization;

    /// <summary>
    /// Contains the information about a single expense in CoffeeCup.
    /// </summary>
    public class Expense
    {
        #region properties

        /// <summary>
        /// The timestamp when the expense was updated last.
        /// </summary>
        [JsonPropertyName("createdAt")]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// The timestamp when the expense was updated last.
        /// </summary>
        [JsonPropertyName("updatedAt")]
        public DateTime UpdatedAt { get; set; }

        /// <summary>
        /// The unique identifier of the expense.
        /// </summary>
        [JsonPropertyName("id")]
        public int Id { get; set; }

        /// <summary>
        /// The description of the expense.
        /// </summary>
        [JsonPropertyName("description")]
        public string? Description { get; set; }

        /// <summary>
        /// The quantity of the expense.
        /// </summary>
        [JsonPropertyName("quantity")]
        public int? Quantity { get; set; }

        /// <summary>
        /// The internal price of the expense.
        /// </summary>
        [JsonPropertyName("priceInternal")]
        public double? PriceInternal { get; set; }

        /// <summary>
        /// The external price of the expense.
        /// </summary>
        [JsonPropertyName("priceExternal")]
        public double? PriceExternal { get; set; }

        /// <summary>
        /// Indicates whether the expense is billable.
        /// </summary>
        [JsonPropertyName("isBillable")]
        public bool IsBillable { get; set; }

        /// <summary>
        /// Indicates whether the expense is in budget.
        /// </summary>
        [JsonPropertyName("inBudget")]
        public bool InBudget { get; set; }

        /// <summary>
        /// Indicates whether the expense is recurring.
        /// </summary>
        [JsonPropertyName("isRecurring")]
        public bool IsRecurring { get; set; }

        /// <summary>
        /// The timestamp when the expense was billed.
        /// </summary>
        [JsonPropertyName("billedAt")]
        public DateTime BilledAt { get; set; }

        /// <summary>
        /// The day of the expense.
        /// </summary>
        [JsonPropertyName("day")]
        public DateOnly Day { get; set; }

        /// <summary>
        /// The percentage associated with the expense.
        /// </summary>
        [JsonPropertyName("percent")]
        public double? Percent { get; set; }

        /// <summary>
        /// The project ID of the expense.
        /// </summary>
        [JsonPropertyName("project")]
        public long ProjectId { get; set; }

        /// <summary>
        /// The expense category ID of the expense.
        /// </summary>
        [JsonPropertyName("expenseCategory")]
        public int ExpenseCategoryId { get; set; }

        /// <summary>
        /// The invoice ID of the expense.
        /// </summary>
        [JsonPropertyName("invoice")]
        public int? InvoiceId { get; set; }

        #endregion
    }
}