namespace devdeer.CoffeeCupApiAccess.Logic.Models.Responses
{
    using System;
    using System.Linq;
    using System.Text.Json.Serialization;

    using DataModels;

    /// <summary>
    /// Represents the response of the CoffeeCup API when the users endpoint is called.
    /// </summary>
    public class UsersResponse : BaseResponse
    {
        #region properties

        /// <summary>
        /// The list of user information.
        /// </summary>
        [JsonPropertyName("users")]
        public User[] Users { get; set; } = default!;

        #endregion
    }
}