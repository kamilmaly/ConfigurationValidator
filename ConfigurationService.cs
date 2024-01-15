using ConfigurationValidator.Configuration;
using Microsoft.Extensions.Options;

namespace ConfigurationValidator
{
    public class ConfigurationService
    {
        private ServiceConfiguration _serviceConfiguration;

        public ConfigurationService(IOptions<ServiceConfiguration> serviceConfigurationOptions)
        {
            if(serviceConfigurationOptions.Value is null)
            {
                throw new ArgumentNullException("serviceconfigurationoptions.Value is missing");
            }
            if (string.IsNullOrEmpty (serviceConfigurationOptions.Value.ApiKey))
            {
                throw new ArgumentNullException("serviceConfiguration.Value.ApiKey is missing");
            }

            _serviceConfiguration = serviceConfigurationOptions.Value;
        }

        public ServiceConfiguration GetOptions()
        {
            return _serviceConfiguration;
        }
    }
}
