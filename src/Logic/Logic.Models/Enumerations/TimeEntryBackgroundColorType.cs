namespace devdeer.CoffeeCupApiAccess.Logic.Models.Enumerations
{
    using System;
    using System.Linq;

    /// <summary>
    /// Defines possible values for the time entry background color.
    /// </summary>
    public enum TimeEntryBackgroundColorType
    {
        BasedOnTask = 0,

        BasedOnProject = 1,

        TimeEntry = 2
    }
}