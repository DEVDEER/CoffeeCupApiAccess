namespace devdeer.CoffeeCupApiAccess.Logic.Core
{
    using System;
    using System.Linq;

    /// <summary>
    /// Transports meta-data for requests to the repository.
    /// </summary>
    public class RequestDataModel
    {
        #region constructors and destructors

        /// <summary>
        /// Default constructor taking values for all readonly properties.
        /// </summary>
        /// <param name="coffeeCupApiVersion">The API version in the pattern "v{number}" of CoffeeCup.</param>
        /// <param name="coffeeCupApiClientId">The client id configured on CoffeeCup-side.</param>
        /// <param name="coffeeCupApiClientSecret">The secret matching the <paramref name="coffeeCupApiClientId" />.</param>
        /// <param name="coffeeCupUsername">
        /// The email-address (username) of the CoffeeCup user in which name the request should
        /// happen.
        /// </param>
        /// <param name="coffeeCupPassword">The password of the <paramref name="coffeeCupUsername" />.</param>
        public RequestDataModel(string coffeeCupApiVersion, string coffeeCupApiClientId, string coffeeCupApiClientSecret, string coffeeCupUsername, string coffeeCupPassword)
        {
            CoffeeCupApiVersion = coffeeCupApiVersion;
            CoffeeCupApiClientId = coffeeCupApiClientId;
            CoffeeCupApiClientSecret = coffeeCupApiClientSecret;
            CoffeeCupUsername = coffeeCupUsername;
            CoffeeCupPassword = coffeeCupPassword;
        }

        #endregion

        #region properties

        /// <summary>
        /// The client id configured on CoffeeCup-side.
        /// </summary>
        public string CoffeeCupApiClientId { get; }

        /// <summary>
        /// The secret matching the <see cref="CoffeeCupApiClientId" />.
        /// </summary>
        public string CoffeeCupApiClientSecret { get; }

        /// <summary>
        /// The API version in the pattern "v{number}" of CoffeeCup.
        /// </summary>
        public string CoffeeCupApiVersion { get; }

        /// <summary>
        /// The password of the <see cref="CoffeeCupUsername" />.
        /// </summary>
        public string CoffeeCupPassword { get; }

        /// <summary>
        /// The email-address (username) of the CoffeeCup user in which name the request should happen.
        /// </summary>
        public string CoffeeCupUsername { get; }

        #endregion
    }
}