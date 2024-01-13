using Microsoft.AspNetCore.Mvc;

namespace BlazorFinance.Server.Controllers
{
    public class ProjectionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
