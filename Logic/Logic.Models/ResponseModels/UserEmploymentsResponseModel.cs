namespace devdeer.CoffeeCupApiAccess.Logic.Models.ResponseModels
{
    using System;
    using System.Linq;

    using Newtonsoft.Json;

    using TransportModels;

    /// <summary>
    /// Represents the response of the CoffeeCup API when the user employments endpoint is called.
    /// </summary>
    public class UserEmploymentsResponseModel : BaseResponseModel
    {
        #region properties

        /// <summary>
        /// The list of user employments.
        /// </summary>
        [JsonProperty("userEmployments")]
        public UserEmploymentTransportModel[] UserEmployments { get; set; }

        #endregion
    }
}