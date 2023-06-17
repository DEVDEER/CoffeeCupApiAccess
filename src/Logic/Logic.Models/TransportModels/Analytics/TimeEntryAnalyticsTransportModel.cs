namespace devdeer.CoffeeCupApiAccess.Logic.Models.TransportModels.Analytics
{
    using System;
    using System.Linq;
    using System.Text.Json.Serialization;

    public class TimeEntryAnalyticsTransportModel
    {
        #region properties

        [JsonPropertyName("amount")]
        public AnalyticsAmountTransportModel Amount { get; set; }

        [JsonPropertyName("endTimestamp")]
        public long EndTimestamp { get; set; }

        [JsonPropertyName("hours")]
        public AnalyticsHoursTransportModel Hours { get; set; }

        [JsonPropertyName("startTimestamp")]
        public long StartTimestamp { get; set; }

        #endregion
    }
}