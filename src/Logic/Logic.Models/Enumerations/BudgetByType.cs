namespace devdeer.CoffeeCupApiAccess.Logic.Models.Enumerations
{
    using System;
    using System.Linq;

    /// <summary>
    /// Defines possible values for budget-by.
    /// </summary>
    public enum BudgetByType
    {
        /// <summary>
        /// No budget defined.
        /// </summary>
        NoBudget = 0,

        /// <summary>
        /// Budget is calculated as hours.
        /// </summary>
        BasedOnBudgetHours = 1,

        /// <summary>
        /// Default budget.
        /// </summary>
        BasedOnBudget = 2,

        /// <summary>
        /// Budget is defined per user.
        /// </summary>
        PerUserAssignment = 3,

        /// <summary>
        /// Budget is defined by task.
        /// </summary>
        PerTaskAssignment = 4
    }
}