namespace devdeer.CoffeeCupApiAccess.Logic.Models.DataModels
{
    using System;
    using System.Linq;
    using System.Text.Json.Serialization;

    using Enumerations;

    /// <summary>
    /// Holds information about the vacation budget for a single user from a given start date on.
    /// </summary>
    public class VacationBudget
    {
        #region properties

        [JsonPropertyName("createdAt")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("updatedAt")]
        public DateTime UpdatedAt { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("user")]
        public int UserId { get; set; }

        [JsonPropertyName("vacationType")]
        public int VacationTypeId { get; set; }

        [JsonPropertyName("quantity")]
        public int Quantity { get; set; }

        [JsonPropertyName("employmentType")]
        public EmploymentType EmploymentType { get; set; }

        [JsonPropertyName("startDate")]
        public DateTime Start { get; set; }

        [JsonPropertyName("comment")]
        public string? Comment { get; set; }

        #endregion
    }
}