namespace devdeer.CoffeeCupApiAccess.Logic.Models.Enumerations
{
    using System;
    using System.Linq;
    using System.Text.Json.Serialization;

    /// <summary>
    /// Defines possible values for expense categories.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ExpenseCategoryType
    {
        /// <summary>
        /// Undefined expense category type, signalazing parsing error.
        /// </summary>
        Undefined = 0,
        Amount = 1,
        Percent = 2
    }
}