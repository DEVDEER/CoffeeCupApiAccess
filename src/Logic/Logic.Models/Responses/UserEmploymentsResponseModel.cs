namespace devdeer.CoffeeCupApiAccess.Logic.Models.Responses
{
    using System;
    using System.Linq;

    using System.Text.Json.Serialization;

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
        [JsonPropertyName("userEmployments")]
        public UserEmploymentTransportModel[] UserEmployments { get; set; }

        #endregion
    }
}