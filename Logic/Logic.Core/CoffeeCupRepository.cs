namespace devdeer.CoffeeCupApiAccess.Logic.Core
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;

    using Newtonsoft.Json;

    using ResponseModels;

    using TransportModels;

    /// <summary>
    /// Allows data retrieval from the CoffeeCup API.
    /// </summary>
    public class CoffeeCupRepository
    {
        #region member vars

        private readonly HttpClient _client;

        private int _retries;

        #endregion

        #region constants

        private static DateTime? _barerTokenInvalidationTime;

        private static string _bearerToken;

        #endregion

        #region constructors and destructors

        public CoffeeCupRepository(HttpClient client)
        {
            _client = client;
        }

        #endregion

        #region methods

        /// <summary>
        /// Retrieves the list of client information from the CoffeeCup API.
        /// </summary>
        /// <param name="requestData">The contextual data from the API which is needed by the repository.</param>
        /// <returns>The list of client information.</returns>
        public async Task<IEnumerable<CoffeeCupClientTransportModel>> GetClientsAsync(CoffeeCupRequestDataModel requestData)
        {
            var apiResult = await GetCoffeeCupApiResultAsync<CoffeeCupClientsResponseModel>(requestData, "clients");
            return apiResult.Clients.OrderBy(p => p.Name);
        }

        /// <summary>
        /// Retrieves the list of project information from the CoffeeCup API.
        /// </summary>
        /// <param name="requestData">The contextual data from the API which is needed by the repository.</param>
        /// <returns>The list of project information.</returns>
        public async Task<IEnumerable<CoffeeCupProjectTransportModel>> GetProjectsAsync(CoffeeCupRequestDataModel requestData)
        {
            var apiResult = await GetCoffeeCupApiResultAsync<CoffeeCupProjectsResponseModel>(requestData, "projects");
            return apiResult.Projects.OrderBy(p => p.Name);
        }

        /// <summary>
        /// Retrieves the list of time entries from the CoffeeCup API.
        /// </summary>
        /// <param name="requestData">The contextual data from the API which is needed by the repository.</param>
        /// <returns>The list of time entries.</returns>
        public async Task<IEnumerable<CoffeeCupTimeEntryTransportModel>> GetTimeEntriesAsync(CoffeeCupRequestDataModel requestData)
        {
            var apiResult = await GetCoffeeCupApiResultAsync<CoffeeCupTimeEntriesResponseModel>(requestData, "timeEntries");
            return apiResult.TimeEntries.OrderBy(p => p.Day).ThenBy(p => p.StartTime).ThenBy(p => p.UserId);
        }

        /// <summary>
        /// Retrieves the list of time entries from the CoffeeCup API.
        /// </summary>
        /// <param name="requestData">The contextual data from the API which is needed by the repository.</param>
        /// <param name="day">The day for which to retrieve the entries.</param>
        /// <returns>The list of time entries.</returns>
        public async Task<IEnumerable<CoffeeCupTimeEntryTransportModel>> GetTimeEntriesByDayAsync(CoffeeCupRequestDataModel requestData, DateTime day)
        {
            var relativeUrl = string.Format(CultureInfo.InvariantCulture, @"timeEntries?where={{""day"":{{"">="": ""{0}""}}}}", day.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture));
            var apiResult = await GetCoffeeCupApiResultAsync<CoffeeCupTimeEntriesResponseModel>(requestData, relativeUrl);
            return apiResult.TimeEntries.OrderBy(p => p.Day).ThenBy(p => p.StartTime).ThenBy(p => p.UserId);
        }

        /// <summary>
        /// Retrieves the list of time entries from the CoffeeCup API.
        /// </summary>
        /// <param name="requestData">The contextual data from the API which is needed by the repository.</param>
        /// <param name="from">The starting day for which to retrieve the entries.</param>
        /// <param name="to">The ending day for which to retrieve the entries.</param>
        /// <returns>The list of time entries.</returns>
        public async Task<IEnumerable<CoffeeCupTimeEntryTransportModel>> GetTimeEntriesByDayRangeAsync(CoffeeCupRequestDataModel requestData, DateTime from, DateTime to)
        {
            var relativeUrl = string.Format(
                CultureInfo.InvariantCulture,
                @"timeEntries?where={{""day"":{{"">="": ""{0}""}},{{""<="": ""{1}""}}}}",
                from.ToString("YYYY-MM-dd", CultureInfo.InvariantCulture),
                to.ToString("YYYY-MM-dd", CultureInfo.InvariantCulture));
            var apiResult = await GetCoffeeCupApiResultAsync<CoffeeCupTimeEntriesResponseModel>(requestData, relativeUrl);
            return apiResult.TimeEntries.OrderBy(p => p.Day).ThenBy(p => p.StartTime).ThenBy(p => p.UserId);
        }

        /// <summary>
        /// Retrieves the list of complete user information from the CoffeeCup API.
        /// </summary>
        /// <param name="onlyValid">If set to <c>true</c> only currently valid users will be loaded.</param>
        /// <param name="requestData">The contextual data from the API which is needed by the repository.</param>
        /// <returns>The list of user information.</returns>
        public async Task<IEnumerable<CoffeeCupUserTransportModel>> GetUsersAsync(CoffeeCupRequestDataModel requestData, bool onlyValid = true)
        {
            var apiResult = await GetCoffeeCupApiResultAsync<CoffeeCupUsersResponseModel>(requestData, "users");
            var result = apiResult.Users.OrderBy(u => u.Lastname).ThenBy(u => u.Firstname);
            return onlyValid ? result.Where(r => r.ShowInPlanner) : result;
        }

        /// <summary>
        /// Retrieves the list of simplified user information from the CoffeeCup API.
        /// </summary>
        /// <param name="onlyValid">If set to <c>true</c> only currently valid users will be loaded.</param>
        /// <param name="requestData">The contextual data from the API which is needed by the repository.</param>
        /// <returns>The list of user information.</returns>
        public async Task<IEnumerable<CoffeeCupSimpleUserTransportModel>> GetUsersSimpleAsync(CoffeeCupRequestDataModel requestData, bool onlyValid = true)
        {
            var apiResult = await GetCoffeeCupApiResultAsync<CoffeeCupUsersResponseModel>(requestData, "users");
            var result = apiResult.Users.Select(u => u.ToSimple()).OrderBy(u => u.Lastname).ThenBy(u => u.Firstname);
            return onlyValid ? result.Where(r => r.IsCurrentlyValid) : result;
        }

        /// <summary>
        /// Retrieves the currently valid or an updated bearer token from the CoffeeCup API.
        /// </summary>
        /// <param name="requestData">The contextual data from the API which is needed by the repository.</param>
        /// <returns>The a string of the pattern "Bearer {token}" if the operation succeeded.</returns>
        private async Task<string> GetBearerTokenAsync(CoffeeCupRequestDataModel requestData)
        {
            var coffeeCupUser = requestData.CoffeeCupUsername;
            var coffeeCupPass = requestData.CoffeeCupPassword;
            if (string.IsNullOrEmpty(coffeeCupUser) || string.IsNullOrEmpty(coffeeCupPass))
            {
                throw new InvalidOperationException("Invalid CoffeeCup credentials.");
            }
            if (_bearerToken == null || _barerTokenInvalidationTime.HasValue && _barerTokenInvalidationTime.Value < DateTime.Now)
            {
                // Either we've never received a bearer token or it is invalidated now.                                
                var dict = new Dictionary<string, string>
                {
                    { "grant_type", "password" },
                    { "username", coffeeCupUser },
                    { "password", coffeeCupPass },
                    { "client_id", requestData.CoffeeCupApiClientId },
                    { "client_secret", requestData.CoffeeCupApiClientSecret }
                };
                var body = new FormUrlEncodedContent(dict);
                var response = await _client.PostAsync("oauth2/token", body);
                var result = await response.Content.ReadAsStringAsync();
                var tokenResult = JsonConvert.DeserializeObject<CoffeeCupAuthorizationResponseModel>(result);
                // store token and invalidation timestamp locally
                _bearerToken = tokenResult.AccessToken;
                _barerTokenInvalidationTime = DateTime.Now.AddSeconds(tokenResult.Expiration);
            }
            return $"Bearer {_bearerToken}";
        }

        /// <summary>
        /// Retrieves a result from the CoffeeCup API and tries to convert it to <typeparamref name="TResult" />.
        /// </summary>
        /// <typeparam name="TResult">The type the result is expected to be.</typeparam>
        /// <param name="relativeUrl">The relative URL to the CoffeeCup API without the configured base address.</param>
        /// <param name="requestData">The contextual data from the API which is needed by the repository.</param>
        /// <returns>The result.</returns>
        private async Task<TResult> GetCoffeeCupApiResultAsync<TResult>(CoffeeCupRequestDataModel requestData, string relativeUrl)
        {
            var bearer = await GetBearerTokenAsync(requestData);
            if (string.IsNullOrEmpty(bearer))
            {
                throw new InvalidOperationException("Could not retrieve bearer token.");
            }
            _client.DefaultRequestHeaders.Add("Authorization", bearer);
            try
            {
                var response = await _client.GetAsync($"{requestData.CoffeeCupApiVersion}/{relativeUrl}");
                if (!response.IsSuccessStatusCode)
                {
                    // something went wrong
                    if (response.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        // seems to be a problem with the bearer token
                        if (_retries >= 3)
                        {
                            Interlocked.Exchange(ref _retries, 0);
                            throw new InvalidOperationException("Got problems with authentication against CoffeeCup.");
                        }
                        _bearerToken = null;
                        _barerTokenInvalidationTime = null;
                        Interlocked.Increment(ref _retries);
                        return await GetCoffeeCupApiResultAsync<TResult>(requestData, relativeUrl);
                    }
                }
                var result = await response.Content.ReadAsStringAsync();
                var converted = JsonConvert.DeserializeObject<TResult>(result);
                return converted;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        #endregion
    }
}