namespace devdeer.CoffeeCupApiAccess.Logic.Models.Responses
{
    using System;
    using System.Linq;
    using System.Text.Json.Serialization;

    using DataModels;

    /// <summary>
    /// Represents the response of the CoffeeCup API when the time-entries-endpoint is called.
    /// </summary>
    public class TimeEntriesResponseModel : BaseResponse
    {
        #region properties

        /// <summary>
        /// The list of time-entry information.
        /// </summary>
        [JsonPropertyName("timeEntries")]
        public TimeEntry[] TimeEntries { get; set; } = default!;

        #endregion
    }
}