namespace devdeer.CoffeeCupApiAccess.Logic.Models.DataModels
{
    using System;
    using System.Linq;

    /// <summary>
    /// A simplified version of <see cref="User" />.
    /// </summary>
    public class SimpleUser
    {
        #region properties

        /// <summary>
        /// The birthday of the user if any is set.
        /// </summary>
        public DateTime? Birthday { get; set; }

        /// <summary>
        /// The department the user works in.
        /// </summary>
        public string? Department { get; set; } = default!;

        /// <summary>
        /// The mail address of the user.
        /// </summary>
        public string Email { get; set; } = default!;

        /// <summary>
        /// The users first name.
        /// </summary>
        public string Firstname { get; set; } = default!;

        /// <summary>
        /// The unique id of the user.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Indicates if this user is currently planable in CoffeeCup.
        /// </summary>
        public bool IsCurrentlyValid { get; set; }

        /// <summary>
        /// The users last name.
        /// </summary>
        public string Lastname { get; set; } = default!;

        #endregion
    }
}