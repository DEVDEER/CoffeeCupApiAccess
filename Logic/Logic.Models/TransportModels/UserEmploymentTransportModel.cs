namespace devdeer.CoffeeCupApiAccess.Logic.Models.TransportModels
{
    using System;
    using System.Linq;

    using Enumerations;

    using Newtonsoft.Json;

    public class UserEmploymentTransportModel
    {
        #region properties

        [JsonProperty("employerContribution")]
        public double? EmployerContribution { get; set; }

        [JsonProperty("employmentType")]
        public EmploymentType EmploymentType { get; set; }

        [JsonProperty("hourlyRemuneration")]
        public double? HourlyRemuneration { get; set; }

        [JsonProperty("hoursFriday")]
        public int? HoursFriday { get; set; }

        [JsonProperty("hoursMonday")]
        public int? HoursMonday { get; set; }

        [JsonProperty("hoursSaturday")]
        public int? HoursSaturday { get; set; }

        [JsonProperty("hoursSunday")]
        public int? HoursSunday { get; set; }

        [JsonProperty("hoursThursday")]
        public int? HoursThursday { get; set; }

        [JsonProperty("hoursTuesday")]
        public int? HoursTuesday { get; set; }

        [JsonProperty("hoursWednesday")]
        public int? HoursWednesday { get; set; }

        [JsonProperty("hoursWeekly")]
        public int? HoursWeekly { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("monthlyRemuneration")]
        public double? MonthlyRemuneration { get; set; }

        [JsonProperty("user")]
        public int User { get; set; }

        [JsonProperty("validFrom")]
        public DateTime? ValidFrom { get; set; }

        [JsonProperty("workHoursType")]
        public int WorkHoursType { get; set; }

        #endregion
    }
}