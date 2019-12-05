namespace devdeer.CoffeeCupApiAccess.Logic.Models.ResponseModels
{
    using System;
    using System.Linq;
    using System.Text.Json.Serialization;

    using TransportModels.Analytics;

    /// <summary>
    /// Represents the response of the CoffeeCup API when the analytics-time-entries-endpoint is called.
    /// </summary>
    public class AnalyticsTimeEntriesResponseModel : BaseResponseModel
    {
        #region properties

        /// <summary>
        /// The list of time-entry information.
        /// </summary>
        [JsonPropertyName("analyticsTimeEntries")]
        public TimeEntryAnalyticsTransportModel[] TimeEntries { get; set; }

        #endregion
    }
}