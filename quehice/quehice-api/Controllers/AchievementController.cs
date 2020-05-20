using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace QueHice.Api.Controllers
{
    /// <summary>
    ///     AchievementController
    /// </summary>
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class AchievementController : ControllerBase
    {
        private readonly ILogger<AchievementController> _logger;

        public AchievementController(ILogger<AchievementController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public IActionResult Post()
        {
            return Ok();
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }

        
    }
}