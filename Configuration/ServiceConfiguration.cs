using System.ComponentModel.DataAnnotations;

namespace ConfigurationValidator.Configuration
{
    public class ServiceConfiguration
    {
        public const string SectionName = "ServiceConfiguration";

        public string ContactEmail { get; set; }

        public int LowestPriority { get; set; }

        public int HighestPriority { get; set; }

        [Required]
        public string ApiKey { get; set; }
    }
}
