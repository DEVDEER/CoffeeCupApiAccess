namespace devdeer.CoffeeCupApiAccess.Logic.Models.Responses
{
    using System;
    using System.Linq;
    using System.Text.Json.Serialization;

    using DataModels;

    /// <summary>
    /// Represents the response of the CoffeeCup API when the absence-types-endpoint is called.
    /// </summary>
    public class AbsenceTypesResponse : BaseResponse
    {
        #region properties

        /// <summary>
        /// The list of absence types.
        /// </summary>
        [JsonPropertyName("absenceTypes")]
        public AbsenceType[] AbsenceTypes { get; set; } = default!;

        #endregion
    }
}