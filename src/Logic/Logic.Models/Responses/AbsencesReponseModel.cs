namespace devdeer.CoffeeCupApiAccess.Logic.Models.Responses
{
    using System;
    using System.Linq;
    using System.Text.Json.Serialization;

    using TransportModels;
    
    /// <summary>
    /// Represents the response of the CoffeeCup API when the absences-endpoint is called.
    /// </summary>
    public class AbsencesReponseModel : BaseResponseModel
    {
        #region properties

        /// <summary>
        /// The list of absences.
        /// </summary>
        [JsonPropertyName("absences")]
        public AbsenceTransportModel[] Absences { get; set; }

        #endregion
    }
}