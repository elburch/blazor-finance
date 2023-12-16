using Microsoft.AspNetCore.Mvc;

namespace BlazorFinance.Server.Controllers
{
    public class ExportController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
