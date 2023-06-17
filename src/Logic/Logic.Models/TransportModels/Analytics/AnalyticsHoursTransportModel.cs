namespace devdeer.CoffeeCupApiAccess.Logic.Models.TransportModels.Analytics
{
    using System;
    using System.Linq;
    using System.Text.Json.Serialization;

    /// <summary>
    /// Contains information about hour-related data in analytics data.
    /// </summary>
    public class AnalyticsHoursTransportModel
    {
        #region properties

        [JsonPropertyName("billed")]
        public int Billed { get; set; }

        [JsonPropertyName("budget")]
        public object Budget { get; set; }

        [JsonPropertyName("nonBillable")]
        public float NonBillable { get; set; }

        [JsonPropertyName("outOfBudget")]
        public object OutOfBudget { get; set; }

        [JsonPropertyName("spent")]
        public float Spent { get; set; }

        [JsonPropertyName("total")]
        public float Total { get; set; }

        #endregion
    }
}