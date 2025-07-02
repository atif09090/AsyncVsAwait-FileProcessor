using AsyncVsAwait_FileProcessor.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AsyncVsAwait_FileProcessor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThreadBlockingController : ControllerBase
    {
        private readonly BadTextProcessorService _service;

        public ThreadBlockingController(BadTextProcessorService service)
        {
            _service = service;
        }

        [HttpPost("upload")]
        public IActionResult Upload(IFormFile file)
        {
            var result = _service.ProcessFile(file).Result; // Blocking async call
            return Ok(result);
        }
    }
}
