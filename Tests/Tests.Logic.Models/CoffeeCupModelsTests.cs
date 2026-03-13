namespace Tests.Logic.Models
{
    using System.Text.Json;

    using devdeer.CoffeeCupApiAccess.Logic.Models.Enumerations;

    using NUnit.Framework;

    /// <summary>
    /// Contains end-2-end-tests for the <see cref="CoffeeCupAccess" />.
    /// </summary>
    [TestFixture]
    public class CoffeeCupModelsTests
    {
        #region methods

        /// <summary>
        /// Tests deserialization of <see cref="BillingMapping" /> from JSON using its custom converter.
        /// </summary>
        [Test]
        public async Task DeserealizeBillingMapping()
        {
            var testCases = new []
            {
                JsonDeserealizationTestCase.MustSucseed("uppercase service", "\"SERVICE\"", BillingMapping.Service),
                JsonDeserealizationTestCase.MustSucseed("lowercase service", "\"service\"", BillingMapping.Service),
                JsonDeserealizationTestCase.MustSucseed("uppercase product", "\"PRODUCT\"", BillingMapping.Product),
                JsonDeserealizationTestCase.MustSucseed("lowercase product", "\"product\"", BillingMapping.Product),
                // Invalid values should be mapped to undefined
                JsonDeserealizationTestCase.MustSucseed("invalid string", "\"Invalid\"", BillingMapping.Undefined),
                JsonDeserealizationTestCase.MustSucseed("number value", "123", BillingMapping.Undefined),
                JsonDeserealizationTestCase.MustSucseed("empty string", "\"\"", BillingMapping.Undefined)
            };
            foreach (var testCase in testCases)
            {
                var result = JsonSerializer.Deserialize<BillingMapping>(testCase.JsonContent);
                Assert.That(
                    result,
                    Is.EqualTo(testCase.Expected),
                    $"Failed to deserialize {testCase.Description}: {testCase.JsonContent}");
            }
            await Task.CompletedTask;
        }

        /// <summary>
        /// Tests deserialization of <see cref="ExpenseCategoryType" /> from JSON using its custom converter.
        /// </summary>
        [Test]
        public async Task DeserealizeExpenseCategoryType()
        {
            var testCases = new []
            {
                JsonDeserealizationTestCase.MustSucseed("uppercase amount", "\"AMOUNT\"", ExpenseCategoryType.Amount),
                JsonDeserealizationTestCase.MustSucseed("lowercase amount", "\"amount\"", ExpenseCategoryType.Amount),
                JsonDeserealizationTestCase.MustSucseed("uppercase percent", "\"PERCENT\"", ExpenseCategoryType.Percent),
                JsonDeserealizationTestCase.MustSucseed("lowercase percent", "\"percent\"", ExpenseCategoryType.Percent),
                // Invalid values should be mapped to undefined
                JsonDeserealizationTestCase.MustSucseed("invalid string", "\"Invalid\"", ExpenseCategoryType.Undefined),
                JsonDeserealizationTestCase.MustSucseed("number value", "123", ExpenseCategoryType.Undefined),
                JsonDeserealizationTestCase.MustSucseed("empty string", "\"\"", ExpenseCategoryType.Undefined),
                JsonDeserealizationTestCase.MustSucseed("null value", "null", ExpenseCategoryType.Undefined),
            };
            foreach (var testCase in testCases)
            {
                var result = JsonSerializer.Deserialize<ExpenseCategoryType>(testCase.JsonContent);
                Assert.That(
                    result,
                    Is.EqualTo(testCase.Expected),
                    $"Failed to deserialize {testCase.Description}: {testCase.JsonContent}");
            }
            await Task.CompletedTask;
        }

        #endregion
    }
}