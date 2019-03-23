namespace devdeer.CoffeeCupApiAccess.Logic.Models.TransportModels
{
    using System;
    using System.Linq;

    using Newtonsoft.Json;

    public class MetaDataTransportModel
    {
        #region properties

        [JsonProperty("criteria")]
        public object Criteria { get; set; }

        [JsonProperty("limit")]
        public int Limit { get; set; }

        [JsonProperty("skip")]
        public int Skip { get; set; }

        [JsonProperty("total")]
        public int Total { get; set; }

        #endregion
    }
}