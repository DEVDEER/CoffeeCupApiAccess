namespace devdeer.CoffeeCupApiAccess.Logic.Models.Responses
{
    using System;
    using System.Linq;
    using System.Text.Json.Serialization;

    using DataModels;

    /// <summary>
    /// Represents the response of the CoffeeCup API when the tasks endpoint is called.
    /// </summary>
    public class CoffeeCupTasksResponse : BaseResponse
    {
        #region properties

        /// <summary>
        /// The list of task information.
        /// </summary>
        [JsonPropertyName("tasks")]
        public CoffeeCupTask[] Tasks { get; set; } = default!;

        #endregion
    }
}