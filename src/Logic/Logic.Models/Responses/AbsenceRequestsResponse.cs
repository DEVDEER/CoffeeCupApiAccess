namespace devdeer.CoffeeCupApiAccess.Logic.Models.Responses
{
    using System;
    using System.Linq;
    using System.Text.Json.Serialization;

    using DataModels;

    /// <summary>
    /// Represents the response of the CoffeeCup API when the absence-requests-endpoint is called.
    /// </summary>
    public class AbsenceRequestsResponse : BaseResponse
    {
        #region properties

        /// <summary>
        /// The list of absence requests.
        /// </summary>
        [JsonPropertyName("absenceRequests")]
        public AbsenceRequest[] AbsenceRequests { get; set; } = default!;

        #endregion
    }
}