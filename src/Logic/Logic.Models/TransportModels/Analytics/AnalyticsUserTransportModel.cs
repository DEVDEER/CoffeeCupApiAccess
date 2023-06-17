using System;
using System.Collections.Generic;
using System.Text;

namespace devdeer.CoffeeCupApiAccess.Logic.Models.TransportModels.Analytics
{
    using System.Text.Json.Serialization;

    public class AnalyticsUserTransportModel
    {
        #region properties

        [JsonPropertyName("amount")]
        public AnalyticsAmountTransportModel Amount { get; set; }

        [JsonPropertyName("hours")]
        public AnalyticsHoursTransportModel Hours { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        #endregion
    }
}
