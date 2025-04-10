using Microsoft.AspNetCore.Mvc;

namespace JobTracker.API.Controllers
{

    public class CompanyController : ControllerBase
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
