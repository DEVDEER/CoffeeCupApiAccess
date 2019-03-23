namespace devdeer.CoffeeCupApiAccess.Logic.Models.ResponseModels
{
    using System;
    using System.Linq;

    using Newtonsoft.Json;

    using TransportModels;

    /// <summary>
    /// Represents the response of the CoffeeCup API when the colors endpoint is called.
    /// </summary>
    public class ColorsResponseModel
    {
        #region properties

        /// <summary>
        /// The list of colors.
        /// </summary>
        [JsonProperty("colors")]
        public ColorTransportModel[] Colors { get; set; }

        #endregion
    }
}