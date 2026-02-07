namespace devdeer.CoffeeCupApiAccess.Logic.Models.Enumerations
{
    using System;
    using System.Linq;

    /// <summary>
    /// Defines valid values for project states.
    /// </summary>
    public enum State
    {
        Pending = 0,
        Planning = 1,
        InProgress = 2,
        Completed = 3
    }
}