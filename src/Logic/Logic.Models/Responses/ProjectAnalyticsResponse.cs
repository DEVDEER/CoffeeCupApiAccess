namespace devdeer.CoffeeCupApiAccess.Logic.Models.Responses
{
    using System;
    using System.Linq;
    using System.Text.Json.Serialization;

    using DataModels.Analytics;

    /// <summary>
    /// Represents the response of the CoffeeCup API when the analytics-project-endpoint is called.
    /// </summary>
    public class ProjectAnalyticsResponse : BaseResponse
    {
        #region properties

        /// <summary>
        /// The project data.
        /// </summary>
        [JsonPropertyName("analyticsProject")]
        public ProjectAnalytics Project { get; set; } = default!;

        #endregion
    }
}