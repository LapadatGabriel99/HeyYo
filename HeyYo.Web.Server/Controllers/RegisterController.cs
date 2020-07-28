using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HeyYo.Web.Server.Controllers
{
    [ApiController]
    [Route("api/v1.0/[controller]")]
    public class RegisterController : ControllerBase
    {
        private readonly ILogger<RegisterController> _logger;

        public RegisterController(ILogger<RegisterController> logger)
        {
            _logger = logger;
        }
    }
}
