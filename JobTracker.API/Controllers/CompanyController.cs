using Microsoft.AspNetCore.Mvc;

namespace JobTracker.API.Controllers
{
    public class CompanyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
