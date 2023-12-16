namespace devdeer.CoffeeCupApiAccess.Logic.Models.Enumerations
{
    using System;
    using System.Linq;

    /// <summary>
    /// Defines possible values for bill-by.
    /// </summary>
    public enum BillByType
    {
        /// <summary>
        /// No hourly rate present.
        /// </summary>
        NoHourlyRate = 0,

        /// <summary>
        /// Use the hourly rate of the client.
        /// </summary>
        ByClientHourlyRate = 1,

        /// <summary>
        /// Use the hourly rate of the project.
        /// </summary>
        ByProjectHourlyRate = 2,

        /// <summary>
        /// Use the hourly rate assigned to the user.
        /// </summary>
        PerUserAssignedHourlyRate = 3,

        /// <summary>
        /// Use the hourly rate directly assigned to the task.
        /// </summary>
        PerTaskAssignedHourlyRate = 4
    }
}