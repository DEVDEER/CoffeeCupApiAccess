namespace devdeer.CoffeeCupApiAccess.Tests.Logic.Core
{
    using System;
    using System.Linq;

    /// <summary>
    /// Contains constants used in tests.
    /// </summary>
    public static class Constants
    {
        #region constants

        /// <summary>
        /// The id of the expense category used in tests.
        /// </summary>
        public const int ExpenseCategoryId = 10;

        /// <summary>
        /// The id of the project used in tests for retrieving related expenses.
        /// </summary>
        public const int ExpensesProjectId = 3402;

        /// <summary>
        /// The id of the project used in tests for retrieving related time entries.
        /// </summary>
        public const int TimeEntriesProjectId = 15639;

        /// <summary>
        /// The id of the user used in tests for retrieving related vacation budgets.
        /// </summary>
        public const int VacationBudgetUserId = 14766;

        /// <summary>
        /// The current year and the beginning of the year.
        /// </summary>
        public static readonly int CurrentYear = DateTime.Now.Year;

        /// <summary>
        /// The first day of the current year.
        /// </summary>
        public static readonly DateTime BeginningOfYear = new(CurrentYear, 1, 1);

        /// <summary>
        /// The date used for specifying minimal date of a time range.
        /// </summary>
        public static readonly DateTime FromDate = new(2023, 6, 1);

        /// <summary>
        /// The date used for specifying maximal date of a time range.
        /// </summary>
        public static readonly DateTime ToDate = new(2023, 6, 30);

        #endregion
    }
}