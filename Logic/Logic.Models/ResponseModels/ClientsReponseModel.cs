namespace devdeer.CoffeeCupApiAccess.Logic.Models.ResponseModels
{
    using System;
    using System.Linq;

    using Newtonsoft.Json;

    using TransportModels;

    /// <summary>
    /// Represents the response of the CoffeeCup API when the clients endpoint is called.
    /// </summary>
    public class CoffeeCupClientsResponseModel : BaseResponseModel
    {
        #region properties

        /// <summary>
        /// The list of client information.
        /// </summary>
        [JsonProperty("clients")]
        public ClientTransportModel[] Clients { get; set; }

        #endregion
    }
}