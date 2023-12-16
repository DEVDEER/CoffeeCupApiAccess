namespace devdeer.CoffeeCupApiAccess.Tests.Logic.Core
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text.Json;

    using CoffeeCupApiAccess.Logic.Core;
    using CoffeeCupApiAccess.Logic.Models.Options;

    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Options;

    /// <summary>
    /// Is used as the local DI container for unit tests.
    /// </summary>
    internal static class DependencyHelper
    {
        #region constants

        private static IServiceProvider? _provider;

        #endregion

        #region methods

        /// <summary>
        /// Retrieves an instance of the required <typeparamref name="T" />.
        /// </summary>
        /// <typeparam name="T">The type of the required service.</typeparam>
        /// <returns>The resolved instance.</returns>
        public static T GetRequiredService<T>()
        {
            return Provider.GetRequiredService<T>();
        }

        #endregion

        #region properties

        private static IServiceProvider Provider
        {
            get
            {
                if (_provider == null)
                {
                    var services = new ServiceCollection();
                    services.AddLogging();
                    services.AddOptions<ApiOptions>()
                        .Configure(
                            a =>
                            {
                                if (!File.Exists("appsettings.json"))
                                {
                                    return;
                                }
                                // the file was found -> map the data
                                var json = File.ReadAllText("appsettings.json");
                                var document = JsonSerializer.Deserialize<ApiOptions>(json);
                                a.ApiVersion = document.ApiVersion;
                                a.ClientId = document.ClientId;
                                a.ClientSecret = document.ClientSecret;
                                a.Origin = document.Origin;
                                a.Username = document.Username;
                                a.Password = document.Password;
                            });
                    services.AddHttpClient<CoffeeCupAccess>(
                        c =>
                        {
                            var options = GetRequiredService<IOptions<ApiOptions>>();
                            c.BaseAddress = new Uri("https://api.coffeecupapp.com");
                            c.DefaultRequestHeaders.Add("Origin", options.Value.Origin);
                        });
                    _provider = services.BuildServiceProvider();
                }
                return _provider;
            }
        }

        #endregion
    }
}