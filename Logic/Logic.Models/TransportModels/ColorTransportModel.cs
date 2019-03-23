namespace devdeer.CoffeeCupApiAccess.Logic.Models.TransportModels
{
    using System;
    using System.Linq;

    using Enumerations;

    using Newtonsoft.Json;

    /// <summary>
    /// Contains the information about a single color in CoffeeCup.
    /// </summary>
    public class ColorTransportModel
    {
        #region properties

        /// <summary>
        /// The hex value of the color.
        /// </summary>
        [JsonProperty("hex")]
        public string HexValue { get; set; }

        /// <summary>
        /// The id of the color entry.
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// A label describing the color.
        /// </summary>
        [JsonProperty("label")]
        public string Label { get; set; }

        /// <summary>
        /// The current status of the color.
        /// </summary>
        [JsonProperty("status")]
        public Status Status { get; set; }

        #endregion
    }
}