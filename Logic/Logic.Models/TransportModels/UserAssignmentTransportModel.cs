namespace devdeer.CoffeeCupApiAccess.Logic.Models.TransportModels
{
    using System;
    using System.Linq;

    using Enumerations;

    using Newtonsoft.Json;

    /// <summary>
    /// Contains the information about a single user assignment in CoffeeCup.
    /// </summary>
    public class UserAssignmentTransportModel
    {
        #region properties

        [JsonProperty("budgetHours")]
        public int? BudgetHours { get; set; }

        [JsonProperty("hourlyRate")]
        public double HourlyRate { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("isProjectManager")]
        public bool IsProjectManager { get; set; }

        [JsonProperty("project")]
        public int ProjectId { get; set; }

        [JsonProperty("status")]
        public Status Status { get; set; }

        [JsonProperty("user")]
        public int UserId { get; set; }

        #endregion
    }
}