namespace devdeer.CoffeeCupApiAccess.Tests.Logic.Core
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using CoffeeCupApiAccess.Logic.Core;
    using CoffeeCupApiAccess.Logic.Models.Requests;

    using NUnit.Framework;

    /// <summary>
    /// Contains end-2-end-tests for the <see cref="CoffeeCupAccess" />.
    /// </summary>
    [TestFixture]
    public class CoffeeCupApiAccessTests
    {
        #region methods

        /// <summary>
        /// Checks the data of <see cref="CoffeeCupAccess.GetTimeEntriesByDayRangeAsync" />.
        /// </summary>
        [Test]
        public async Task GetTimeEntries_ByDayRange()
        {
            Assert.That(ApiAccess, Is.Not.Null, "Logic not initialized");
            var minDate = new DateTime(2023, 6, 1);
            var maxDate = new DateTime(2023, 6, 30);
            var result = await ApiAccess.GetTimeEntriesByDayRangeAsync(minDate, maxDate);
            Assert.That(result, Is.Not.Null);
            if (result == null)
            {
                return;
            }
            Assert.That(result.Count, Is.GreaterThan(0));
            var minResultDate = result.Min(r => r.Day);
            var maxResultDate = result.Max(r => r.Day);
            Assert.That(minDate, Is.LessThanOrEqualTo(minResultDate));
            Assert.That(maxDate, Is.GreaterThanOrEqualTo(maxResultDate));
        }

        /// <summary>
        /// Checks the data of <see cref="CoffeeCupAccess.GetTimeEntriesAsync()" />.
        /// </summary>
        [Test]
        public async Task GetTimeEntries_Filtered()
        {
            Assert.That(ApiAccess, Is.Not.Null, "Logic not initialized");
            var minDate = new DateTime(2023, 6, 1);
            var maxDate = new DateTime(2023, 6, 30);
            var filter = new TimeEntriesRequest
            {
                From = minDate,
                To = maxDate,
                ProjectFilterIds = new[] { 15639 }
            };
            var result = await ApiAccess.GetTimeEntriesAsync(filter);
            Assert.That(result, Is.Not.Null);
            if (result == null)
            {
                return;
            }
            Assert.That(result!.Count, Is.GreaterThan(0));
            Assert.That(result!.All(r => r.ProjectId == 15639), Is.True);
            var minResultDate = result.Min(r => r.Day);
            var maxResultDate = result.Max(r => r.Day);
            Assert.That(minDate, Is.LessThanOrEqualTo(minResultDate));
            Assert.That(maxDate, Is.GreaterThanOrEqualTo(maxResultDate));
        }

        /// <summary>
        /// Simple null-check for <see cref="CoffeeCupAccess.GetTimeEntriesAsync()" />.
        /// </summary>
        [Test]
        public async Task GetTimeEntries_RetrievesNotNull()
        {
            Assert.That(ApiAccess, Is.Not.Null, "Logic not initialized");
            var result = await ApiAccess.GetTimeEntriesAsync();
            Assert.That(result, Is.Not.Null);
        }

        /// <summary>
        /// Simple null-check for <see cref="CoffeeCupAccess.GetUserEmploymentsAsync" />.
        /// </summary>
        [Test]
        public async Task GetUserEmployments_RetrievesNotNull()
        {
            Assert.That(ApiAccess, Is.Not.Null, "Logic not initialized");
            var result = await ApiAccess.GetUserEmploymentsAsync();
            Assert.That(result, Is.Not.Null);
        }

        /// <summary>
        /// Simple null-check for <see cref="CoffeeCupAccess.GetAbsenceRequestsAsync" />.
        /// </summary>
        [Test]
        public async Task GetAbsencyRequests_RetrievesNotNull()
        {
            Assert.That(ApiAccess, Is.Not.Null, "Logic not initialized");
            var result = await ApiAccess.GetAbsenceRequestsAsync(2024);
            Assert.That(result, Is.Not.Null);
            Assert.That(result!.Any(), Is.True);
        }

        /// <summary>
        /// Reads the values from the settings.json file if it exists.
        /// </summary>
        [OneTimeSetUp]
        public void Init()
        {
            ApiAccess = DependencyHelper.GetRequiredService<CoffeeCupAccess>();
        }

        #endregion

        #region properties

        /// <summary>
        /// Provides easy access to the initialized logic.
        /// </summary>
        private CoffeeCupAccess ApiAccess { get; set; } = default!;

        #endregion
    }
}