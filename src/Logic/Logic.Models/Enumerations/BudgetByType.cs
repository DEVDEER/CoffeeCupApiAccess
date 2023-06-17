namespace devdeer.CoffeeCupApiAccess.Logic.Models.Enumerations
{
    using System;
    using System.Linq;

    /// <summary>
    /// Defines possible values for budget-by.
    /// </summary>
    public enum BudgetByType
    {
        NoBudget = 0,

        BasedOnBudgetHours = 1,

        BasedOnBudget = 2,

        PerUserAssignment = 3,

        PerTaskAssignment = 4
    }
}