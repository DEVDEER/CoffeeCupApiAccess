namespace devdeer.CoffeeCupApiAccess.Logic.Core.TransportModels
{
    using System;
    using System.Linq;

    using Newtonsoft.Json;

    /// <summary>
    /// Contains the information about a single time entry in CoffeeCup.
    /// </summary>
    public class CoffeeCupTimeEntryTransportModel
    {
        #region properties

        [JsonProperty("billedAt")]
        public DateTime? BilledAt { get; set; }

        [JsonProperty("comment")]
        public string Comment { get; set; }

        [JsonProperty("createdAt")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("day")]
        public DateTime Day { get; set; }

        [JsonProperty("duration")]
        public int Duration { get; set; }

        [JsonProperty("durationRoundedOverride")]
        public int? DurationRoundedOverride { get; set; }

        [JsonProperty("endTime")]
        public DateTime? EndTime { get; set; }

        [JsonProperty("estimate")]
        public int? Estimate { get; set; }

        [JsonProperty("hourlyRate")]
        public double HourlyRate { get; set; }

        [JsonProperty("hourlyRateInternal")]
        public double? HourlyRateInternal { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("billable")]
        public bool IsBillable { get; set; }

        [JsonProperty("running")]
        public bool IsRunning { get; set; }

        [JsonProperty("lockedAt")]
        public DateTime? LockedAt { get; set; }

        [JsonProperty("project")]
        public int? ProjectId { get; set; }

        [JsonProperty("projectSettlement")]
        public object ProjectSettlement { get; set; }

        [JsonProperty("sorting")]
        public int Sorting { get; set; }

        [JsonProperty("spentAt")]
        public DateTime SpentAt { get; set; }

        [JsonProperty("startTime")]
        public DateTime? StartTime { get; set; }

        [JsonProperty("task")]
        public int? TaskId { get; set; }

        [JsonProperty("trackingType")]
        public string TrackingType { get; set; }

        [JsonProperty("updatedAt")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty("user")]
        public int UserId { get; set; }

        #endregion
    }
}