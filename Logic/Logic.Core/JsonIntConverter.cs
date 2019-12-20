namespace devdeer.CoffeeCupApiAccess.Logic.Core
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text.Json;
    using System.Text.Json.Serialization;

    /// <summary>
    /// Custom JSON converter for <see cref="Int32"/> ignoring invalid JSON.
    /// </summary>
    public class JsonIntConverter : JsonConverter<int>
    {
        #region methods

        /// <inheritdoc />
        public override int Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var ok = reader.TryGetInt32(out var tmp);
            return ok ? tmp :0;
        }

        /// <inheritdoc />
        public override void Write(Utf8JsonWriter writer, int value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString(CultureInfo.InvariantCulture));
        }

        #endregion
    }

    
}