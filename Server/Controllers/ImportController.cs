using Microsoft.AspNetCore.Mvc;

namespace BlazorFinance.Server.Controllers
{
    public class ImportController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
