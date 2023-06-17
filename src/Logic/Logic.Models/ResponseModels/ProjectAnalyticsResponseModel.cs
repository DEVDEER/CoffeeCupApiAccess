namespace devdeer.CoffeeCupApiAccess.Logic.Models.ResponseModels
{
    using System;
    using System.Linq;
    using System.Text.Json.Serialization;

    using TransportModels.Analytics;

    /// <summary>
    /// Represents the response of the CoffeeCup API when the analytics-project-endpoint is called.
    /// </summary>
    public class ProjectAnalyticsResponseModel : BaseResponseModel
    {
        #region properties

        /// <summary>
        /// The project data.
        /// </summary>
        [JsonPropertyName("analyticsProject")]
        public ProjectAnalyticsTransportModel Project { get; set; }

        #endregion
    }
}