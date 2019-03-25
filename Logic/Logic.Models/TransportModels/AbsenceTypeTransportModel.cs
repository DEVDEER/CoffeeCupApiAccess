namespace devdeer.CoffeeCupApiAccess.Logic.Models.TransportModels
{
    using System;
    using System.Linq;

    using Enumerations;

    using Newtonsoft.Json;

    /// <summary>
    /// Contains the information about a single absence type in CoffeeCup.
    /// </summary>
    public class AbsenceTypeTransportModel
    {
        #region properties

        /// <summary>
        /// Indicates if the absence can be created as a request by an employee.
        /// </summary>
        [JsonProperty("canBeRequested")]
        public bool CanBeRequested { get; set; }

        [JsonProperty("color")]
        public int? Color { get; set; }

        [JsonProperty("createdAt")]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Indicates if absence reduces the vacation budget.
        /// </summary>
        [JsonProperty("defaultCountsAsVacation")]
        public bool DefaultCountsAsVacation { get; set; }

        /// <summary>
        /// Indicates if absence reduces the overtime of an employee.
        /// </summary>
        [JsonProperty("defaultReducesOvertime")]
        public bool DefaultReducesOvertime { get; set; }

        /// <summary>
        /// Indicates if remuneration is active for the absence.
        /// </summary>
        [JsonProperty("defaultRemunerationActive")]
        public bool DefaultRemunerationActive { get; set; }

        /// <summary>
        /// Indicates if the absence expects the employee to work.
        /// </summary>
        [JsonProperty("defaultWorkHoursExpected")]
        public bool DefaultWorkHoursExpected { get; set; }

        /// <summary>
        /// Indicates if absence is visible for other employees.
        /// </summary>
        [JsonProperty("detailsVisibleToOtherUsers")]
        public bool DetailsVisibleToOtherUsers { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty("icon")]
        public int Icon { get; set; }

        /// <summary>
        /// The unique id of the absence type.
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("status")]
        public Status Status { get; set; }

        [JsonProperty("updatedAt")]
        public DateTime UpdatedAt { get; set; }

        #endregion
    }
}