namespace devdeer.CoffeeCupApiAccess.Logic.Models.Enumerations
{
    using System;
    using System.Linq;

    /// <summary>
    /// Defines valid values for password status.
    /// </summary>
    public enum PasswordStatus
    {
        NeedsToBeSet = 0,

        NeedsToBeReset = 1,

        IsValid = 2
    }
}