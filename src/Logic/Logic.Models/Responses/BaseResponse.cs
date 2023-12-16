namespace devdeer.CoffeeCupApiAccess.Logic.Models.Responses
{
    using System;
    using System.Linq;
    using System.Text.Json.Serialization;

    using DataModels;

    /// <summary>
    /// Abstract base class for all responses.
    /// </summary>
    public abstract class BaseResponse
    {
        #region properties

        /// <summary>
        /// Contains the meta data which are appended to each response by CoffeeCup.
        /// </summary>
        [JsonPropertyName("meta")]
        public MetaData MetaData { get; set; } = default!;

        #endregion
    }
}