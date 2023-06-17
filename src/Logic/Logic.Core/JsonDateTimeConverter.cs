namespace devdeer.CoffeeCupApiAccess.Logic.Core
{
    using System;
    using System.Linq;
    using System.Text.Json;
    using System.Text.Json.Serialization;

    /// <summary>
    /// A custom converter for JSON date-time.
    /// </summary>
    public class JsonDateTimeConverter : JsonConverter<DateTime>
    {
        #region methods

        /// <inheritdoc />
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return DateTime.Parse(
                reader.GetString() ?? throw new InvalidOperationException("Null cann not be parsed."));
        }

        /// <inheritdoc />
        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(
                value.ToUniversalTime()
                    .ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ssZ"));
        }

        #endregion
    }
}