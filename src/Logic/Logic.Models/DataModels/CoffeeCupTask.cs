namespace devdeer.CoffeeCupApiAccess.Logic.Models.DataModels
{
    using System;
    using System.Linq;
    using System.Text.Json.Serialization;

    using Enumerations;

    /// <summary>
    /// Contains the information about a single task in CoffeeCup.
    /// </summary>
    public class CoffeeCupTask
    {
        #region properties

        [JsonPropertyName("code")]
        public string Code { get; set; } = default!;

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
        public string Label { get; set; } = default!;

        [JsonPropertyName("status")]
        public Status Status { get; set; }

        #endregion
    }
}