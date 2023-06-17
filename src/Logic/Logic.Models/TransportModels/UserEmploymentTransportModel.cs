namespace devdeer.CoffeeCupApiAccess.Logic.Models.TransportModels
{
    using System;
    using System.Linq;

    using Enumerations;

    using System.Text.Json.Serialization;

    /// <summary>
    /// Holds information about the employment of a single user.
    /// </summary>
    public class UserEmploymentTransportModel
    {
        #region properties

        [JsonPropertyName("employerContribution")]
        public double? EmployerContribution { get; set; }

        [JsonPropertyName("employmentType")]
        public EmploymentType EmploymentType { get; set; }

        [JsonPropertyName("hourlyRemuneration")]
        public double? HourlyRemuneration { get; set; }

        [JsonPropertyName("hoursFriday")]
        public int? HoursFriday { get; set; }

        [JsonPropertyName("hoursMonday")]
        public int? HoursMonday { get; set; }

        [JsonPropertyName("hoursSaturday")]
        public int? HoursSaturday { get; set; }

        [JsonPropertyName("hoursSunday")]
        public int? HoursSunday { get; set; }

        [JsonPropertyName("hoursThursday")]
        public int? HoursThursday { get; set; }

        [JsonPropertyName("hoursTuesday")]
        public int? HoursTuesday { get; set; }

        [JsonPropertyName("hoursWednesday")]
        public int? HoursWednesday { get; set; }

        [JsonPropertyName("hoursWeekly")]
        public int? HoursWeekly { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("monthlyRemuneration")]
        public double? MonthlyRemuneration { get; set; }

        [JsonPropertyName("user")]
        public int UserId { get; set; }

        [JsonPropertyName("validFrom")]
        public DateTime? ValidFrom { get; set; }

        [JsonPropertyName("workHoursType")]
        public int? WorkHoursType { get; set; }

        #endregion
    }
}