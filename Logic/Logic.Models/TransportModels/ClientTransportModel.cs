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

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("comment")]
        public string Comment { get; set; }

        [JsonProperty("createdAt")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("easybillId")]
        public string EasyBillId { get; set; }

        [JsonProperty("hourlyRate")]
        public double HourlyRate { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("idHashed")]
        public string IdHashed { get; set; }

        [JsonProperty("imageDirectoryURL")]
        public string ImageDirectoryUrl { get; set; }

        [JsonProperty("imageFileToken")]
        public string ImageFileToken { get; set; }

        [JsonProperty("imageType")]
        public ImageType ImageType { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("status")]
        public Status Status { get; set; }

        [JsonProperty("updatedAt")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty("website")]
        public string Website { get; set; }

        #endregion
    }
}