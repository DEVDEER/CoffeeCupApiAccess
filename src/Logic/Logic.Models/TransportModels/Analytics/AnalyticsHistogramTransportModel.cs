namespace devdeer.CoffeeCupApiAccess.Logic.Models.TransportModels.Analytics
{
    using System;
    using System.Linq;
    using System.Text.Json.Serialization;

    /// <summary>
    /// Contains information about certain values at a specfic time in analytics data.
    /// </summary>
    public class AnalyticsHistogramTransportModel
    {
        #region properties

        [JsonPropertyName("amount")]
        public AnalyticsAmountTransportModel Amount { get; set; }

        [JsonPropertyName("date")]
        public DateTime Date { get; set; }

        [JsonPropertyName("hours")]
        public AnalyticsHoursTransportModel Hours { get; set; }

        [JsonPropertyName("timestamp")]
        public long Timestamp { get; set; }

        #endregion
    }
}