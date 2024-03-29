﻿namespace devdeer.CoffeeCupApiAccess.Logic.Models.Responses
{
    using System;
    using System.Linq;
    using System.Text.Json.Serialization;

    using DataModels;

    /// <summary>
    /// Represents the response of the CoffeeCup API when the clients endpoint is called.
    /// </summary>
    public class ClientsResponseModel : BaseResponse
    {
        #region properties

        /// <summary>
        /// The list of client information.
        /// </summary>
        [JsonPropertyName("clients")]
        public Client[] Clients { get; set; } = default!;

        #endregion
    }
}