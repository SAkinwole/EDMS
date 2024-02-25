using Microsoft.AspNetCore.Mvc;

namespace EDMS.Controllers
{
    public class AccountsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
