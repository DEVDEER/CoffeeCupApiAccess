namespace devdeer.CoffeeCupApiAccess.Logic.Models.Responses
{
    using System;
    using System.Linq;
    using System.Text.Json.Serialization;

    using DataModels;

    /// <summary>
    /// Represents the response of the CoffeeCup API when the vacation budgets endpoint is called.
    /// </summary>
    public class VacationBudgetResponse : BaseResponse
    {
        #region properties

        /// <summary>
        /// The list of vacation budgets.
        /// </summary>
        [JsonPropertyName("vacationBudgets")]
        public VacationBudget[] VacationBudgets { get; set; } = default!;

        #endregion
    }
}