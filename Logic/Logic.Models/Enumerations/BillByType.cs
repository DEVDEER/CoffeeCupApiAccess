namespace devdeer.CoffeeCupApiAccess.Logic.Models.Enumerations
{
    using System;
    using System.Linq;

    /// <summary>
    /// Defines possible values for bill-by.
    /// </summary>
    public enum BillByType
    {
        NoHourlyRate = 0,

        ByClientHourlyRate = 1,

        ByProjectHourlyRate = 2,

        PerUserAssignedHourlyRate = 3,

        PerTaskAssignedHourlyRate = 4
    }
}