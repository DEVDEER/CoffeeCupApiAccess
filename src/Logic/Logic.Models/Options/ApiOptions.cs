namespace devdeer.CoffeeCupApiAccess.Logic.Models.Options
{
    using System;
    using System.Linq;

    /// <summary>
    /// Represents the data for the API access settings.
    /// </summary>
    public class ApiOptions
    {
        #region properties

        /// <summary>
        /// The API version in the form "vX".
        /// </summary>
        public string ApiVersion { get; set; } = default!;

        /// <summary>
        /// The registered client ID at CoffeeCup.
        /// </summary>
        public string ClientId { get; set; } = default!;

        /// <summary>
        /// The secret matching the <see cref="ClientId" />.
        /// </summary>
        public string ClientSecret { get; set; } = default!;

        /// <summary>
        /// The Coffee Cup username with which to perform the request.
        /// </summary>
        public string Username { get; set; } = default!;

        /// <summary>
        /// The password for the <see cref="Username" />.
        /// </summary>
        public string Password { get; set; } = default!;

        /// <summary>
        /// The Coffee Cup tenant URL in the form https://TENANT.coffeecupapp.com.
        /// </summary>
        public string Origin { get; set; } = default!;

        #endregion
    }
}