namespace devdeer.CoffeeCupApiAccess.Logic.Models.ResponseModels
{
    using System;
    using System.Linq;

    using Newtonsoft.Json;

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
        [JsonProperty("taskAssignments")]
        public TaskAssignmentTransportModel[] TaskAssignments { get; set; }

        #endregion
    }
}