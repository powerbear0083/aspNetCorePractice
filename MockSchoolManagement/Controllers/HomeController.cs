using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MockSchoolManagement.DataRepositories;
using MockSchoolManagement.Models;
using MockSchoolManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace MockSchoolManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        // 使用 constructor 注入的方式注入 IStudentRepository
        public HomeController(IStudentRepository studentRepository, IWebHostEnvironment webHostEnvironment)
        {
            _studentRepository = studentRepository;
            _webHostEnvironment = webHostEnvironment;
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
            // Instantiate 實例化 HomeDetailsViewModel 並儲存 Student 詳細訊息和 PageTitle
            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
            {
                // 如果 id == null 則取第一筆
                Student = _studentRepository.GetStudentById(id??1),
                PageTitle = "Student Details ViewModel"
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

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Student student = _studentRepository.GetStudentById(id);
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
        
    }
}
