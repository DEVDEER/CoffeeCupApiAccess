namespace devdeer.CoffeeCupApiAccess.Logic.Models.DataModels.Analytics
{
    using System;
    using System.Linq;
    using System.Text.Json.Serialization;

    public class TimeEntryAnalytics
    {
        #region properties

        [JsonPropertyName("amount")]
        public AnalyticsAmount Amount { get; set; } = default!;

        [JsonPropertyName("endTimestamp")]
        public long EndTimestamp { get; set; }

        [JsonPropertyName("hours")]
        public AnalyticsHours Hours { get; set; } = default!;

        [JsonPropertyName("startTimestamp")]
        public long StartTimestamp { get; set; }

        #endregion
    }
}