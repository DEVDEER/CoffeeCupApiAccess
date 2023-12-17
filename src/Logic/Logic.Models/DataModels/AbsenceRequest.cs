namespace devdeer.CoffeeCupApiAccess.Logic.Models.DataModels
{
    using System;
    using System.Linq;
    using System.Text.Json.Serialization;

    /// <summary>
    /// Contains the information about a single absence request in CoffeeCup.
    /// </summary>
    public class AbsenceRequest
    {
        #region properties

        [JsonPropertyName("absenceType")]
        public int AbsenceTypeId { get; set; }

        [JsonPropertyName("senderComment")]
        public string SenderComment { get; set; } = default!;

        [JsonPropertyName("receiverComment")]
        public string? ReceiverComment { get; set; } = default!;

        [JsonPropertyName("createdAt")]
        public DateTime CreatedAt { get; set; } = default!;

        [JsonPropertyName("endDate")]
        public DateTime? EndDate { get; set; } = default!;

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("rangeType")]
        public string RangeType { get; set; } = default!;

        [JsonPropertyName("startDate")]
        public DateTime StartDate { get; set; } = default!;

        [JsonPropertyName("updatedAt")]
        public DateTime UpdatedAt { get; set; } = default!;

        [JsonPropertyName("state")]
        public string State { get; set; } = default;

        [JsonPropertyName("sender")]
        public int SenderId { get; set; }

        [JsonPropertyName("receiver")]
        public int ReceiverId { get; set; }

        #endregion
    }
}