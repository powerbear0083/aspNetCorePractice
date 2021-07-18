using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MockSchoolManagement.Controllers
{
    public class ErrorController : Controller
    {

        private readonly ILogger<ErrorController> logger;

        /// <summary>
        /// 注入 ASP.NET Core ILogger
        /// 將 controller 類指定為泛型參數
        /// 有助於確定那個 class or controller 產生異常
        /// </summary>
        /// <param name="logger"></param>
        public ErrorController(ILogger<ErrorController> logger)
        {
            this.logger = logger;
        }
        
        /// <summary>
        /// 500 伺服器錯誤
        /// </summary>
        /// <returns></returns>
        [Route("Error")]
        public IActionResult Error()
        {
            var exceptionHandlerPathFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            logger.LogError($"路徑 {exceptionHandlerPathFeature.Path}" + $"產生了一個錯誤 {exceptionHandlerPathFeature.Error}");
            ViewBag.ExceptionPath = exceptionHandlerPathFeature.Path;
            ViewBag.ExceptionMessage = exceptionHandlerPathFeature.Error.Message;
            ViewBag.StackTrace = exceptionHandlerPathFeature.Error.StackTrace;

            return View("Error");
        }
        
        /// <summary>
        /// 如果狀態碼 404,則路徑將變為 Error / 404
        /// </summary>
        /// <returns></returns>
        [Route("Error/{statusCode}")]
        public IActionResult HttpStatusCodeHandler(int statusCode)
        {
            var statusCodeResult = HttpContext.Features.Get<IStatusCodeReExecuteFeature>();
            switch (statusCode)
            {
                case 404:
                    logger.LogWarning($"發生了一個 404 錯誤，路徑 = " + $"{statusCodeResult.OriginalPath} 以及查詢字符串" + $"{statusCodeResult.OriginalQueryString}");
                    ViewBag.ErrorMessage = "抱歉，頁面不存在";
                    ViewBag.Path = statusCodeResult.OriginalPath;
                    ViewBag.QS = statusCodeResult.OriginalQueryString;
                    break;
            }
            return View("NotFound");
        }

        
    }
}