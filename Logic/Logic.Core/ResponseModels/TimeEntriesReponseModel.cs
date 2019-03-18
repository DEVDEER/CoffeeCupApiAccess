namespace devdeer.CoffeeCupApiAccess.Logic.Core.ResponseModels
{
    using System;
    using System.Linq;

    using Newtonsoft.Json;

    using TransportModels;

    /// <summary>
    /// Represents the response of the CoffeeCup API when the time-entries-endpoint is called.
    /// </summary>
    public class CoffeeCupTimeEntriesResponseModel
    {
        #region properties

        /// <summary>
        /// The list of time-entry information.
        /// </summary>
        [JsonProperty("timeEntries")]
        public TimeEntryTransportModel[] TimeEntries { get; set; }

        #endregion
    }
}