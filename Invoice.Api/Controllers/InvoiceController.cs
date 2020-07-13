using Microsoft.AspNetCore.Mvc;

namespace Invoice.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InvoiceController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Invoice");
        }
    }
}
    

    