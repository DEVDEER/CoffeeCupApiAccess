namespace devdeer.CoffeeCupApiAccess.Logic.Models.TransportModels
{
    using System;
    using System.Linq;
    using System.Text.Json.Serialization;

    using Enumerations;

    /// <summary>
    /// Contains the information about a single task assignment in CoffeeCup.
    /// </summary>
    public class TaskAssignmentTransportModel
    {
        #region properties

        [JsonPropertyName("budgetHours")]
        public int? BudgetHours { get; set; }

        [JsonPropertyName("hourlyRate")]
        public double? HourlyRate { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("billable")]
        public bool IsBillable { get; set; }

        [JsonPropertyName("project")]
        public int ProjectId { get; set; }

        [JsonPropertyName("status")]
        public Status Status { get; set; }

        [JsonPropertyName("task")]
        public int TaskId { get; set; }

        #endregion
    }
}