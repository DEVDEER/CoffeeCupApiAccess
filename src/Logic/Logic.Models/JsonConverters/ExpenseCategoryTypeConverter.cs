namespace devdeer.CoffeeCupApiAccess.Logic.Models.JsonConverters
{
    using System;
    using System.Linq;
    using System.Text.Json;
    using System.Text.Json.Serialization;

    using Enumerations;

    /// <summary>
    /// Custom JSON converter for the <see cref="ExpenseCategoryType" /> enum to handle the conversion.
    /// </summary>
    public class ExpenseCategoryTypeConverter : JsonConverter<ExpenseCategoryType>
    {
        #region methods

        public override ExpenseCategoryType Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options)
        {
            var value = reader.GetString();
            return value?.ToUpperInvariant() switch
            {
                "AMOUNT" => ExpenseCategoryType.Amount,
                "PERCENT" => ExpenseCategoryType.Percent,
                _ => ExpenseCategoryType.Undefined
            };
        }

        public override void Write(Utf8JsonWriter writer, ExpenseCategoryType value, JsonSerializerOptions options)
        {
            var stringValue = value switch
            {
                ExpenseCategoryType.Amount => "AMOUNT",
                ExpenseCategoryType.Percent => "PERCENT",
                _ => throw new InvalidOperationException(
                    $"Unexpected value when converting ExpenseCategoryType: {value}")
            };
            writer.WriteStringValue(stringValue);
        }

        #endregion
    }
}