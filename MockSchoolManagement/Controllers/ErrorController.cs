using Microsoft.AspNetCore.Mvc;

namespace MockSchoolManagement.Controllers
{
    public class ErrorController : Controller
    {
        /// <summary>
        /// 如果狀態碼 404,則路徑將變為 Error / 404
        /// </summary>
        /// <returns></returns>
        [Route("Error/{statusCode}")]
        public IActionResult HttpStatusCodeHandler(int statusCode)
        {
            switch (statusCode)
            {
                case 404:
                    ViewBag.ErrorMessage = "抱歉，頁面不存在";
                    break;
            }
            return View("NotFound");
        }
    }
}