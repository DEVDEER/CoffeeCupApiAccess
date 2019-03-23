namespace devdeer.CoffeeCupApiAccess.Logic.Models.TransportModels
{
    using System;
    using System.Linq;

    using Enumerations;

    using Newtonsoft.Json;

    /// <summary>
    /// Contains the information about a single task in CoffeeCup.
    /// </summary>
    public class TaskTransportModel
    {
        #region properties

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("color")]
        public int Color { get; set; }

        [JsonProperty("hourlyRate")]
        public double HourlyRate { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("billable")]
        public bool IsBillable { get; set; }

        [JsonProperty("favorite")]
        public bool IsFavorite { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("status")]
        public Status Status { get; set; }

        #endregion
    }
}