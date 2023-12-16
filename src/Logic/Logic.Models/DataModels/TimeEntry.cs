namespace devdeer.CoffeeCupApiAccess.Logic.Models.DataModels
{
    using System;
    using System.Linq;
    using System.Text.Json.Serialization;

    /// <summary>
    /// Contains the information about a single time entry in CoffeeCup.
    /// </summary>
    public class TimeEntry
    {
        #region properties

        [JsonPropertyName("billedAt")]
        public DateTime? BilledAt { get; set; }

        [JsonPropertyName("comment")]
        public string Comment { get; set; } = default!;

        [JsonPropertyName("createdAt")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("day")]
        public DateTime Day { get; set; }

        [JsonPropertyName("duration")]
        public int Duration { get; set; }

        [JsonPropertyName("durationRoundedOverride")]
        public int? DurationRoundedOverride { get; set; }

        [JsonPropertyName("endTime")]
        public DateTime? EndTime { get; set; }

        [JsonPropertyName("estimate")]
        public int? Estimate { get; set; }

        [JsonPropertyName("hourlyRate")]
        public double HourlyRate { get; set; }

        [JsonPropertyName("hourlyRateInternal")]
        public double? HourlyRateInternal { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("billable")]
        public bool IsBillable { get; set; }

        [JsonPropertyName("running")]
        public bool IsRunning { get; set; }

        [JsonPropertyName("lockedAt")]
        public DateTime? LockedAt { get; set; }

        [JsonPropertyName("project")]
        public int? ProjectId { get; set; }

        [JsonPropertyName("projectSettlement")]
        public object ProjectSettlement { get; set; } = default!;

        [JsonPropertyName("sorting")]
        public int? Sorting { get; set; }

        [JsonPropertyName("spentAt")]
        public DateTime SpentAt { get; set; }

        [JsonPropertyName("startTime")]
        public DateTime? StartTime { get; set; }

        [JsonPropertyName("task")]
        public int? TaskId { get; set; }

        [JsonPropertyName("trackingType")]
        public string TrackingType { get; set; } = default!;

        [JsonPropertyName("updatedAt")]
        public DateTime UpdatedAt { get; set; }

        [JsonPropertyName("user")]
        public int UserId { get; set; }

        #endregion
    }
}