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

        public HomeController(IStudentRepository studentRepository)
        {
            _studentRepository = new MockStudentRepository();
        }

        /// <summary>
        /// 回傳一個陣列
        /// </summary>
        /// <returns></returns>
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

        public ViewResult Details()
        {
            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
            {
                Student = _studentRepository.GetStudent(1),
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
