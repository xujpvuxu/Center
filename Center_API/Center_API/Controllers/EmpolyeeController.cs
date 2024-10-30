using Center_API.Models.DB;
using Microsoft.AspNetCore.Mvc;

namespace Center_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmpolyeeController : ControllerBase
    {
        private readonly ILogger<EmpolyeeController> _logger;
        private CenterContext CenterContext { get; set; }

        public EmpolyeeController(CenterContext centerContext, ILogger<EmpolyeeController> logger)
        {
            CenterContext = centerContext;
            _logger = logger;
        }

        [HttpGet("")]
        public IEnumerable<Empolyee> Get()
        {
            return CenterContext.Empolyee.ToList();
        }
    }
}