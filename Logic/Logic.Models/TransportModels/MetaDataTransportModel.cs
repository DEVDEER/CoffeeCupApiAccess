namespace devdeer.CoffeeCupApiAccess.Logic.Models.TransportModels
{
    using System;
    using System.Linq;

    using Newtonsoft.Json;

    /// <summary>
    /// Contains the information which is added to each response.
    /// </summary>
    public class MetaDataTransportModel
    {
        #region properties

        /// <summary>
        /// The collection of request criteria.
        /// </summary>
        [JsonProperty("criteria")]
        public object Criteria { get; set; }

        /// <summary>
        /// The limit of rows that was set in the request.
        /// </summary>
        [JsonProperty("limit")]
        public int Limit { get; set; }

        /// <summary>
        /// The elements that where skipped (e.g. for paging).
        /// </summary>
        [JsonProperty("skip")]
        public int Skip { get; set; }

        /// <summary>
        /// The total amount of available entries.
        /// </summary>
        [JsonProperty("total")]
        public int Total { get; set; }

        #endregion
    }
}