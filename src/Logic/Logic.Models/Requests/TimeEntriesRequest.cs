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
        /// A flag indicating if relations should be resolved.
        /// </summary>
        public bool ResolveRelations { get; set; }

        /// <summary>
        /// Optional id of a client for which to filter.
        /// </summary>
        public int? ClientFilterId { get; set; }

        /// <summary>
        /// Optional id of a project for which to filter.
        /// </summary>
        public int? ProjectFilterId { get; set; }

        #endregion
    }
}