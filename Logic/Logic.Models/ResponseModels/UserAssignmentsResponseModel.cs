namespace devdeer.CoffeeCupApiAccess.Logic.Models.ResponseModels
{
    using System;
    using System.Linq;

    using Newtonsoft.Json;

    using TransportModels;

    /// <summary>
    /// Represents the response of the CoffeeCup API when the user assignments endpoint is called.
    /// </summary>
    public class UserAssignmentsResponseModel : BaseResponseModel
    {
        #region properties

        /// <summary>
        /// The list of user assignments.
        /// </summary>
        [JsonProperty("userAssignments")]
        public UserAssignmentTransportModel[] UserAssignments { get; set; }

        #endregion
    }
}