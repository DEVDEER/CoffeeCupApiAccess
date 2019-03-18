namespace devdeer.CoffeeCupApiAccess.Logic.Models.TransportModels
{
    using System;
    using System.Linq;

    using Newtonsoft.Json;

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

        [JsonProperty("allowConcurrentTimeEntries")]
        public bool AllowConcurrentTimeEntries { get; set; }

        [JsonProperty("bicNumber")]
        public string BankBicNumber { get; set; }

        [JsonProperty("ibanNumber")]
        public string BankIbanNumber { get; set; }

        [JsonProperty("bankName")]
        public string BankName { get; set; }

        [JsonProperty("beginningOfWeek")]
        public string BeginningOfWeek { get; set; }

        [JsonProperty("birthday")]
        public DateTime? Birthday { get; set; }

        [JsonProperty("birthplace")]
        public string Birthplace { get; set; }

        [JsonProperty("canManageAbsenceRequests")]
        public bool CanManageAbsenceRequests { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("dateFormat")]
        public string DateFormat { get; set; }

        [JsonProperty("department")]
        public string Department { get; set; }

        [JsonProperty("durationFormat")]
        public int? DurationFormat { get; set; }

        [JsonProperty("easybillEnabledAt")]
        public string EasyBillEnabledAt { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("emailHmacHash")]
        public string EmailHmacHash { get; set; }

        [JsonProperty("faxNumber")]
        public string FaxNumber { get; set; }

        [JsonProperty("firstname")]
        public string Firstname { get; set; }

        [JsonProperty("hourlyRate")]
        public int? HourlyRate { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("idHashed")]
        public string IdHashed { get; set; }

        [JsonProperty("imageDirectoryURL")]
        public string ImageDirectoryURL { get; set; }

        [JsonProperty("imageFileToken")]
        public string ImageFileToken { get; set; }

        [JsonProperty("imageType")]
        public int? ImageType { get; set; }

        [JsonProperty("insuranceName")]
        public string InsuranceName { get; set; }

        [JsonProperty("insuranceType")]
        public int? InsuranceType { get; set; }

        [JsonProperty("favorite")]
        public bool IsFavorite { get; set; }

        [JsonProperty("jobLabel")]
        public string JobLabel { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonProperty("lastname")]
        public string Lastname { get; set; }

        [JsonProperty("mobileNumber")]
        public string MobileNumber { get; set; }

        [JsonProperty("passwordStatus")]
        public int? PasswordStatus { get; set; }

        [JsonProperty("phoneNumber")]
        public string PhoneNumber { get; set; }

        [JsonProperty("postCode")]
        public string PostCode { get; set; }

        [JsonProperty("privateEmail")]
        public string PrivateEmail { get; set; }

        [JsonProperty("role")]
        public int? Role { get; set; }

        [JsonProperty("showInPlanner")]
        public bool ShowInPlanner { get; set; }

        [JsonProperty("status")]
        public int? Status { get; set; }

        [JsonProperty("street")]
        public string Street { get; set; }

        [JsonProperty("timeEntryBackgroundColor")]
        public int? TimeEntryBackgroundColor { get; set; }

        [JsonProperty("timeFormat")]
        public string TimeFormat { get; set; }

        [JsonProperty("timezone")]
        public string Timezone { get; set; }

        [JsonProperty("uiState")]
        public string UiState { get; set; }

        [JsonProperty("updatedAt")]
        public DateTime? UpdatedAt { get; set; }

        [JsonProperty("visibleDaysPerWeek")]
        public int? VisibleDaysPerWeek { get; set; }

        #endregion
    }
}