namespace devdeer.CoffeeCupApiAccess.Logic.Models.Filters
{
    using System;
    using System.Linq;

    /// <summary>
    /// Represents the options to filter time entry requests.
    /// </summary>
    public class VacationBudgetsFilter
    {
        #region properties

        /// <summary>
        /// If set to a value the request will be filtered by this user.
        /// </summary>
        public int? UserId { get; set; }

        /// <summary>
        /// Is set to a value the budgets valid on that date will be requested.
        /// </summary>
        public DateTime? Date { get; set; }

        #endregion
    }
}