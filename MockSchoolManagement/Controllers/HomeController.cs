using Microsoft.AspNetCore.Mvc;
using MockSchoolManagement.DataRepositories;
using MockSchoolManagement.Models;
using MockSchoolManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace MockSchoolManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ILogger _logger;

        // 使用 constructor 注入的方式注入 IStudentRepository
        public HomeController(
            IStudentRepository studentRepository, 
            IWebHostEnvironment webHostEnvironment,
            ILogger<HomeController> logger
        )
        {
            _studentRepository = studentRepository;
            _webHostEnvironment = webHostEnvironment;
            _logger = logger;
        }

        /// <summary>
        /// 回傳一個陣列
        /// </summary>
        /// <returns></returns>
        [Route("")]
        [Route("Index")]
        public ViewResult Index()
        {
            IEnumerable<Student> model = _studentRepository.GetAllStudents();
            return View(model);
        }

        /// <summary>
        /// 回傳一筆資料
        /// </summary>
        /// <returns></returns>
        //public string Index()
        //{
        //    return _studentRepository.GetStudentById(1).Name;
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
            _logger.LogTrace(" Trace 追蹤 Log");
            _logger.LogDebug("Debug 除錯 log");
            _logger.LogInformation(" Information 資訊 Log");
            _logger.LogWarning("Warning 警告 log");
            _logger.LogError(" Error 錯誤 Log");
            _logger.LogCritical("Critical 嚴重 log");

            // GetStudentById 介面方法要重新定義，不然會報錯
            var student = _studentRepository.GetStudentById(id);
            if (student == null)
            {
                Response.StatusCode = 404;
                return View("StudentNotFound", (int) id);
            }
            // Instantiate 實例化 HomeDetailsViewModel 並儲存 Student 詳細訊息和 PageTitle
            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
            {
                // 如果 id == null 則取第一筆
                Student = _studentRepository.GetStudentById(id??1),
                PageTitle = $"Student Details "
            };

            return View(homeDetailsViewModel);
        }

        

        [HttpGet]
        public IActionResult Create()
        {
             return View();
        }
        /// <summary>
        /// 新增學生資訊，並將 User redirect 至 details
        /// </summary> RedirectToActionResult
        /// <param name="student"></param>
        /// <returns></returns>

        [HttpPost]
        public IActionResult Create(StudentCreateViewModel model)
        {
            if(ModelState.IsValid)
            {
                string uniqueFileName = null;
                if (model.Photos != null && model.Photos.Count > 0 )
                {

                    foreach (IFormFile photo in model.Photos)
                    {
                        // 要將圖片上傳至 wwwroot 的 images 底下
                        // 要取得 wwwroot 資料夾的路徑, 需要注入 ASP NET Core　提供的 WebHostEnvironment 服務
                        string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                        uniqueFileName = Guid.NewGuid().ToString() + "_" + photo.FileName;
                        string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                        // 使用 IFormFile 提供的 CopyTo method 將檔案複製到 wwwroot/images 
                        // 這邊 wwwroot 底下如果沒有 images 會發出找不到路徑的錯
                        photo.CopyTo(new FileStream(filePath, FileMode.Create));
                    }
                }

                Student newStudent = new Student
                {
                    Name = model.Name,
                    Email = model.Email,
                    Major = model.Major,
                    PhotoPath = uniqueFileName
                };

                _studentRepository.Insert(newStudent);
                return RedirectToAction("Details", new { id = newStudent.Id });
            }
            return View();
            
        }
        /// <summary>
        /// 編輯
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Student student = _studentRepository.GetStudentById(id);
            if (student == null)
            {
                Response.StatusCode = 404;
                return View("StundentNotFound", id);
            }
            StudentEditViewModel studentEditViewModel = new StudentEditViewModel
            {
                Id = student.Id,
                Name = student.Name,
                Email = student.Email,
                Major = student.Major,
                ExistingPhotoPath = student.PhotoPath
            };
            return View(studentEditViewModel);
        }

        /// <summary>
        /// 修改學生資料
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Edit(StudentEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                Student student = _studentRepository.GetStudentById(model.Id);
                student.Name = model.Name;
                student.Email = model.Email;
                student.Major = model.Major;

                if (model.Photos != null && model.Photos.Count > 0)
                {
                    if (model.ExistingPhotoPath != null)
                    {
                        string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "images",
                            model.ExistingPhotoPath);
                        System.IO.File.Delete(filePath);
                    }

                    student.PhotoPath = ProcessUploadeFile(model);
                }

                Student updatedstudent = _studentRepository.Update(student);
                return RedirectToAction("index");
            }
            return View(model);
        }

        private string ProcessUploadeFile(StudentEditViewModel model)
        {
            string uniqueFileName = null;

            if (model.Photos.Count > 0)
            {
                foreach (var photo in model.Photos)
                {
                    string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + photo.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        photo.CopyTo(fileStream);
                    }
                }
            }

            return uniqueFileName;
        }
    }
}
