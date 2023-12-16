namespace devdeer.CoffeeCupApiAccess.Logic.Models.Responses
{
    using System;
    using System.Linq;
    using System.Text.Json.Serialization;

    using DataModels;

    /// <summary>
    /// Represents the response of the CoffeeCup API when the user assignments endpoint is called.
    /// </summary>
    public class UserAssignmentsResponse : BaseResponse
    {
        #region properties

        /// <summary>
        /// The list of user assignments.
        /// </summary>
        [JsonPropertyName("userAssignments")]
        public UserAssignment[] UserAssignments { get; set; } = default!;

        #endregion
    }
}