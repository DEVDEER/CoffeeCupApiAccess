namespace devdeer.CoffeeCupApiAccess.Logic.Models.DataModels
{
    using System;
    using System.Linq;
    using System.Text.Json.Serialization;

    /// <summary>
    /// Contains the information which is added to each response.
    /// </summary>
    public class MetaData
    {
        #region properties

        /// <summary>
        /// The collection of request criteria.
        /// </summary>
        [JsonPropertyName("criteria")]
        public object Criteria { get; set; } = default!;

        /// <summary>
        /// The limit of rows that was set in the request.
        /// </summary>
        [JsonPropertyName("limit")]
        public int Limit { get; set; }

        /// <summary>
        /// The elements that where skipped (e.g. for paging).
        /// </summary>
        [JsonPropertyName("skip")]
        public int Skip { get; set; }

        /// <summary>
        /// The total amount of available entries.
        /// </summary>
        [JsonPropertyName("total")]
        public int Total { get; set; }

        #endregion
    }
}