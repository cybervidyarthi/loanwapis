using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LoanWAPIs.Models
{
    public class LeadInformation
    {
        public int Id { get; set; }

        public float LoanAmountRequired { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public LeadSource LeadSource { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public CommunicationModes CommunicationMode { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public LeadStatus CurrentStatus { get; set; }

        [Required]
        public ContactDetails Contact { get; set; }

    }
}
