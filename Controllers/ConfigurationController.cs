using Microsoft.AspNetCore.Mvc;

namespace ConfigurationValidator.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConfigurationController : ControllerBase
    {
        private readonly ConfigurationService _service;

        public ConfigurationController(ConfigurationService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetOptions()
        {
           var options = _service.GetOptions();
           return Ok(options);
        }
    }
}