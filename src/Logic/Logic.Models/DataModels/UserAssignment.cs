namespace devdeer.CoffeeCupApiAccess.Logic.Models.DataModels
{
    using System;
    using System.Linq;
    using System.Text.Json.Serialization;

    using Enumerations;

    /// <summary>
    /// Contains the information about a single user assignment in CoffeeCup.
    /// </summary>
    public class UserAssignment
    {
        #region properties

        [JsonPropertyName("budgetHours")]
        public int? BudgetHours { get; set; }

        [JsonPropertyName("hourlyRate")]
        public double? HourlyRate { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("isProjectManager")]
        public bool IsProjectManager { get; set; }

        [JsonPropertyName("project")]
        public int ProjectId { get; set; }

        [JsonPropertyName("status")]
        public Status Status { get; set; }

        [JsonPropertyName("user")]
        public int UserId { get; set; }

        #endregion
    }
}