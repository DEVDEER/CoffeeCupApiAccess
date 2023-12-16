namespace devdeer.CoffeeCupApiAccess.Logic.Models.DataModels
{
    using System;
    using System.Linq;
    using System.Text.Json.Serialization;

    /// <summary>
    /// Contains the information about a single absence in CoffeeCup.
    /// </summary>
    public class Absence
    {
        #region properties

        [JsonPropertyName("absenceType")]
        public int AbsenceTypeId { get; set; }

        [JsonPropertyName("comment")]
        public string Comment { get; set; } = default!;

        [JsonPropertyName("countsAsVacation")]
        public bool CountsAsVacation { get; set; }

        [JsonPropertyName("createdAt")]
        public DateTime CreatedAt { get; set; } = default!;

        [JsonPropertyName("endDate")]
        public DateTime? EndDate { get; set; } = default!;

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("remunerationActive")]
        public bool IsRemunerationActive { get; set; }

        [JsonPropertyName("rangeType")]
        public string RangeType { get; set; } = default!;

        [JsonPropertyName("reducesOvertime")]
        public bool ReducesOvertime { get; set; }

        [JsonPropertyName("startDate")]
        public DateTime StartDate { get; set; } = default!;

        [JsonPropertyName("updatedAt")]
        public DateTime UpdatedAt { get; set; } = default!;

        [JsonPropertyName("user")]
        public int UserId { get; set; }

        [JsonPropertyName("workHoursExpected")]
        public bool WorkHoursExpected { get; set; }

        #endregion
    }
}