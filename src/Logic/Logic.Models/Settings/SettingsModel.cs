using System;
using System.Linq;

namespace devdeer.CoffeeCupApiAccess.Logic.Models.Settings
{
    using System;
    using System.Linq;

    public class SettingsModel
    {
        #region properties

        public string CoffeeCupApiVersion { get; set; }

        public string ClientId { get; set; }

        public string ClientSecret { get; set; }

        public string CoffeeCupUsername { get; set; }

        public string CoffeeCupPassword { get; set; }

        public string CoffeeCupOrigin { get; set; }

        #endregion
    }
}