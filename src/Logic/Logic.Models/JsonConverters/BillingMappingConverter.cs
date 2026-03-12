namespace devdeer.CoffeeCupApiAccess.Logic.Models.JsonConverters
{
    using System;
    using System.Linq;
    using System.Text.Json;
    using System.Text.Json.Serialization;

    using Enumerations;

    /// <summary>
    /// Custom JSON converter for the <see cref="BillingMapping" /> enum to handle the conversion.
    /// </summary>
    public class BillingMappingConverter : JsonConverter<BillingMapping>
    {
        #region methods

        public override BillingMapping Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options)
        {
            var value = reader.GetString();
            return value?.ToUpperInvariant() switch
            {
                "SERVICE" => BillingMapping.Service,
                "PRODUCT" => BillingMapping.Product,
                _ => BillingMapping.Undefined
            };
        }

        public override void Write(Utf8JsonWriter writer, BillingMapping value, JsonSerializerOptions options)
        {
            var stringValue = value switch
            {
                BillingMapping.Service => "SERVICE",
                BillingMapping.Product => "PRODUCT",
                _ => throw new InvalidOperationException($"Unexpected value when converting BillingMapping: {value}")
            };
            writer.WriteStringValue(stringValue);
        }

        #endregion
    }
}