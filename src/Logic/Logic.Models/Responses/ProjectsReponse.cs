namespace devdeer.CoffeeCupApiAccess.Logic.Models.Responses
{
    using System;
    using System.Linq;
    using System.Text.Json.Serialization;

    using DataModels;

    /// <summary>
    /// Represents the response of the CoffeeCup API when the projects endpoint is called.
    /// </summary>
    public class ProjectsResponseModel : BaseResponse
    {
        #region properties

        /// <summary>
        /// The list of project information.
        /// </summary>
        [JsonPropertyName("projects")]
        public Project[] Projects { get; set; } = default!;

        #endregion
    }
}