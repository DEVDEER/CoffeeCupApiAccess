namespace devdeer.CoffeeCupApiAccess.Logic.Core.ResponseModels
{
    using System;
    using System.Linq;

    using Newtonsoft.Json;

    public class CoffeeCupAuthorizationResponseModel
    {
        #region properties

        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("expiration")]
        public int Expiration { get; set; }

        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }

        [JsonProperty("token_type")]
        public string TokenType { get; set; }

        #endregion
    }
}