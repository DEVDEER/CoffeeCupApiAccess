namespace devdeer.CoffeeCupApiAccess.Logic.Models.TransportModels
{
    using System;
    using System.Linq;

    using Newtonsoft.Json;

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
        public int Status { get; set; }

        #endregion
    }
}