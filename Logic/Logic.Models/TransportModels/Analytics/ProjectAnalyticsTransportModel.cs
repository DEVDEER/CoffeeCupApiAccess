namespace devdeer.CoffeeCupApiAccess.Logic.Models.TransportModels.Analytics
{
    using System;
    using System.Linq;
    using System.Text.Json.Serialization;

    /// <summary>
    /// </summary>
    public class ProjectAnalyticsTransportModel
    {
        #region properties

        [JsonPropertyName("amount")]
        public AnalyticsAmountTransportModel Amount { get; set; }

        [JsonPropertyName("hours")]
        public AnalyticsHoursTransportModel Hours { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("monthlyHistogram")]
        public AnalyticsHistogramTransportModel[] MonthlyHistogram { get; set; }

        [JsonPropertyName("project")]
        public int ProjectId { get; set; }

        [JsonPropertyName("tasks")]
        public AnalyticsTaskTransportModel[] Tasks { get; set; }

        [JsonPropertyName("users")]
        public AnalyticsUserTransportModel[] Users { get; set; }

        #endregion
    }
}