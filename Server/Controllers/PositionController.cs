using Microsoft.AspNetCore.Mvc;

namespace BlazorFinance.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PositionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
