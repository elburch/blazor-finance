using Microsoft.AspNetCore.Mvc;

namespace BlazorFinance.Server.Controllers
{
    public class ProjectedEarningsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
