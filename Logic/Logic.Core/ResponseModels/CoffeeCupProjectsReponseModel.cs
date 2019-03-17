namespace devdeer.CoffeeCupApiAccess.Logic.Core.ResponseModels
{
    using System;
    using System.Linq;

    using Newtonsoft.Json;

    using TransportModels;

    /// <summary>
    /// Represents the response of the CoffeeCup API when the projects endpoint is called.
    /// </summary>
    public class CoffeeCupProjectsResponseModel
    {
        #region properties

        /// <summary>
        /// The list of project information.
        /// </summary>
        [JsonProperty("projects")]
        public CoffeeCupProjectTransportModel[] Projects { get; set; }

        #endregion
    }
}