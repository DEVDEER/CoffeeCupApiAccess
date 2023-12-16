namespace devdeer.CoffeeCupApiAccess.Logic.Models.DataModels.Analytics
{
    using System;
    using System.Linq;
    using System.Text.Json.Serialization;

    /// <summary>
    /// Contains information about amounts in analytics data.
    /// </summary>
    public class AnalyticsTask
    {
        #region properties

        [JsonPropertyName("amount")]
        public AnalyticsAmount Amount { get; set; } = default!;

        [JsonPropertyName("hours")]
        public AnalyticsHours Hours { get; set; } = default!;

        [JsonPropertyName("id")]
        public int Id { get; set; }

        #endregion
    }
}