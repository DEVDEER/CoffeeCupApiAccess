namespace devdeer.CoffeeCupApiAccess.Logic.Models.TransportModels
{
    using System;
    using System.Linq;
    using System.Text.Json.Serialization;

    using Enumerations;

    /// <summary>
    /// Contains the information about a single user in CoffeeCup.
    /// </summary>
    public class UserTransportModel
    {
        #region methods

        /// <summary>
        /// Converts this instance into the simplified version of it.
        /// </summary>
        /// <returns>The simplified model.</returns>
        public SimpleUserTransportModel ToSimple()
        {
            return new SimpleUserTransportModel
            {
                Id = Id,
                Birthday = Birthday,
                Department = Department,
                Email = Email,
                Firstname = Firstname,
                Lastname = Lastname,
                IsCurrentlyValid = ShowInPlanner
            };
        }

        #endregion

        #region properties

        [JsonPropertyName("allowConcurrentTimeEntries")]
        public bool AllowConcurrentTimeEntries { get; set; }

        [JsonPropertyName("bicNumber")]
        public string BankBicNumber { get; set; }

        [JsonPropertyName("ibanNumber")]
        public string BankIbanNumber { get; set; }

        [JsonPropertyName("bankName")]
        public string BankName { get; set; }

        [JsonPropertyName("beginningOfWeek")]
        public string BeginningOfWeek { get; set; }

        [JsonPropertyName("birthday")]
        public DateTime? Birthday { get; set; }

        [JsonPropertyName("birthplace")]
        public string Birthplace { get; set; }

        [JsonPropertyName("canManageAbsenceRequests")]
        public bool CanManageAbsenceRequests { get; set; }

        [JsonPropertyName("city")]
        public string City { get; set; }

        [JsonPropertyName("country")]
        public string Country { get; set; }

        [JsonPropertyName("dateFormat")]
        public string DateFormat { get; set; }

        [JsonPropertyName("department")]
        public string Department { get; set; }

        [JsonPropertyName("durationFormat")]
        public DurationFormat DurationFormat { get; set; }

        [JsonPropertyName("easybillEnabledAt")]
        public string EasyBillEnabledAt { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("emailHmacHash")]
        public string EmailHmacHash { get; set; }

        [JsonPropertyName("faxNumber")]
        public string FaxNumber { get; set; }

        [JsonPropertyName("firstname")]
        public string Firstname { get; set; }

        [JsonPropertyName("hourlyRate")]
        public double? HourlyRate { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("idHashed")]
        public string IdHashed { get; set; }

        [JsonPropertyName("imageDirectoryURL")]
        public string ImageDirectoryUrl { get; set; }

        [JsonPropertyName("imageFileToken")]
        public string ImageFileToken { get; set; }

        [JsonPropertyName("imageType")]
        public ImageType? ImageType { get; set; }

        [JsonPropertyName("insuranceName")]
        public string InsuranceName { get; set; }

        [JsonPropertyName("insuranceType")]
        public int? InsuranceType { get; set; }

        [JsonPropertyName("favorite")]
        public bool IsFavorite { get; set; }

        [JsonPropertyName("jobLabel")]
        public string JobLabel { get; set; }

        [JsonPropertyName("language")]
        public string Language { get; set; }

        [JsonPropertyName("lastname")]
        public string Lastname { get; set; }

        [JsonPropertyName("mobileNumber")]
        public string MobileNumber { get; set; }

        [JsonPropertyName("passwordStatus")]
        public PasswordStatus PasswordStatus { get; set; }

        [JsonPropertyName("phoneNumber")]
        public string PhoneNumber { get; set; }

        [JsonPropertyName("postCode")]
        public string PostCode { get; set; }

        [JsonPropertyName("privateEmail")]
        public string PrivateEmail { get; set; }

        [JsonPropertyName("role")]
        public int? Role { get; set; }

        [JsonPropertyName("showInPlanner")]
        public bool ShowInPlanner { get; set; }

        [JsonPropertyName("status")]
        public Status Status { get; set; }

        [JsonPropertyName("street")]
        public string Street { get; set; }

        [JsonPropertyName("timeEntryBackgroundColor")]
        public TimeEntryBackgroundColorType TimeEntryBackgroundColor { get; set; }

        [JsonPropertyName("timeFormat")]
        public string TimeFormat { get; set; }

        [JsonPropertyName("timezone")]
        public string Timezone { get; set; }

        [JsonPropertyName("uiState")]
        public string UiState { get; set; }

        [JsonPropertyName("updatedAt")]
        public DateTime? UpdatedAt { get; set; }

        [JsonPropertyName("visibleDaysPerWeek")]
        public int? VisibleDaysPerWeek { get; set; }

        #endregion
    }
}