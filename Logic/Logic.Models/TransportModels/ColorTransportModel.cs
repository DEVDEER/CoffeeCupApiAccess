namespace devdeer.CoffeeCupApiAccess.Logic.Models.TransportModels
{
    using System;
    using System.Linq;

    using Enumerations;

    using Newtonsoft.Json;

    public class ColorTransportModel
    {
        #region properties

        [JsonProperty("hex")]
        public string HexValue { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("status")]
        public Status Status { get; set; }

        #endregion
    }
}