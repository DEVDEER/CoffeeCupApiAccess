namespace devdeer.CoffeeCupApiAccess.Logic.Models.TransportModels
{
    using System;
    using System.Linq;

    using Enumerations;

    using System.Text.Json.Serialization;

    /// <summary>
    /// Contains the information about a single task in CoffeeCup.
    /// </summary>
    public class TaskTransportModel
    {
        #region properties

        [JsonPropertyName("code")]
        public string Code { get; set; }

        [JsonPropertyName("color")]
        public int Color { get; set; }

        [JsonPropertyName("hourlyRate")]
        public double HourlyRate { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("billable")]
        public bool IsBillable { get; set; }

        [JsonPropertyName("favorite")]
        public bool IsFavorite { get; set; }

        [JsonPropertyName("label")]
        public string Label { get; set; }

        [JsonPropertyName("status")]
        public Status Status { get; set; }

        #endregion
    }
}