namespace devdeer.CoffeeCupApiAccess.Logic.Models.ResponseModels
{
    using System;
    using System.Linq;

    using Newtonsoft.Json;

    using TransportModels;

    /// <summary>
    /// Represents the response of the CoffeeCup API when the tasks endpoint is called.
    /// </summary>
    public class TasksResponseModel
    {
        #region properties

        /// <summary>
        /// The list of user information.
        /// </summary>
        [JsonProperty("tasks")]
        public TaskTransportModel[] Tasks { get; set; }

        #endregion
    }
}