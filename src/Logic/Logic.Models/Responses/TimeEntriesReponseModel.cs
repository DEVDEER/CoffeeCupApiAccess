namespace devdeer.CoffeeCupApiAccess.Logic.Models.Responses
{
    using System;
    using System.Linq;
    using System.Text.Json.Serialization;

    using TransportModels;

    /// <summary>
    /// Represents the response of the CoffeeCup API when the time-entries-endpoint is called.
    /// </summary>
    public class TimeEntriesResponseModel : BaseResponseModel
    {
        #region properties

        /// <summary>
        /// The list of time-entry information.
        /// </summary>
        [JsonPropertyName("timeEntries")]
        public TimeEntryTransportModel[] TimeEntries { get; set; }

        #endregion
    }
}