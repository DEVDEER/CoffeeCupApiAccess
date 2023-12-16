namespace devdeer.CoffeeCupApiAccess.Logic.Models.DataModels.Analytics
{
    using System;
    using System.Linq;
    using System.Text.Json.Serialization;

    /// <summary>
    /// Contains information about certain values at a specfic time in analytics data.
    /// </summary>
    public class AnalyticsHistogram
    {
        #region properties

        [JsonPropertyName("amount")]
        public AnalyticsAmount Amount { get; set; } = default!;

        [JsonPropertyName("date")]
        public DateTime Date { get; set; }

        [JsonPropertyName("hours")]
        public AnalyticsHours Hours { get; set; } = default!;

        [JsonPropertyName("timestamp")]
        public long Timestamp { get; set; }

        #endregion
    }
}