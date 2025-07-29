namespace devdeer.CoffeeCupApiAccess.Logic.Models.Responses
{
    using System;
    using System.Linq;
    using System.Text.Json.Serialization;

    using DataModels;

    /// <summary>
    /// Represents the response of the CoffeeCup API when the absences-endpoint is called.
    /// </summary>
    public class AbsencesReponse : BaseResponse
    {
        #region properties

        /// <summary>
        /// The list of absences.
        /// </summary>
        [JsonPropertyName("absences")]
        public Absence[] Absences { get; set; } = default!;

        #endregion
    }
}