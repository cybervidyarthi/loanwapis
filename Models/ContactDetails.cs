using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Text.Json.Serialization;
using LoanWAPIs.Utilities;

namespace LoanWAPIs.Models
{
    public class ContactDetails
    {
        public int Id { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ContactType TypeOfContact { get; set; }
        public string ContactName { get; set; }
        [JsonConverter(typeof(JsonConverterDateTimeToDate))]
        public DateTime Dob
        { get; set;}
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Gender GenderOfContact { get; set; }
        public string Email { get; set; }
        public string ContactNumber { get; set; }
    }
}
