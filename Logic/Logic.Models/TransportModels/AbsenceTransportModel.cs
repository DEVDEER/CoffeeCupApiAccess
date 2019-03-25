namespace devdeer.CoffeeCupApiAccess.Logic.Models.TransportModels
{
    using System;
    using System.Linq;

    using Newtonsoft.Json;

    /// <summary>
    /// Contains the information about a single absence in CoffeeCup.
    /// </summary>
    public class AbsenceTransportModel
    {
        #region properties

        [JsonProperty("absenceType")]
        public int AbsenceTypeId { get; set; }

        [JsonProperty("comment")]
        public string Comment { get; set; }

        [JsonProperty("countsAsVacation")]
        public bool CountsAsVacation { get; set; }

        [JsonProperty("createdAt")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("endDate")]
        public DateTime? EndDate { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("remunerationActive")]
        public bool IsRemunerationActive { get; set; }

        [JsonProperty("rangeType")]
        public string RangeType { get; set; }

        [JsonProperty("reducesOvertime")]
        public bool ReducesOvertime { get; set; }

        [JsonProperty("startDate")]
        public DateTime StartDate { get; set; }

        [JsonProperty("updatedAt")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty("user")]
        public int UserId { get; set; }

        [JsonProperty("workHoursExpected")]
        public bool WorkHoursExpected { get; set; }

        #endregion
    }
}