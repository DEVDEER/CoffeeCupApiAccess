namespace devdeer.CoffeeCupApiAccess.Logic.Models.Responses
{
    using System;
    using System.Linq;
    using System.Text.Json.Serialization;

    using DataModels;

    /// <summary>
    /// Represents the response of the CoffeeCup API when the colors endpoint is called.
    /// </summary>
    public class ColorsResponse : BaseResponse
    {
        #region properties

        /// <summary>
        /// The list of colors.
        /// </summary>
        [JsonPropertyName("colors")]
        public Color[] Colors { get; set; } = default!;

        #endregion
    }
}