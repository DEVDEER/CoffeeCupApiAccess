namespace devdeer.CoffeeCupApiAccess.Logic.Models.ResponseModels
{
    using System;
    using System.Linq;

    using Newtonsoft.Json;

    using TransportModels;

    /// <summary>
    /// Abstract base class for all responses.
    /// </summary>
    public abstract class BaseResponseModel
    {
        #region properties

        /// <summary>
        /// Contains the meta data which are appended to each response by CoffeeCup.
        /// </summary>
        [JsonProperty("meta")]
        public MetaDataTransportModel MetaData { get; set; }

        #endregion
    }
}