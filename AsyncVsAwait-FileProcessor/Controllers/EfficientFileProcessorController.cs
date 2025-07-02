using AsyncVsAwait_FileProcessor.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AsyncVsAwait_FileProcessor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EfficientFileProcessorController : ControllerBase
    {
        private readonly GoodTextProcessorService _service;

        public EfficientFileProcessorController(GoodTextProcessorService service)
        {
            _service = service;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            var result = await _service.ProcessFileAsync(file);
            return Ok(result);
        }
    }
}
