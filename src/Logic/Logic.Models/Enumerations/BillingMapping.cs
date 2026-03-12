namespace devdeer.CoffeeCupApiAccess.Logic.Models.Enumerations
{
    using System;
    using System.Linq;
    using System.Text.Json.Serialization;

    using JsonConverters;

    /// <summary>
    /// Defines possible values for billing mappings.
    /// </summary>
    [JsonConverter(typeof(BillingMappingConverter))]
    public enum BillingMapping
    {
        /// <summary>
        /// Undefined billing mapping, signalazing parsing error.
        /// </summary>
        Undefined = 0,
        Service = 1,
        Product = 2
    }
}