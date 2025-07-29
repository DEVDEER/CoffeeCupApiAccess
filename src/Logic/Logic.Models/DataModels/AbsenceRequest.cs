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
        public string SenderComment { get; set; } = null!;

        [JsonPropertyName("receiverComment")]
        public string? ReceiverComment { get; set; } = null!;

        [JsonPropertyName("createdAt")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("endDate")]
        public DateTime? EndDate { get; set; } = null!;

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("rangeType")]
        public string RangeType { get; set; } = null!;

        [JsonPropertyName("startDate")]
        public DateTime StartDate { get; set; }

        [JsonPropertyName("updatedAt")]
        public DateTime UpdatedAt { get; set; }

        [JsonPropertyName("state")]
        public string State { get; set; } = null!;

        [JsonPropertyName("sender")]
        public int SenderId { get; set; }

        [JsonPropertyName("receiver")]
        public int ReceiverId { get; set; }

        #endregion
    }
}