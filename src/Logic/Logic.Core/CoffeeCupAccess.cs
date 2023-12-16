namespace devdeer.CoffeeCupApiAccess.Logic.Core
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Globalization;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Security.Authentication;
    using System.Text;
    using System.Text.Json;
    using System.Text.Json.Serialization;
    using System.Threading.Tasks;

    using Models.Requests;
    using Models.Responses;
    using Models.TransportModels;
    using Models.TransportModels.Analytics;

    /// <summary>
    /// Allows data retrieval from the CoffeeCup API.
    /// </summary>
    public class CoffeeCupAccess
    {
        #region member vars

        private readonly HttpClient _client;

        private JsonSerializerOptions? _options;

        #endregion

        #region constants

        private static DateTime? _barerTokenInvalidationTime;

        private static string? _bearerToken;

        private static string? _refreshToken;

        #endregion

        #region constructors and destructors

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="client">The HTTP client to use.</param>
        public CoffeeCupAccess(HttpClient client)
        {
            _client = client;
        }

        #endregion

        #region methods

        /// <summary>
        /// Retrieves the list of absence information from the CoffeeCup API.
        /// </summary>
        /// <param name="requestData">The contextual data from the API which is needed by the access logic.</param>
        /// <returns>The list of absence information ordered by date and user.</returns>
        public async Task<AbsenceTransportModel[]?> GetAbsencesAsync(RequestDataModel requestData)
        {
            var apiResult = await GetCoffeeCupApiResultAsync<AbsencesReponseModel>(requestData, "absences");
            return apiResult?.Absences.OrderByDescending(p => p.StartDate)
                .ThenBy(p => p.UserId).ToArray();
        }

        /// <summary>
        /// Retrieves the list of task information from the CoffeeCup API.
        /// </summary>
        /// <param name="requestData">The contextual data from the API which is needed by the access logic.</param>
        /// <returns>The list of task information ordered by label.</returns>
        public async Task<AbsenceTypeTransportModel[]?> GetAbsenceTypesAsync(RequestDataModel requestData)
        {
            var apiResult = await GetCoffeeCupApiResultAsync<AbsenceTypesResponseModel>(requestData, "absenceTypes");
            return apiResult?.AbsenceTypes.OrderBy(p => p.Label).ToArray();
        }

        /// <summary>
        /// Retrieves the list of client information from the CoffeeCup API.
        /// </summary>
        /// <param name="requestData">The contextual data from the API which is needed by the access logic.</param>
        /// <returns>The list of client information.</returns>
        public async Task<ClientTransportModel[]?> GetClientsAsync(RequestDataModel requestData)
        {
            var apiResult = await GetCoffeeCupApiResultAsync<ClientsResponseModel>(requestData, "clients");
            return apiResult?.Clients.OrderBy(p => p.Name).ToArray();
        }

        /// <summary>
        /// Retrieves the list of color information from the CoffeeCup API.
        /// </summary>
        /// <param name="requestData">The contextual data from the API which is needed by the access logic.</param>
        /// <returns>The list of color information.</returns>
        public async Task<ColorTransportModel[]?> GetColorsAsync(RequestDataModel requestData)
        {
            var apiResult = await GetCoffeeCupApiResultAsync<ColorsResponseModel>(requestData, "colors");
            return apiResult?.Colors.OrderBy(p => p.Label).ToArray();
        }

        /// <summary>
        /// Retrieves the analytics data for a single project identified by its <paramref name="projectId" />.
        /// </summary>
        /// <param name="requestData">The contextual data from the API which is needed by the access logic.</param>
        /// <param name="projectId">The unique id of the project in CoffeeCup.</param>
        /// <returns>The project information or <c>null</c> if the project wasn't found.</returns>
        public async Task<ProjectAnalyticsTransportModel?> GetProjectAnalyticsAsync(
            RequestDataModel requestData,
            int projectId)
        {
            var apiResult = await GetCoffeeCupApiResultAsync<ProjectAnalyticsResponseModel>(
                requestData,
                $"analytics/projects?project={projectId}");
            return apiResult?.Project;
        }

        /// <summary>
        /// Retrieves the list of project information from the CoffeeCup API.
        /// </summary>
        /// <param name="requestData">The contextual data from the API which is needed by the access logic.</param>
        /// <returns>The list of project information.</returns>
        public async Task<ProjectTransportModel[]?> GetProjectsAsync(RequestDataModel requestData)
        {
            var apiResult = await GetCoffeeCupApiResultAsync<ProjectsResponseModel>(requestData, "projects");
            return apiResult?.Projects.OrderBy(p => p.Name).ToArray();
        }

        /// <summary>
        /// Retrieves the list of task assignments from the CoffeeCup API.
        /// </summary>
        /// <param name="requestData">The contextual data from the API which is needed by the access logic.</param>
        /// <returns>The list of task assignments.</returns>
        public async Task<TaskAssignmentTransportModel[]?> GetTaskAssignmentsAsync(
            RequestDataModel requestData)
        {
            var apiResult =
                await GetCoffeeCupApiResultAsync<TaskAssignmentsResponseModel>(requestData, "taskAssignments");
            return apiResult?.TaskAssignments.ToArray();
        }

        /// <summary>
        /// Retrieves the list of task information from the CoffeeCup API.
        /// </summary>
        /// <param name="requestData">The contextual data from the API which is needed by the access logic.</param>
        /// <returns>The list of task information.</returns>
        public async Task<TaskTransportModel[]?> GetTasksAsync(RequestDataModel requestData)
        {
            var apiResult = await GetCoffeeCupApiResultAsync<TasksResponseModel>(requestData, "tasks");
            return apiResult?.Tasks.OrderBy(p => p.Label).ToArray();
        }

        /// <summary>
        /// Retrieves a list of entries for time entries based on a given <paramref name="filter"/>.
        /// </summary>
        /// <param name="requestData">The contextual data from the API which is needed by the access logic.</param>
        /// <param name="filter">The options for filtering the request.</param>
        /// <returns>The list of matching results.</returns>
        /// <exception cref="ArgumentException">Is thrown if from or to are invalid.</exception>
        public async Task<TimeEntryTransportModel[]?> GetTimeEntriesAsync(
            RequestDataModel requestData,
            TimeEntriesRequest filter)
        {
            var urlBuilder = new StringBuilder("timeEntries");
            var postProjectFilter = false;
            if ((filter is { From: null, To: null}) && (filter.ProjectFilterIds?.Any() ?? false))
            {
                urlBuilder.AppendFormat(
                    CultureInfo.InvariantCulture,
                    "?project[]={0}",
                    filter.ProjectFilterIds.First());
            }
            else if (filter is { From: not null, To: not null })
            {
                if (filter.From.Value >= DateTime.Now)
                {
                    throw new ArgumentException("The from date must be in the past.", nameof(filter.From));
                }
                if (filter.From.Value > filter.To.Value)
                {
                    throw new ArgumentException("The from date must lay before the to date.", nameof(filter.To));
                }
                urlBuilder.AppendFormat(
                    CultureInfo.InvariantCulture,
                    @"?where={{""day"":{{"">="": ""{0}"", ""<="": ""{1}""}}}}",
                    filter.From.Value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture),
                    filter.To.Value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture));
                postProjectFilter = (filter.ProjectFilterIds?.Any() ?? false);
            }
            var apiResult =
                await GetCoffeeCupApiResultAsync<TimeEntriesResponseModel>(requestData, urlBuilder.ToString());
            var items = apiResult?.TimeEntries.AsQueryable();
            if (items != null)
            {
                if (postProjectFilter && (filter.ProjectFilterIds?.Any() ?? false))
                {
                    items = items.Where(i => i.ProjectId != null && i.ProjectId == filter.ProjectFilterIds.First());
                }
            }
            return items?.ToArray();
        }

        /// <summary>
        /// Retrieves a list of entries for time-entry-analytics based on a given time range.
        /// </summary>
        /// <param name="requestData">The contextual data from the API which is needed by the access logic.</param>
        /// <param name="from">The start date for the analysis result.</param>
        /// <param name="to">The end date for the analysis result.</param>
        /// <returns>The list of matching analytics results.</returns>
        /// <exception cref="ArgumentException">Is thrown if from or to are invalid.</exception>
        public async Task<TimeEntryAnalyticsTransportModel[]?> GetTimeEntriesAnalyticsAsync(
            RequestDataModel requestData,
            DateTime from,
            DateTime to)
        {
            if (from >= DateTime.Now)
            {
                throw new ArgumentException("The from date must be in the past.", nameof(from));
            }
            if (from > to)
            {
                throw new ArgumentException("The from date must lay before the to date.", nameof(to));
            }
            var relativeUrl = string.Format(
                CultureInfo.InvariantCulture,
                @"timeEntries?start_date={0}&end_date={1}",
                from.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture),
                to.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture));
            var apiResult =
                await GetCoffeeCupApiResultAsync<AnalyticsTimeEntriesResponseModel>(requestData, relativeUrl);
            return apiResult?.TimeEntries;
        }

        /// <summary>
        /// Retrieves the list of time entries from the CoffeeCup API.
        /// </summary>
        /// <param name="requestData">The contextual data from the API which is needed by the access logic.</param>
        /// <returns>The list of time entries.</returns>
        public async Task<TimeEntryTransportModel[]?> GetTimeEntriesAsync(RequestDataModel requestData)
        {
            var apiResult = await GetCoffeeCupApiResultAsync<TimeEntriesResponseModel>(requestData, "timeEntries");
            return apiResult?.TimeEntries.OrderBy(p => p.Day)
                .ThenBy(p => p.StartTime)
                .ThenBy(p => p.UserId).ToArray();
        }

        /// <summary>
        /// Retrieves the list of time entries from the CoffeeCup API.
        /// </summary>
        /// <param name="requestData">The contextual data from the API which is needed by the access logic.</param>
        /// <param name="day">The day for which to retrieve the entries.</param>
        /// <returns>The list of time entries.</returns>
        public async Task<TimeEntryTransportModel[]?> GetTimeEntriesByDayAsync(
            RequestDataModel requestData,
            DateTime day)
        {
            var relativeUrl = string.Format(
                CultureInfo.InvariantCulture,
                @"timeEntries?where={{""day"":{{"">="": ""{0}""}}}}",
                day.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture));
            var apiResult = await GetCoffeeCupApiResultAsync<TimeEntriesResponseModel>(requestData, relativeUrl);
            return apiResult?.TimeEntries.OrderBy(p => p.Day)
                .ThenBy(p => p.StartTime)
                .ThenBy(p => p.UserId).ToArray();
        }

        /// <summary>
        /// Retrieves the list of time entries from the CoffeeCup API.
        /// </summary>
        /// <param name="requestData">The contextual data from the API which is needed by the access logic.</param>
        /// <param name="from">The starting day for which to retrieve the entries.</param>
        /// <param name="to">The ending day for which to retrieve the entries.</param>
        /// <returns>The list of time entries.</returns>
        public async Task<TimeEntryTransportModel[]?> GetTimeEntriesByDayRangeAsync(
            RequestDataModel requestData,
            DateTime from,
            DateTime to)
        {
            var relativeUrl = string.Format(
                CultureInfo.InvariantCulture,
                @"timeEntries?where={{""day"":{{"">="": ""{0}"", ""<="": ""{1}""}}}}",
                from.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture),
                to.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture));
            Trace.WriteLine(relativeUrl);
            var apiResult = await GetCoffeeCupApiResultAsync<TimeEntriesResponseModel>(requestData, relativeUrl);
            return apiResult?.TimeEntries.OrderBy(p => p.Day)
                .ThenBy(p => p.StartTime)
                .ThenBy(p => p.UserId).ToArray();
        }

        /// <summary>
        /// Retrieves the list of user assignments from the CoffeeCup API.
        /// </summary>
        /// <param name="requestData">The contextual data from the API which is needed by the access logic.</param>
        /// <returns>The list of user assignments.</returns>
        public async Task<UserAssignmentTransportModel[]?> GetUserAssignmentsAsync(
            RequestDataModel requestData)
        {
            var apiResult =
                await GetCoffeeCupApiResultAsync<UserAssignmentsResponseModel>(requestData, "userAssignments");
            return apiResult?.UserAssignments;
        }

        /// <summary>
        /// Retrieves the list of user employments from the CoffeeCup API.
        /// </summary>
        /// <param name="requestData">The contextual data from the API which is needed by the access logic.</param>
        /// <returns>The list of user employments.</returns>
        public async Task<UserEmploymentTransportModel[]?> GetUserEmploymentsAsync(
            RequestDataModel requestData)
        {
            var apiResult =
                await GetCoffeeCupApiResultAsync<UserEmploymentsResponseModel>(requestData, "userEmployments");
            return apiResult?.UserEmployments;
        }

        /// <summary>
        /// Retrieves the list of complete user information from the CoffeeCup API.
        /// </summary>
        /// <param name="onlyValid">If set to <c>true</c> only currently valid users will be loaded.</param>
        /// <param name="requestData">The contextual data from the API which is needed by the access logic.</param>
        /// <returns>The list of user information.</returns>
        public async Task<UserTransportModel[]?> GetUsersAsync(
            RequestDataModel requestData,
            bool onlyValid = true)
        {
            var apiResult = await GetCoffeeCupApiResultAsync<UsersResponseModel>(requestData, "users");
            var result = apiResult?.Users.OrderBy(u => u.Lastname)
                .ThenBy(u => u.Firstname);
            return onlyValid ? result?.Where(r => r.ShowInPlanner).ToArray() : result?.ToArray();
        }

        /// <summary>
        /// Retrieves the list of simplified user information from the CoffeeCup API.
        /// </summary>
        /// <param name="onlyValid">If set to <c>true</c> only currently valid users will be loaded.</param>
        /// <param name="requestData">The contextual data from the API which is needed by the access logic.</param>
        /// <returns>The list of user information.</returns>
        public async Task<SimpleUserTransportModel[]?> GetUsersSimpleAsync(
            RequestDataModel requestData,
            bool onlyValid = true)
        {
            var apiResult = await GetCoffeeCupApiResultAsync<UsersResponseModel>(requestData, "users");
            var result = apiResult?.Users.Select(u => u.ToSimple())
                .OrderBy(u => u.Lastname)
                .ThenBy(u => u.Firstname);
            return onlyValid ? result?.Where(r => r.IsCurrentlyValid).ToArray() : result?.ToArray();
        }

        /// <summary>
        /// Retrieves the currently valid or an updated bearer token from the CoffeeCup API.
        /// </summary>
        /// <param name="requestData">The contextual data from the API which is needed by the access logic.</param>
        /// <returns>The a string of the pattern "Bearer {token}" if the operation succeeded.</returns>
        private async Task<string> GetBearerTokenAsync(RequestDataModel requestData)
        {
            var coffeeCupUser = requestData.CoffeeCupUsername;
            var coffeeCupPass = requestData.CoffeeCupPassword;
            if (string.IsNullOrEmpty(coffeeCupUser) || string.IsNullOrEmpty(coffeeCupPass))
            {
                throw new InvalidOperationException("Invalid CoffeeCup credentials.");
            }
            if (_bearerToken == null
                || (_barerTokenInvalidationTime.HasValue && _barerTokenInvalidationTime.Value < DateTime.Now))
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
                try
                {
                    var response = await _client.PostAsync("oauth2/token", body);
                    var result = await response.Content.ReadAsStringAsync();
                    var tokenResult = JsonSerializer.Deserialize<AuthorizationResponseModel>(result);
                    if (tokenResult == null)
                    {
                        throw new AuthenticationException("Could not receive token from CoffeeCup.");
                    }
                    // store token, refresh and invalidation timestamp locally
                    _bearerToken = tokenResult.AccessToken;
                    _refreshToken = tokenResult.RefreshToken;
                    _barerTokenInvalidationTime = DateTime.Now.AddSeconds(tokenResult.Expiration);
                }
                catch (Exception ex)
                {
                    Trace.TraceError(ex.Message);
                }
            }
            return $"Bearer {_bearerToken}";
        }

        /// <summary>
        /// Retrieves a result from the CoffeeCup API and tries to convert it to <typeparamref name="TResult" />.
        /// </summary>
        /// <typeparam name="TResult">The type the result is expected to be.</typeparam>
        /// <param name="relativeUrl">The relative URL to the CoffeeCup API without the configured base address.</param>
        /// <param name="requestData">The contextual data from the API which is needed by the access logic.</param>
        /// <returns>The result.</returns>
        private async Task<TResult?> GetCoffeeCupApiResultAsync<TResult>(
            RequestDataModel requestData,
            string relativeUrl)
        {
            if (_barerTokenInvalidationTime <= DateTime.Now)
            {
                // we have to refresh the token
                var ok = await RefreshBearerTokenAsync(requestData);
                if (!ok)
                {
                    throw new ApplicationException("Could not refresh authentication token.");
                }
            }
            var bearer = await GetBearerTokenAsync(requestData);
            if (string.IsNullOrEmpty(bearer))
            {
                throw new InvalidOperationException("Could not retrieve bearer token.");
            }
            if (_client.DefaultRequestHeaders.Contains("Authorization"))
            {
                _client.DefaultRequestHeaders.Remove("Authorization");
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
                        throw new ApplicationException(
                            "Could not read data from CoffeeCup-API due to authorization issues.");
                    }
                    throw new ApplicationException(
                        $"Could not read data from CoffeeCup-API due to response code {response.StatusCode}.");
                }
                var result = await response.Content.ReadAsStringAsync();
                var converted = JsonSerializer.Deserialize<TResult>(result, Options);
                return converted;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        /// <summary>
        /// Retrieves the currently valid or an updated bearer token from the CoffeeCup API.
        /// </summary>
        /// <param name="requestData">The contextual data from the API which is needed by the access logic.</param>
        /// <returns>The a string of the pattern "Bearer {token}" if the operation succeeded.</returns>
        private async Task<bool> RefreshBearerTokenAsync(RequestDataModel requestData)
        {
            if (string.IsNullOrEmpty(_refreshToken))
            {
                throw new InvalidOperationException("No refresh token defined.");
            }
            try
            {
                var dict = new Dictionary<string, string>
                {
                    { "grant_type", "refresh_token" },
                    { "refresh_token", _refreshToken },
                    { "client_id", requestData.CoffeeCupApiClientId },
                    { "client_secret", requestData.CoffeeCupApiClientSecret }
                };
                var body = new FormUrlEncodedContent(dict);
                var response = await _client.PostAsync("oauth2/token", body);
                var result = await response.Content.ReadAsStringAsync();
                var tokenResult = JsonSerializer.Deserialize<AuthorizationResponseModel>(result);
                if (tokenResult == null)
                {
                    throw new AuthenticationException("Could not receive token from CoffeeCup.");
                }
                // store token, refresh and invalidation timestamp locally
                _bearerToken = tokenResult.AccessToken;
                _refreshToken = tokenResult.RefreshToken;
                _barerTokenInvalidationTime = DateTime.Now.AddSeconds(tokenResult.Expiration);
                return true;
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.Message);
                return false;
            }
        }

        #endregion

        #region properties

        /// <summary>
        /// Retrieves the lazy initialized options for JSON converting.
        /// </summary>
        private JsonSerializerOptions Options
        {
            get
            {
                if (_options != null)
                {
                    return _options;
                }
                _options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                _options.Converters.Add(new JsonDateTimeConverter());
                _options.Converters.Add(new JsonStringEnumConverter());
                _options.Converters.Add(new JsonIntConverter());
                _options.Converters.Add(new JsonNullableIntConverter());
                return _options;
            }
        }

        #endregion
    }
}