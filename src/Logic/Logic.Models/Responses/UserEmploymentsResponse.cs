namespace devdeer.CoffeeCupApiAccess.Logic.Models.Responses
{
    using System;
    using System.Linq;
    using System.Text.Json.Serialization;

    using DataModels;

    /// <summary>
    /// Represents the response of the CoffeeCup API when the user employments endpoint is called.
    /// </summary>
    public class UserEmploymentsResponse : BaseResponse
    {
        #region properties

        /// <summary>
        /// The list of user employments.
        /// </summary>
        [JsonPropertyName("userEmployments")]
        public UserEmployment[] UserEmployments { get; set; } = default!;

        #endregion
    }
}