using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorFinance.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AllocationController : Controller
    {
        // GET: AllocationController
        public ActionResult Index()
        {
            return View();
        }
    }
}
