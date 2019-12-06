namespace devdeer.CoffeeCupApiAccess.Logic.Models.TransportModels
{
    using System;
    using System.Linq;

    using Enumerations;

    using System.Text.Json.Serialization;

    /// <summary>
    /// Contains the information about a single project in CoffeeCup.
    /// </summary>
    public class ProjectTransportModel
    {
        #region properties

        /// <summary>
        /// The billing type.
        /// </summary>
        [JsonPropertyName("billBy")]
        public BillByType BillBy { get; set; }

        /// <summary>
        /// The overall project budget.
        /// </summary>
        [JsonPropertyName("budget")]
        public double Budget { get; set; }

        /// <summary>
        /// The budget-type.
        /// </summary>
        [JsonPropertyName("budgetBy")]
        public BudgetByType BudgetBy { get; set; }

        /// <summary>
        /// The amount of hours available for this project.
        /// </summary>
        [JsonPropertyName("budgetHours")]
        public int BudgetHours { get; set; }

        /// <summary>
        /// The id of the client.
        /// </summary>
        [JsonPropertyName("client")]
        public int? ClientId { get; set; }

        /// <summary>
        /// The project code.
        /// </summary>
        [JsonPropertyName("code")]
        public string Code { get; set; }

        /// <summary>
        /// The id of the color.
        /// </summary>
        [JsonPropertyName("color")]
        public int ColorId { get; set; }

        /// <summary>
        /// The comment for the project.
        /// </summary>
        [JsonPropertyName("comment")]
        public string Comment { get; set; }

        /// <summary>
        /// The date the project was actually finished.
        /// </summary>
        [JsonPropertyName("completedAt")]
        public DateTime? CompletedAt { get; set; }

        /// <summary>
        /// TODO
        /// </summary>
        [JsonPropertyName("contact")]
        public int? Contact { get; set; }

        /// <summary>
        /// The date when the project was created.
        /// </summary>
        [JsonPropertyName("createdAt")]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// The planned end-date for the project.
        /// </summary>
        [JsonPropertyName("endDate")]
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// The hourly rate for this project.
        /// </summary>
        [JsonPropertyName("hourlyRate")]
        public double HourlyRate { get; set; }

        /// <summary>
        /// The unique id of this project.
        /// </summary>
        [JsonPropertyName("id")]
        public int Id { get; set; }

        /// <summary>
        /// The project name.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("roundingAmount")]
        public double RoundingAmount { get; set; }

        [JsonPropertyName("roundingType")]
        public int RoundingType { get; set; }

        [JsonPropertyName("startDate")]
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// The current status of the project.
        /// </summary>
        [JsonPropertyName("status")]
        public Status Status { get; set; }

        /// <summary>
        /// The timestamp when the project was updated last.
        /// </summary>
        [JsonPropertyName("updatedAt")]
        public DateTime UpdatedAt { get; set; }

        #endregion
    }
}