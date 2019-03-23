namespace devdeer.CoffeeCupApiAccess.Logic.Models.TransportModels
{
    using System;
    using System.Linq;

    using Enumerations;

    using Newtonsoft.Json;

    /// <summary>
    /// Contains the information about a single client in CoffeeCup.
    /// </summary>
    public class ClientTransportModel
    {
        #region properties

        /// <summary>
        /// The code of the client.
        /// </summary>
        [JsonProperty("code")]
        public string Code { get; set; }

        /// <summary>
        /// A comment.
        /// </summary>
        [JsonProperty("comment")]
        public string Comment { get; set; }

        /// <summary>
        /// The timestamp the client was created.
        /// </summary>
        [JsonProperty("createdAt")]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// The associated id in Easy Bill for this client.
        /// </summary>
        [JsonProperty("easybillId")]
        public string EasyBillId { get; set; }

        /// <summary>
        /// The hourly rate which will be billed on projects normally.
        /// </summary>
        [JsonProperty("hourlyRate")]
        public double HourlyRate { get; set; }

        /// <summary>
        /// The unique id of the client.
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// The hashed value of the <see cref="Id" />.
        /// </summary>
        [JsonProperty("idHashed")]
        public string IdHashed { get; set; }

        /// <summary>
        /// The URL of the image directory.
        /// </summary>
        [JsonProperty("imageDirectoryURL")]
        public string ImageDirectoryUrl { get; set; }

        /// <summary>
        /// The token for retrieving the image depending on the <see cref="ImageType" />.
        /// </summary>
        [JsonProperty("imageFileToken")]
        public string ImageFileToken { get; set; }

        /// <summary>
        /// The type resp. source of the image.
        /// </summary>
        [JsonProperty("imageType")]
        public ImageType ImageType { get; set; }

        /// <summary>
        /// The client name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// The current status of the client.
        /// </summary>
        [JsonProperty("status")]
        public Status Status { get; set; }

        /// <summary>
        /// The timestamp of the last update operation.
        /// </summary>
        [JsonProperty("updatedAt")]
        public DateTime UpdatedAt { get; set; }

        /// <summary>
        /// The website URL of the client.
        /// </summary>
        [JsonProperty("website")]
        public string Website { get; set; }

        #endregion
    }
}