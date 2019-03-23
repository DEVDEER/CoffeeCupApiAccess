namespace devdeer.CoffeeCupApiAccess.Logic.Models.TransportModels
{
    using System;
    using System.Linq;

    using Enumerations;

    using Newtonsoft.Json;

    /// <summary>
    /// Contains the information about a single project in CoffeeCup.
    /// </summary>
    public class ProjectTransportModel
    {
        #region properties

        /// <summary>
        /// The billing type.
        /// </summary>
        [JsonProperty("billBy")]
        public BillByType BillBy { get; set; }

        /// <summary>
        /// The overall project budget.
        /// </summary>
        [JsonProperty("budget")]
        public double Budget { get; set; }

        /// <summary>
        /// The budget-type.
        /// </summary>
        [JsonProperty("budgetBy")]
        public BudgetByType BudgetBy { get; set; }

        /// <summary>
        /// The amount of hours available for this project.
        /// </summary>
        [JsonProperty("budgetHours")]
        public int BudgetHours { get; set; }

        /// <summary>
        /// The id of the client.
        /// </summary>
        [JsonProperty("client")]
        public int? ClientId { get; set; }

        /// <summary>
        /// The project code.
        /// </summary>
        [JsonProperty("code")]
        public string Code { get; set; }

        /// <summary>
        /// The id of the color.
        /// </summary>
        [JsonProperty("color")]
        public int ColorId { get; set; }

        /// <summary>
        /// The comment for the project.
        /// </summary>
        [JsonProperty("comment")]
        public string Comment { get; set; }

        /// <summary>
        /// The date the project was actually finished.
        /// </summary>
        [JsonProperty("completedAt")]
        public DateTime? CompletedAt { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("contact")]
        public string Contact { get; set; }

        /// <summary>
        /// The date when the project was created.
        /// </summary>
        [JsonProperty("createdAt")]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// The planned end-date for the project.
        /// </summary>
        [JsonProperty("endDate")]
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// The hourly rate for this project.
        /// </summary>
        [JsonProperty("hourlyRate")]
        public double HourlyRate { get; set; }

        /// <summary>
        /// The unique id of this project.
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// The project name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("roundingAmount")]
        public double RoundingAmount { get; set; }

        [JsonProperty("roundingType")]
        public int RoundingType { get; set; }

        [JsonProperty("startDate")]
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// The current status of the project.
        /// </summary>
        [JsonProperty("status")]
        public Status Status { get; set; }

        /// <summary>
        /// The timestamp when the project was updated last.
        /// </summary>
        [JsonProperty("updatedAt")]
        public DateTime UpdatedAt { get; set; }

        #endregion
    }
}