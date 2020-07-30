using HeyYo.Core.Data.ApiModels;
using HeyYo.Web.BusinessLogic.Interfaces;
using HeyYo.Web.DataAccess.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;

namespace HeyYo.Web.Server.Controllers
{
    [ApiController]
    [Route("api/v1.0/[controller]")]
    public class RegisterController : ControllerBase
    {
        private readonly ILogger<RegisterController> _logger;

        private readonly IConfiguration _configuration;

        private readonly IRegularUserService _regularUserService;

        private readonly UserManager<ApplicationUser> _userManager;

        public RegisterController(ILogger<RegisterController> logger, IRegularUserService regularUserService,
                                  UserManager<ApplicationUser> userManager, IConfiguration configuration)
        {
            _logger = logger;

            _configuration = configuration;

            _regularUserService = regularUserService;

            _userManager = userManager;
        }
        
        [HttpPost]
        [Route("/register")]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterApi model)
        {
            var identityResult = await _userManager.CreateAsync(new ApplicationUser
            {
                UserName = model.Username,
                Email = model.Email,
                PhoneNumber = model.Phone
            }, model.Password);            
            
            if (!identityResult.Succeeded)
            {
                var errors = identityResult.Errors.ToDictionary(e => e.Code, e => e.Description).ToList();

                var errorResponse = new NormalErrorResponse();

                foreach (var error in errors)
                {
                    errorResponse.Errors.Add(new NormalErrorModel
                    {
                        Code = error.Key,
                        Description = error.Value
                    });
                }

                return BadRequest(errorResponse);
            }

            var applicationUser = await _userManager.FindByEmailAsync(model.Email);

            var regularUser = new RegularUser
            {
                ApplicationUser = applicationUser
            };

            if (await _regularUserService.CreateRegularUserAsync(regularUser))
            {
                var errorResponse = new NormalErrorResponse();

                errorResponse.Errors.Add(new NormalErrorModel
                {
                    Description = "Failed to register user!"
                });

                return BadRequest(errorResponse);
            }

            return Ok();
        }
    }
}
