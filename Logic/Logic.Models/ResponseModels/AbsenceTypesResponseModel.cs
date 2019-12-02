namespace devdeer.CoffeeCupApiAccess.Logic.Models.ResponseModels
{
    using System;
    using System.Linq;

    using System.Text.Json.Serialization;

    using TransportModels;

    /// <summary>
    /// Represents the response of the CoffeeCup API when the absence-types-endpoint is called.
    /// </summary>
    public class AbsenceTypesResponseModel : BaseResponseModel
    {
        #region properties

        /// <summary>
        /// The list of absence types.
        /// </summary>
        [JsonPropertyName("absenceTypes")]
        public AbsenceTypeTransportModel[] AbsenceTypes { get; set; }

        #endregion
    }
}