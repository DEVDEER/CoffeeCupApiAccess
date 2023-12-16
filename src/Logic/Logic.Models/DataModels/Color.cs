namespace devdeer.CoffeeCupApiAccess.Logic.Models.DataModels
{
    using System;
    using System.Linq;
    using System.Text.Json.Serialization;

    using Enumerations;

    /// <summary>
    /// Contains the information about a single color in CoffeeCup.
    /// </summary>
    public class Color
    {
        #region properties

        /// <summary>
        /// The hex value of the color.
        /// </summary>
        [JsonPropertyName("hex")]
        public string HexValue { get; set; } = default!;

        /// <summary>
        /// The id of the color entry.
        /// </summary>
        [JsonPropertyName("id")]
        public int Id { get; set; }

        /// <summary>
        /// A label describing the color.
        /// </summary>
        [JsonPropertyName("label")]
        public string Label { get; set; } = default!;

        /// <summary>
        /// The current status of the color.
        /// </summary>
        [JsonPropertyName("status")]
        public Status Status { get; set; }

        #endregion
    }
}