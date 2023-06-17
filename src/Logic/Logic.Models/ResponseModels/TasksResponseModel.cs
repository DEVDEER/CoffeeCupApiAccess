namespace devdeer.CoffeeCupApiAccess.Logic.Models.ResponseModels
{
    using System;
    using System.Linq;

    using System.Text.Json.Serialization;

    using TransportModels;

    /// <summary>
    /// Represents the response of the CoffeeCup API when the tasks endpoint is called.
    /// </summary>
    public class TasksResponseModel : BaseResponseModel
    {
        #region properties

        /// <summary>
        /// The list of task information.
        /// </summary>
        [JsonPropertyName("tasks")]
        public TaskTransportModel[] Tasks { get; set; }

        #endregion
    }
}