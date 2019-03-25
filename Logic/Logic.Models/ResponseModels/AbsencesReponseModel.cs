namespace devdeer.CoffeeCupApiAccess.Logic.Models.ResponseModels
{
    using System;
    using System.Linq;

    using Newtonsoft.Json;

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
        [JsonProperty("absences")]
        public AbsenceTransportModel[] Absences { get; set; }

        #endregion
    }
}