namespace devdeer.CoffeeCupApiAccess.Logic.Models.DataModels
{
    using System;
    using System.Linq;
    using System.Text.Json.Serialization;

    using Enumerations;

    /// <summary>
    /// Contains the information about a single expense category in CoffeeCup.
    /// </summary>
    public class ExpenseCategory
    {
        #region properties

        /// <summary>
        /// The timestamp when the expense category was created.
        /// </summary>
        [JsonPropertyName("createdAt")]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// The timestamp when the expense category was updated last.
        /// </summary>
        [JsonPropertyName("updatedAt")]
        public DateTime UpdatedAt { get; set; }

        /// <summary>
        /// The unique identifier of the expense category.
        /// </summary>
        [JsonPropertyName("id")]
        public int Id { get; set; }

        /// <summary>
        /// The label of the expense category.
        /// </summary>
        [JsonPropertyName("label")]
        public string Label { get; set; } = default!;

        /// <summary>
        /// The type of the expense category.
        /// </summary>
        [JsonPropertyName("type")]
        public ExpenseCategoryType Type { get; set; }

        /// <summary>
        /// The unit of the expense category.
        /// </summary>
        [JsonPropertyName("unit")]
        public string? Unit { get; set; }

        /// <summary>
        /// The icon of the expense category.
        /// </summary>
        [JsonPropertyName("icon")]
        public int Icon { get; set; }

        /// <summary>
        /// The price per unit of the expense category.
        /// </summary>
        [JsonPropertyName("pricePerUnit")]
        public double? PricePerUnit { get; set; }

        /// <summary>
        /// The color of the expense category.
        /// </summary>
        [JsonPropertyName("color")]
        public int Color { get; set; }

        /// <summary>
        /// Indicates the expense category's status.
        /// </summary>
        [JsonPropertyName("status")]
        public bool Status { get; set; }

        /// <summary>
        /// The billing ID of the expense category.
        /// </summary>
        [JsonPropertyName("billingId")]
        public string? BillingId { get; set; }

        /// <summary>
        /// The billing mapping of the expense category.
        /// </summary>
        [JsonPropertyName("billingMapping")]
        public BillingMapping BillingMapping { get; set; }

        /// <summary>
        /// Indicates whether the value of the expense category can be edited.
        /// </summary>
        [JsonPropertyName("allowEditingValue")]
        public bool AllowEditingValue { get; set; }

        /// <summary>
        /// The percentage associated with the expense category.
        /// </summary>
        [JsonPropertyName("percent")]
        public double? Percent { get; set; }

        #endregion
    }
}