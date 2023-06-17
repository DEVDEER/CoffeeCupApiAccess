namespace devdeer.CoffeeCupApiAccess.Logic.Models.TransportModels.Analytics
{
    using System;
    using System.Linq;
    using System.Text.Json.Serialization;

    /// <summary>
    /// Contains information about amounts in analytics data.
    /// </summary>
    public class AnalyticsTaskTransportModel
    {
        #region properties

        [JsonPropertyName("amount")]
        public AnalyticsAmountTransportModel Amount { get; set; }

        [JsonPropertyName("hours")]
        public AnalyticsHoursTransportModel Hours { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        #endregion
    }
}