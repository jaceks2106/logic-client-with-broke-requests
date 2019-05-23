using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("testapi")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpPost]
        [Route("file")]
        public IActionResult PostFormFile(IFormFile file)
        {
            return Ok(file == null);
        }
    }
}
