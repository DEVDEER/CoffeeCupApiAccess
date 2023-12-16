namespace devdeer.CoffeeCupApiAccess.Logic.Models.DataModels.Analytics
{
    using System;
    using System.Linq;
    using System.Text.Json.Serialization;

    /// <summary>
    /// </summary>
    public class ProjectAnalytics
    {
        #region properties

        [JsonPropertyName("amount")]
        public AnalyticsAmount Amount { get; set; } = default!;

        [JsonPropertyName("hours")]
        public AnalyticsHours Hours { get; set; } = default!;

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("monthlyHistogram")]
        public AnalyticsHistogram[] MonthlyHistogram { get; set; } = default!;

        [JsonPropertyName("project")]
        public int ProjectId { get; set; }

        [JsonPropertyName("tasks")]
        public AnalyticsTask[] Tasks { get; set; } = default!;

        [JsonPropertyName("users")]
        public AnalyticsUser[] Users { get; set; } = default!;

        #endregion
    }
}