namespace devdeer.CoffeeCupApiAccess.Logic.Core
{
    using System;
    using System.Linq;

    using Models.Options;

    /// <summary>
    /// Transports meta-data for requests to the repository.
    /// </summary>
    public class RequestDataModel
    {
        #region constructors and destructors

        /// <summary>
        /// Default constructor taking values for all readonly properties.
        /// </summary>
        /// <param name="options">The options to use.</param>
        public RequestDataModel(ApiOptions options)
        {
            Options = options;
        }

        #endregion

        #region properties

        /// <summary>
        /// The client id configured on CoffeeCup-side.
        /// </summary>
        public string CoffeeCupApiClientId => Options.ClientId;

        /// <summary>
        /// The secret matching the <see cref="CoffeeCupApiClientId" />.
        /// </summary>
        public string CoffeeCupApiClientSecret => Options.ClientSecret;

        /// <summary>
        /// The API version in the pattern "v{number}" of CoffeeCup.
        /// </summary>
        public string CoffeeCupApiVersion => Options.ApiVersion;

        /// <summary>
        /// The password of the <see cref="CoffeeCupUsername" />.
        /// </summary>
        public string CoffeeCupPassword => Options.Password;

        /// <summary>
        /// The email-address (username) of the CoffeeCup user in which name the request should happen.
        /// </summary>
        public string CoffeeCupUsername => Options.Username;

        /// <summary>
        /// The injected configuration options.
        /// </summary>
        private ApiOptions Options { get; }

        #endregion
    }
}