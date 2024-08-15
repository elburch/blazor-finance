using Microsoft.AspNetCore.Mvc;

namespace BlazorFinance.Server.Controllers
{
    public class AllocationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
