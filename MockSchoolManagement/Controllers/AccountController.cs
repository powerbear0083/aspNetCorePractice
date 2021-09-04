using Microsoft.AspNetCore.Mvc;

namespace MockSchoolManagement.Controllers
{
    public class AccountController : Controller
    {
        // GET
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
    }
}