namespace devdeer.CoffeeCupApiAccess.Logic.Core.TransportModels
{
    using System;
    using System.Linq;

    using Newtonsoft.Json;

    /// <summary>
    /// Contains the information about a single project in CoffeeCup.
    /// </summary>
    public class CoffeeCupProjectTransportModel
    {
        #region properties

        [JsonProperty("billBy")]
        public int BillBy { get; set; }

        [JsonProperty("budget")]
        public int Budget { get; set; }

        [JsonProperty("budgetBy")]
        public int BudgetBy { get; set; }

        [JsonProperty("budgetHours")]
        public int BudgetHours { get; set; }

        [JsonProperty("client")]
        public int? ClientId { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("color")]
        public int Color { get; set; }

        [JsonProperty("comment")]
        public string Comment { get; set; }

        [JsonProperty("completedAt")]
        public DateTime? CompletedAt { get; set; }

        [JsonProperty("contact")]
        public string Contact { get; set; }

        [JsonProperty("createdAt")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("endDate")]
        public DateTime? EndDate { get; set; }

        [JsonProperty("hourlyRate")]
        public double HourlyRate { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("roundingAmount")]
        public double RoundingAmount { get; set; }

        [JsonProperty("roundingType")]
        public int RoundingType { get; set; }

        [JsonProperty("startDate")]
        public DateTime? StartDate { get; set; }

        [JsonProperty("status")]
        public int Status { get; set; }

        [JsonProperty("updatedAt")]
        public DateTime UpdatedAt { get; set; }

        #endregion
    }
}