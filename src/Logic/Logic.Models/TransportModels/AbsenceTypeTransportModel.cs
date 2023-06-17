namespace devdeer.CoffeeCupApiAccess.Logic.Models.TransportModels
{
    using System;
    using System.Linq;

    using Enumerations;

    using System.Text.Json.Serialization;

    /// <summary>
    /// Contains the information about a single absence type in CoffeeCup.
    /// </summary>
    public class AbsenceTypeTransportModel
    {
        #region properties

        /// <summary>
        /// Indicates if the absence can be created as a request by an employee.
        /// </summary>
        [JsonPropertyName("canBeRequested")]
        public bool CanBeRequested { get; set; }

        [JsonPropertyName("color")]
        public int? Color { get; set; }

        [JsonPropertyName("createdAt")]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Indicates if absence reduces the vacation budget.
        /// </summary>
        [JsonPropertyName("defaultCountsAsVacation")]
        public bool DefaultCountsAsVacation { get; set; }

        /// <summary>
        /// Indicates if absence reduces the overtime of an employee.
        /// </summary>
        [JsonPropertyName("defaultReducesOvertime")]
        public bool DefaultReducesOvertime { get; set; }

        /// <summary>
        /// Indicates if remuneration is active for the absence.
        /// </summary>
        [JsonPropertyName("defaultRemunerationActive")]
        public bool DefaultRemunerationActive { get; set; }

        /// <summary>
        /// Indicates if the absence expects the employee to work.
        /// </summary>
        [JsonPropertyName("defaultWorkHoursExpected")]
        public bool DefaultWorkHoursExpected { get; set; }

        /// <summary>
        /// Indicates if absence is visible for other employees.
        /// </summary>
        [JsonPropertyName("detailsVisibleToOtherUsers")]
        public bool DetailsVisibleToOtherUsers { get; set; }

        /// <summary>
        /// </summary>
        [JsonPropertyName("icon")]
        public int Icon { get; set; }

        /// <summary>
        /// The unique id of the absence type.
        /// </summary>
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("label")]
        public string Label { get; set; }

        [JsonPropertyName("status")]
        public Status Status { get; set; }

        [JsonPropertyName("updatedAt")]
        public DateTime UpdatedAt { get; set; }

        #endregion
    }
}