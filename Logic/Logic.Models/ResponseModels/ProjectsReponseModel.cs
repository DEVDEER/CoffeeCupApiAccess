namespace devdeer.CoffeeCupApiAccess.Logic.Models.ResponseModels
{
    using System;
    using System.Linq;

    using Newtonsoft.Json;

    using TransportModels;

    /// <summary>
    /// Represents the response of the CoffeeCup API when the projects endpoint is called.
    /// </summary>
    public class ProjectsResponseModel : BaseResponseModel
    {
        #region properties

        /// <summary>
        /// The list of project information.
        /// </summary>
        [JsonProperty("projects")]
        public ProjectTransportModel[] Projects { get; set; }

        #endregion
    }
}