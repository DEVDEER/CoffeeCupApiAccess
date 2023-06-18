namespace devdeer.CoffeeCupApiAccess.Logic.Models.Responses
{
    using System;
    using System.Linq;

    using System.Text.Json.Serialization;

    using TransportModels;

    /// <summary>
    /// Represents the response of the CoffeeCup API when the users endpoint is called.
    /// </summary>
    public class UsersResponseModel : BaseResponseModel
    {
        #region properties

        /// <summary>
        /// The list of user information.
        /// </summary>
        [JsonPropertyName("users")]
        public UserTransportModel[] Users { get; set; }

        #endregion
    }
}