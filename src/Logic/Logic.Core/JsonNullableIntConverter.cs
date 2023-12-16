namespace devdeer.CoffeeCupApiAccess.Logic.Core
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text.Json;
    using System.Text.Json.Serialization;

    /// <summary>
    /// Custom JSON converter for <see cref="Nullable{Int32}" /> ignoring invalid JSON.
    /// </summary>
    /// s
    public class JsonNullableIntConverter : JsonConverter<int?>
    {
        #region methods

        /// <inheritdoc />
        public override int? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var ok = reader.TryGetInt32(out var tmp);
            return ok ? tmp : default(int?);
        }

        /// <inheritdoc />
        public override void Write(Utf8JsonWriter writer, int? value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value?.ToString(CultureInfo.InvariantCulture));
        }

        #endregion
    }
}