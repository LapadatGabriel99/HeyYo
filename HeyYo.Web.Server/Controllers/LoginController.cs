using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HeyYo.Web.Server.Controllers
{
    [ApiController]
    [Route("api/v1.0/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ILogger<LoginController> _logger;

        public LoginController(ILogger<LoginController> logger)
        {
            _logger = logger;
        }
    }
}
