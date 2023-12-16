namespace devdeer.CoffeeCupApiAccess.Logic.Models.Responses
{
    using System;
    using System.Linq;
    using System.Text.Json.Serialization;

    using DataModels.Analytics;

    /// <summary>
    /// Represents the response of the CoffeeCup API when the analytics-time-entries-endpoint is called.
    /// </summary>
    public class AnalyticsTimeEntriesResponseModel : BaseResponse
    {
        #region properties

        /// <summary>
        /// The list of time-entry information.
        /// </summary>
        [JsonPropertyName("analyticsTimeEntries")]
        public TimeEntryAnalytics[] TimeEntries { get; set; } = default!;

        #endregion
    }
}