namespace devdeer.CoffeeCupApiAccess.Logic.Models.Requests
{
    using System;
    using System.Linq;

    /// <summary>
    /// Represents the options to filter time entry requests.
    /// </summary>
    public class TimeEntriesRequest
    {
        #region properties

        /// <summary>
        /// The date from which the time entries should be returned.
        /// </summary>
        public DateTime? From { get; set; }

        /// <summary>
        /// The date up to which the time entries should be returned.
        /// </summary>
        public DateTime? To { get; set; }

        /// <summary>
        /// Optional ids of projects for which to filter.
        /// </summary>
        public int[]? ProjectFilterIds { get; set; }

        /// <summary>
        /// Optional ids of users for which to filter.
        /// </summary>
        public int[]? UserIds { get; set; }

        #endregion
    }
}