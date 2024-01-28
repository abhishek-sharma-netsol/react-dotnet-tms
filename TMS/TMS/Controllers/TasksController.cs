using Domain.Request;
using Microsoft.AspNetCore.Mvc;
using ServiceAbstraction;

namespace TMS.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class TasksController : Controller
    {
        private readonly IServiceManager _serviceManager;
        public TasksController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        // GET: TasksController
        [HttpGet("all")]
        public async Task<IActionResult> Index()
        {
            return Ok(await _serviceManager.TasksService.GetAllAsync());
        }

        [HttpGet("user/{id}")]
        public async Task<IActionResult> GetByUserIdAsync(long id)
        {
            return Ok(await _serviceManager.TasksService.GetAllByUserIdASync(id));
        }

        // GET: TasksController/Details/5
        [HttpGet("{id?}")]
        public async Task<IActionResult> Details(long id)
        {
            return Ok(await _serviceManager.TasksService.GetByIdAsync(id));
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(TaskRequest request)
        {
            return Ok(await _serviceManager.TasksService.AddAsync(request));
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update(TaskRequest request)
        {
            return Ok(await _serviceManager.TasksService.UpdateAsync(request));
        }

        [HttpPost("delete")]
        public async Task<IActionResult> Delete(TaskRequest request)
        {
            return Ok(await _serviceManager.TasksService.DeleteAsync(request));
        }
    }
}
