using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace ConfigDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConfigController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public ConfigController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet("appname")]
        public string GetAppName()
        {
            return _configuration["AppSettings:AppName"];
        }

        [HttpGet("conn")]
        public string GetConnection()
        {
            return _configuration.GetConnectionString("DefaultConnection");
        }
    }
}
