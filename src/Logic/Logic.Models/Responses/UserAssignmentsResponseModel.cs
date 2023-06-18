namespace devdeer.CoffeeCupApiAccess.Logic.Models.Responses
{
    using System;
    using System.Linq;

    using System.Text.Json.Serialization;

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
        [JsonPropertyName("userAssignments")]
        public UserAssignmentTransportModel[] UserAssignments { get; set; }

        #endregion
    }
}