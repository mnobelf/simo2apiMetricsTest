using Microsoft.AspNetCore.Mvc;
using simo2api.Models;
using simo2api.Services;
using Prometheus;
using simo2api.MetricsNamespace;

namespace simo2api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost]
        public IActionResult Authenticate(AuthenticateRequest model)
        {
            AppMetrics.AuthenticateCounter.Inc();

            var response = _userService.Authenticate(model);

            if (response == null)
                return BadRequest(new { message = "Username atau password salah !"});

            return Ok(response);
        }
    }
}
