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

    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;

    using Models.Options;
    using Models.Requests;
    using Models.Responses;
    using Models.DataModels;
    using Models.DataModels.Analytics;

    using CoffeeCupTask = Models.DataModels.Task;

    /// <summary>
    /// Allows data retrieval from the CoffeeCup API.
    /// </summary>
    public class CoffeeCupAccess
    {
        #region member vars

        private readonly ApiOptions _apiOptions;

        private readonly HttpClient _client;

        private readonly ILogger<CoffeeCupAccess> _logger;

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
        /// <param name="logger">The logger to use.</param>
        /// <param name="apiOptions">The configuration options of the API.</param>
        public CoffeeCupAccess(HttpClient client, ILogger<CoffeeCupAccess> logger, IOptions<ApiOptions> apiOptions)
        {
            _client = client;
            _logger = logger;
            _apiOptions = apiOptions.Value;
        }

        #endregion

        #region methods

        /// <summary>
        /// Retrieves the list of absence information from the CoffeeCup API.
        /// </summary>
        /// <returns>The list of absence information ordered by date and user.</returns>
        public async Task<Absence[]?> GetAbsencesAsync()
        {
            var apiResult = await GetCoffeeCupApiResultAsync<AbsencesReponse>("absences");
            return apiResult?.Absences.OrderByDescending(p => p.StartDate)
                .ThenBy(p => p.UserId)
                .ToArray();
        }

        /// <summary>
        /// Retrieves the list of task information from the CoffeeCup API.
        /// </summary>
        /// <returns>The list of task information ordered by label.</returns>
        public async Task<AbsenceType[]?> GetAbsenceTypesAsync()
        {
            var apiResult = await GetCoffeeCupApiResultAsync<AbsenceTypesResponse>("absenceTypes");
            return apiResult?.AbsenceTypes.OrderBy(p => p.Label)
                .ToArray();
        }

        /// <summary>
        /// Retrieves the list of client information from the CoffeeCup API.
        /// </summary>
        /// <returns>The list of client information.</returns>
        public async Task<Client[]?> GetClientsAsync()
        {
            var apiResult = await GetCoffeeCupApiResultAsync<ClientsResponseModel>("clients");
            return apiResult?.Clients.OrderBy(p => p.Name)
                .ToArray();
        }

        /// <summary>
        /// Retrieves the list of color information from the CoffeeCup API.
        /// </summary>
        /// <returns>The list of color information.</returns>
        public async Task<Color[]?> GetColorsAsync()
        {
            var apiResult = await GetCoffeeCupApiResultAsync<ColorsResponse>("colors");
            return apiResult?.Colors.OrderBy(p => p.Label)
                .ToArray();
        }

        /// <summary>
        /// Retrieves the analytics data for a single project identified by its <paramref name="projectId" />.
        /// </summary>
        /// <param name="projectId">The unique id of the project in CoffeeCup.</param>
        /// <returns>The project information or <c>null</c> if the project wasn't found.</returns>
        public async Task<ProjectAnalytics?> GetProjectAnalyticsAsync(int projectId)
        {
            var apiResult = await GetCoffeeCupApiResultAsync<ProjectAnalyticsResponse>(
                $"analytics/projects?project={projectId}");
            return apiResult?.Project;
        }

        /// <summary>
        /// Retrieves the list of project information from the CoffeeCup API.
        /// </summary>
        /// <returns>The list of project information.</returns>
        public async Task<Project[]?> GetProjectsAsync()
        {
            var apiResult = await GetCoffeeCupApiResultAsync<ProjectsResponseModel>("projects");
            return apiResult?.Projects.OrderBy(p => p.Name)
                .ToArray();
        }

        /// <summary>
        /// Retrieves the list of task assignments from the CoffeeCup API.
        /// </summary>
        /// <returns>The list of task assignments.</returns>
        public async Task<TaskAssignment[]?> GetTaskAssignmentsAsync()
        {
            var apiResult = await GetCoffeeCupApiResultAsync<TaskAssignmentsResponse>("taskAssignments");
            return apiResult?.TaskAssignments.ToArray();
        }

        /// <summary>
        /// Retrieves the list of task information from the CoffeeCup API.
        /// </summary>
        /// <returns>The list of task information.</returns>
        public async Task<CoffeeCupTask[]?> GetTasksAsync()
        {
            var apiResult = await GetCoffeeCupApiResultAsync<TasksResponse>("tasks");
            return apiResult?.Tasks.OrderBy(p => p.Label).ToArray();
        }

        /// <summary>
        /// Retrieves a list of entries for time-entry-analytics based on a given time range.
        /// </summary>
        /// <param name="from">The start date for the analysis result.</param>
        /// <param name="to">The end date for the analysis result.</param>
        /// <returns>The list of matching analytics results.</returns>
        /// <exception cref="ArgumentException">Is thrown if from or to are invalid.</exception>
        public async Task<TimeEntryAnalytics[]?> GetTimeEntriesAnalyticsAsync(DateTime from, DateTime to)
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
            var apiResult = await GetCoffeeCupApiResultAsync<AnalyticsTimeEntriesResponseModel>(relativeUrl);
            return apiResult?.TimeEntries;
        }

        /// <summary>
        /// Retrieves a list of entries for time entries based on a given <paramref name="filter" />.
        /// </summary>
        /// <param name="filter">The apiOptions for filtering the request.</param>
        /// <returns>The list of matching results.</returns>
        /// <exception cref="ArgumentException">Is thrown if from or to are invalid.</exception>
        public async Task<TimeEntry[]?> GetTimeEntriesAsync(TimeEntriesRequest filter)
        {
            var urlBuilder = new StringBuilder("timeEntries");
            var postProjectFilter = false;
            if (filter is { From: null, To: null } && (filter.ProjectFilterIds?.Any() ?? false))
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
                postProjectFilter = filter.ProjectFilterIds?.Any() ?? false;
            }
            var apiResult = await GetCoffeeCupApiResultAsync<TimeEntriesResponseModel>(urlBuilder.ToString());
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
        /// Retrieves the list of time entries from the CoffeeCup API.
        /// </summary>
        /// <returns>The list of time entries.</returns>
        public async Task<TimeEntry[]?> GetTimeEntriesAsync()
        {
            var apiResult = await GetCoffeeCupApiResultAsync<TimeEntriesResponseModel>("timeEntries");
            return apiResult?.TimeEntries.OrderBy(p => p.Day)
                .ThenBy(p => p.StartTime)
                .ThenBy(p => p.UserId)
                .ToArray();
        }

        /// <summary>
        /// Retrieves the list of time entries from the CoffeeCup API.
        /// </summary>
        /// <param name="day">The day for which to retrieve the entries.</param>
        /// <returns>The list of time entries.</returns>
        public async Task<TimeEntry[]?> GetTimeEntriesByDayAsync(DateTime day)
        {
            var relativeUrl = string.Format(
                CultureInfo.InvariantCulture,
                @"timeEntries?where={{""day"":{{"">="": ""{0}""}}}}",
                day.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture));
            var apiResult = await GetCoffeeCupApiResultAsync<TimeEntriesResponseModel>(relativeUrl);
            return apiResult?.TimeEntries.OrderBy(p => p.Day)
                .ThenBy(p => p.StartTime)
                .ThenBy(p => p.UserId)
                .ToArray();
        }

        /// <summary>
        /// Retrieves the list of time entries from the CoffeeCup API.
        /// </summary>
        /// <param name="from">The starting day for which to retrieve the entries.</param>
        /// <param name="to">The ending day for which to retrieve the entries.</param>
        /// <returns>The list of time entries.</returns>
        public async Task<TimeEntry[]?> GetTimeEntriesByDayRangeAsync(DateTime from, DateTime to)
        {
            var relativeUrl = string.Format(
                CultureInfo.InvariantCulture,
                @"timeEntries?where={{""day"":{{"">="": ""{0}"", ""<="": ""{1}""}}}}",
                from.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture),
                to.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture));
            Trace.WriteLine(relativeUrl);
            var apiResult = await GetCoffeeCupApiResultAsync<TimeEntriesResponseModel>(relativeUrl);
            return apiResult?.TimeEntries.OrderBy(p => p.Day)
                .ThenBy(p => p.StartTime)
                .ThenBy(p => p.UserId)
                .ToArray();
        }

        /// <summary>
        /// Retrieves the list of user assignments from the CoffeeCup API.
        /// </summary>
        /// <returns>The list of user assignments.</returns>
        public async Task<UserAssignment[]?> GetUserAssignmentsAsync()
        {
            var apiResult = await GetCoffeeCupApiResultAsync<UserAssignmentsResponse>("userAssignments");
            return apiResult?.UserAssignments;
        }

        /// <summary>
        /// Retrieves the list of user employments from the CoffeeCup API.
        /// </summary>
        /// <returns>The list of user employments.</returns>
        public async Task<UserEmployment[]?> GetUserEmploymentsAsync()
        {
            var apiResult = await GetCoffeeCupApiResultAsync<UserEmploymentsResponse>("userEmployments");
            return apiResult?.UserEmployments;
        }

        /// <summary>
        /// Retrieves the list of complete user information from the CoffeeCup API.
        /// </summary>
        /// <param name="onlyValid">If set to <c>true</c> only currently valid users will be loaded.</param>
        /// <returns>The list of user information.</returns>
        public async Task<User[]?> GetUsersAsync(bool onlyValid = true)
        {
            var apiResult = await GetCoffeeCupApiResultAsync<UsersResponse>("users");
            var result = apiResult?.Users.OrderBy(u => u.Lastname)
                .ThenBy(u => u.Firstname);
            return onlyValid
                ? result?.Where(r => r.ShowInPlanner)
                    .ToArray()
                : result?.ToArray();
        }

        /// <summary>
        /// Retrieves the list of simplified user information from the CoffeeCup API.
        /// </summary>
        /// <param name="onlyValid">If set to <c>true</c> only currently valid users will be loaded.</param>
        /// <returns>The list of user information.</returns>
        public async Task<SimpleUser[]?> GetUsersSimpleAsync(bool onlyValid = true)
        {
            var apiResult = await GetCoffeeCupApiResultAsync<UsersResponse>("users");
            var result = apiResult?.Users.Select(u => u.ToSimple())
                .OrderBy(u => u.Lastname)
                .ThenBy(u => u.Firstname);
            return onlyValid
                ? result?.Where(r => r.IsCurrentlyValid)
                    .ToArray()
                : result?.ToArray();
        }

        /// <summary>
        /// Retrieves the currently valid or an updated bearer token from the CoffeeCup API.
        /// </summary>
        /// <returns>The a string of the pattern "Bearer {token}" if the operation succeeded.</returns>
        private async Task<string> GetBearerTokenAsync()
        {
            if (_bearerToken == null
                || (_barerTokenInvalidationTime.HasValue && _barerTokenInvalidationTime.Value < DateTime.Now))
            {
                // Either we've never received a bearer token or it is invalidated now.
                var coffeeCupUser = _apiOptions.Username;
                var coffeeCupPass = _apiOptions.Password;
                if (string.IsNullOrEmpty(coffeeCupUser) || string.IsNullOrEmpty(coffeeCupPass))
                {
                    throw new InvalidOperationException("Invalid CoffeeCup credentials.");
                }
                var dict = new Dictionary<string, string>
                {
                    { "grant_type", "password" },
                    { "username", coffeeCupUser },
                    { "password", coffeeCupPass },
                    { "client_id", _apiOptions.ClientId },
                    { "client_secret", _apiOptions.ClientSecret }
                };
                var body = new FormUrlEncodedContent(dict);
                try
                {
                    var response = await _client.PostAsync("oauth2/token", body);
                    var result = await response.Content.ReadAsStringAsync();
                    var tokenResult = JsonSerializer.Deserialize<AuthorizationResponse>(result);
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
                    var exception = new AuthenticationException("Could retrieve bearer token from CoffeeCup.", ex);
                    _logger.LogError(exception, "CoffeeCup Authentication failed.");
                    throw exception;
                }
            }
            return $"Bearer {_bearerToken}";
        }

        /// <summary>
        /// Retrieves a result from the CoffeeCup API and tries to convert it to <typeparamref name="TResult" />.
        /// </summary>
        /// <typeparam name="TResult">The type the result is expected to be.</typeparam>
        /// <param name="relativeUrl">The relative URL to the CoffeeCup API without the configured base address.</param>
        /// <returns>The result.</returns>
        private async Task<TResult?> GetCoffeeCupApiResultAsync<TResult>(string relativeUrl)
        {
            if (_barerTokenInvalidationTime <= DateTime.Now)
            {
                // we have to refresh the token
                await RefreshBearerTokenAsync();
            }
            var bearer = await GetBearerTokenAsync();
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
                var response = await _client.GetAsync($"{_apiOptions.ApiVersion}/{relativeUrl}");
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
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error during CoffeeCup request.");
                throw;
            }
        }

        /// <summary>
        /// Retrieves the currently valid or an updated bearer token from the CoffeeCup API.
        /// </summary>
        private async Task RefreshBearerTokenAsync()
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
                    { "client_id", _apiOptions.ClientId },
                    { "client_secret", _apiOptions.ClientSecret }
                };
                var body = new FormUrlEncodedContent(dict);
                var response = await _client.PostAsync("oauth2/token", body);
                var result = await response.Content.ReadAsStringAsync();
                var tokenResult = JsonSerializer.Deserialize<AuthorizationResponse>(result);
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
                var exception = new AuthenticationException("Could refresh bearer token from CoffeeCup.", ex);
                _logger.LogError(exception, "CoffeeCup Authentication refresh failed.");
                throw exception;
            }
        }

        #endregion

        #region properties

        /// <summary>
        /// Retrieves the lazy initialized apiOptions for JSON converting.
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