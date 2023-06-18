namespace devdeer.CoffeeCupApiAccess.Logic.Models.Responses
{
    using System;
    using System.Linq;

    using System.Text.Json.Serialization;

    using TransportModels;

    /// <summary>
    /// Represents the response of the CoffeeCup API when the colors endpoint is called.
    /// </summary>
    public class ColorsResponseModel : BaseResponseModel
    {
        #region properties

        /// <summary>
        /// The list of colors.
        /// </summary>
        [JsonPropertyName("colors")]
        public ColorTransportModel[] Colors { get; set; }

        #endregion
    }
}