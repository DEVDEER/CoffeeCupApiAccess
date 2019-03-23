namespace devdeer.CoffeeCupApiAccess.Logic.Models.ResponseModels
{
    using System;
    using System.Linq;

    using Newtonsoft.Json;

    /// <summary>
    /// Represents the result from the authorization endpoint.
    /// </summary>
    public class AuthorizationResponseModel
    {
        #region properties

        /// <summary>
        /// The access token to use.
        /// </summary>
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        /// <summary>
        /// The seconds from now on which the <see cref="AccessToken" /> will expire.
        /// </summary>
        [JsonProperty("expiration")]
        public int Expiration { get; set; }

        /// <summary>
        /// The refresh token to send to the API after the <see cref="AccessToken" /> expired.
        /// </summary>
        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }

        /// <summary>
        /// The type of the token.
        /// </summary>
        [JsonProperty("token_type")]
        public string TokenType { get; set; }

        #endregion
    }
}