namespace Tests.Logic.Models
{
    /// <summary>
    /// Represents a test case for JSON deserialization.
    /// </summary>
    public class JsonDeserealizationTestCase
    {
        #region constructors and destructors

        /// <summary>
        /// Private constructor.
        /// </summary>
        /// <param name="expected">The expected result of the deserialization.</param>
        /// <param name="jsonContent">The JSON content to be deserialized.</param>
        /// <param name="description">A description of the test case.</param>
        /// <remarks>Use static methods for creating test cases.</remarks>
        private JsonDeserealizationTestCase(object expected, string jsonContent, string description)
        {
            Expected = expected;
            JsonContent = jsonContent;
            Description = description;
        }

        /// <summary>
        /// Private constructor.
        /// </summary>
        /// <param name="jsonContent">The JSON content to be deserialized.</param>
        /// <param name="description">A description of the test case.</param>
        /// <param name="exception">Optional exception that should be thrown when deserializing the json content.</param>
        /// <remarks>Use static methods for creating test cases.</remarks>
        private JsonDeserealizationTestCase(string jsonContent, string description, Exception? exception = null)
        {
            Exception = exception;
            JsonContent = jsonContent;
            Description = description;
        }

        #endregion

        #region methods
        /// <summary>
        /// Creates a test case that must fail.
        /// </summary>
        /// <param name="description">Description of the test case.</param>
        /// <param name="jsonContent">JSON content to be deserialized.</param>
        /// <param name="exception">Optional exception that should be thrown when deserializing the JSON content.</param>
        /// <returns>Test case instance.</returns>
        public static JsonDeserealizationTestCase MustFail(
            string description,
            string jsonContent,
            Exception? exception = null)
        {
            return new JsonDeserealizationTestCase(jsonContent, description, exception);
        }
        /// <summary>
        /// Creates a test case that must succeed.
        /// </summary>
        /// <param name="description">Description of the test case.</param>
        /// <param name="jsonContent">JSON content to be deserialized.</param>
        /// <param name="expected">Expected deserialized object.</param>
        /// <returns>Test case instance.</returns>
        public static JsonDeserealizationTestCase MustSucseed(string description, string jsonContent, object expected)
        {
            return new JsonDeserealizationTestCase(expected, jsonContent, description);
        }

        #endregion

        #region properties

        /// <summary>
        /// Indicates whether the deserialization is supposed to fail.
        /// </summary>
        public bool SupposedToFail => Expected == null;

        /// <summary>
        /// The expected result of the deserialization.
        /// </summary>
        public object? Expected { get; init; }

        /// <summary>
        /// The json content to deserialize.
        /// </summary>
        public string JsonContent { get; init; }

        /// <summary>
        /// A description of the test case.
        /// </summary>
        public string Description { get; init; }

        /// <summary>
        /// The exception that should be thrown when deserializing the json content.
        /// </summary>
        public Exception? Exception { get; init; }

        #endregion
    }
}