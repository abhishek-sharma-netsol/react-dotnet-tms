using Domain.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceAbstraction;

namespace TMS.Controllers
{
    [ApiController]
    [Authorize]
    [Route("/api/[controller]")]
    public class HomeController : Controller
    {
        private readonly IServiceManager _serviceManager;

        public HomeController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet]
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var response = await _serviceManager.UserService.GetAllAsync();
            return Ok(response);
        }
    }
}
