namespace devdeer.CoffeeCupApiAccess.Logic.Models.Responses
{
    using System;
    using System.Linq;
    using System.Text.Json.Serialization;

    using TransportModels;

    /// <summary>
    /// Represents the response of the CoffeeCup API when the task assignments endpoint is called.
    /// </summary>
    public class TaskAssignmentsResponseModel : BaseResponseModel
    {
        #region properties

        /// <summary>
        /// The list of task assignment information.
        /// </summary>
        [JsonPropertyName("taskAssignments")]
        public TaskAssignmentTransportModel[] TaskAssignments { get; set; }

        #endregion
    }
}