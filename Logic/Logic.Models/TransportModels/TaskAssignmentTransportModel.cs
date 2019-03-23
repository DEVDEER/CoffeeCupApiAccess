namespace devdeer.CoffeeCupApiAccess.Logic.Models.TransportModels
{
    using System;
    using System.Linq;

    using Enumerations;

    using Newtonsoft.Json;

    public class TaskAssignmentTransportModel
    {
        #region properties

        [JsonProperty("budgetHours")]
        public int BudgetHours { get; set; }

        [JsonProperty("hourlyRate")]
        public double HourlyRate { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("billable")]
        public bool IsBillable { get; set; }

        [JsonProperty("project")]
        public int ProjectId { get; set; }

        [JsonProperty("status")]
        public Status Status { get; set; }

        [JsonProperty("task")]
        public int TaskId { get; set; }

        #endregion
    }
}