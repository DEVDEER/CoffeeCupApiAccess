namespace devdeer.CoffeeCupApiAccess.Logic.Models.Responses
{
    using System;
    using System.Linq;
    using System.Text.Json.Serialization;

    using DataModels;

    /// <summary>
    /// Represents the response of the CoffeeCup API when the task assignments endpoint is called.
    /// </summary>
    public class CoffeeCupTaskAssignmentsResponse : BaseResponse
    {
        #region properties

        /// <summary>
        /// The list of task assignment information.
        /// </summary>
        [JsonPropertyName("taskAssignments")]
        public CoffeeCupTaskAssignment[] TaskAssignments { get; set; } = default!;

        #endregion
    }
}