namespace devdeer.CoffeeCupApiAccess.Tests.Logic.Core
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Net.Http;
    using System.Text.Json;
    using System.Threading.Tasks;

    using CoffeeCupApiAccess.Logic.Core;

    using NUnit.Framework;

    /// <summary>
    /// Contains end-2-end-tests for the <see cref="CoffeeCupAccess" />.
    /// </summary>
    [TestFixture]
    public class CoffeeCupApiAccessTests
    {
        #region methods

        /// <summary>
        /// Simple null-check for <see cref="CoffeeCupAccess.GetTimeEntriesAsync" />.
        /// </summary>
        [Test]
        public async Task GetTimeEntries_RetrievesNotNull()
        {
            Assert.IsNotNull(ApiAccess, "Logic not initialized");
            var result = await ApiAccess.GetTimeEntriesAsync(RequestModel);
            Assert.IsNotNull(result);
        }

        /// <summary>
        /// Reads the values from the settings.json file if it exists.
        /// </summary>
        [OneTimeSetUp]
        public void Init()
        {
            if (!File.Exists("settings.json"))
            {
                return;
            }
            // the file was found -> map the data
            var json = File.ReadAllText("settings.json");
            var document = JsonDocument.Parse(json);
            var version = document.RootElement.GetProperty("CoffeeCupApiVersion").GetString();
            var clientId = document.RootElement.GetProperty("CoffeeCupApiClientId").GetString();
            var clientSecret = document.RootElement.GetProperty("CoffeeCupApiClientSecret").GetString();
            var user = document.RootElement.GetProperty("CoffeeCupUsername").GetString();
            var pass = document.RootElement.GetProperty("CoffeeCupPassword").GetString();
            var origin = document.RootElement.GetProperty("CoffeeCupOrigin").GetString();
            // generate a new request model
            RequestModel = new RequestDataModel(version, clientId, clientSecret, user, pass);
            // initialize HTTP client and logic
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://api.coffeecupapp.com")
            };
            client.DefaultRequestHeaders.Add("Origin", origin);
            ApiAccess = new CoffeeCupAccess(client);
        }

        #endregion

        #region properties

        /// <summary>
        /// Provides easy access to the initialized logic.
        /// </summary>
        private CoffeeCupAccess ApiAccess { get; set; }

        /// <summary>
        /// Retrieves the prepared request model needed by the <see cref="ApiAccess" />.
        /// </summary>
        private RequestDataModel RequestModel { get; set; }

        #endregion
    }
}