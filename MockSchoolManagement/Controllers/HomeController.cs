using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MockSchoolManagement.DataRepositories;
using MockSchoolManagement.Models;
using MockSchoolManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MockSchoolManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStudentRepository _studentRepository;

        // 使用 constructor 注入的方式注入 IStudentRepository
        public HomeController(IStudentRepository studentRepository)
        {
            _studentRepository = new MockStudentRepository();
        }

        /// <summary>
        /// 回傳一個陣列
        /// </summary>
        /// <returns></returns>
        [Route("")]
        [Route("Index")]
        public ViewResult Index()
        {
            var model = _studentRepository.GetAllStudents();
            return View(model);
        }

        /// <summary>
        /// 回傳一筆資料
        /// </summary>
        /// <returns></returns>
        //public string Index()
        //{
        //    return _studentRepository.GetStudent(1).Name;
        //}

        /// <summary>
        /// Details method
        /// </summary>
        /// <returns></returns>
        /// 
        // 使用 id? 表示參數可為空
        [Route("Home/Details/{id?}")]
        // ? 使 id 方法參數可以是空的
        public ViewResult Details(int?id)
        {
            // Instantiate 實例化 HomeDetailsViewModel 並儲存 Student 詳細訊息和 PageTitle
            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
            {
                // 如果 id == null 則取第一筆
                Student = _studentRepository.GetStudent(id??1),
                PageTitle = "Student Details ViewModel"
            };

            return View(homeDetailsViewModel);
        }

        /// <summary>
        /// ViewBag
        /// </summary>
        /// <returns></returns>
        //public ViewResult Details()
        //{
        //    Student model = _studentRepository.GetStudent(1);

        //    ViewBag.PageTitle = "Student Details 2";

        //    return View(model);
        //}

        /// <summary>
        /// ViewData
        /// </summary>
        /// <returns></returns>
        //public ViewResult Details()
        //{
        //    Student model = _studentRepository.GetStudent(1);
        //    ViewData["PageTitel"] = "Student Details";
        //    ViewData["Student"] = model;

        //    return View(model);
        //}

        /// <summary>
        /// 回傳 Json 格式
        /// </summary>
        /// <returns></returns>
        //public JsonResult Details()
        //{
        //    Student model = _studentRepository.GetStudent(1);
        //    return Json(model);
        //}

        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        //public IActionResult Index()
        //{
        //    return View();
        //}

        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
