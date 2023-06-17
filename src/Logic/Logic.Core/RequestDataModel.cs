namespace devdeer.CoffeeCupApiAccess.Logic.Core
{
    using System;
    using System.Linq;

    using Models.Settings;

    /// <summary>
    /// Transports meta-data for requests to the repository.
    /// </summary>
    public class RequestDataModel
    {
        #region constructors and destructors

        /// <summary>
        /// Default constructor taking values for all readonly properties.
        /// </summary>
        /// <param name="settings">The settings to use.</param>
        public RequestDataModel(SettingsModel settings)
        {
            Settings = settings;
        }

        #endregion

        #region properties

        /// <summary>
        /// The client id configured on CoffeeCup-side.
        /// </summary>
        public string CoffeeCupApiClientId => Settings.ClientId;

        /// <summary>
        /// The secret matching the <see cref="CoffeeCupApiClientId" />.
        /// </summary>
        public string CoffeeCupApiClientSecret => Settings.ClientSecret;

        /// <summary>
        /// The API version in the pattern "v{number}" of CoffeeCup.
        /// </summary>
        public string CoffeeCupApiVersion => Settings.CoffeeCupApiVersion;

        /// <summary>
        /// The password of the <see cref="CoffeeCupUsername" />.
        /// </summary>
        public string CoffeeCupPassword => Settings.CoffeeCupPassword;

        /// <summary>
        /// The email-address (username) of the CoffeeCup user in which name the request should happen.
        /// </summary>
        public string CoffeeCupUsername => Settings.CoffeeCupUsername;

        private SettingsModel Settings { get; }

        #endregion
    }
}