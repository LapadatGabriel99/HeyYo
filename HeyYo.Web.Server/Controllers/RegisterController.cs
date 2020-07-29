using HeyYo.Core.Data.ApiModels;
using HeyYo.Web.BusinessLogic.Interfaces;
using HeyYo.Web.DataAccess.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace HeyYo.Web.Server.Controllers
{
    [ApiController]
    [Route("api/v1.0/[controller]")]
    public class RegisterController : ControllerBase
    {
        private readonly ILogger<RegisterController> _logger;

        private readonly IRegularUserService _regularUserService;

        private readonly UserManager<ApplicationUser> _userManager;

        public RegisterController(ILogger<RegisterController> logger, IRegularUserService regularUserService,
                                  UserManager<ApplicationUser> userManager)
        {
            _logger = logger;

            _regularUserService = regularUserService;

            _userManager = userManager;
        }
        
        [HttpPost]
        [Route("/register")]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterApi model)
        {
            var result = await _userManager.CreateAsync(new ApplicationUser
            {
                UserName = model.Username,
                Email = model.Email,
                PhoneNumber = model.Phone
            }, model.Password);

            if (!result.Succeeded)
            {
                
            }

            return Ok();
        }
    }
}
