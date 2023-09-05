using IntegrationTestsWebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace IntegrationTestsWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestsController : ControllerBase
    {
        private readonly TestsService _testsService;

        public TestsController(TestsService testsService)
        {
            _testsService = testsService;
        }

        [HttpGet]
        public IActionResult Get(int id)
        {
            return Ok(_testsService.GetData(id));
        }

        [HttpPost]
        public IActionResult Post([FromBody] string data)
        {
            return Ok(_testsService.AddData(data));
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            return Ok(_testsService.DeleteData(id));
        }
    }
}
