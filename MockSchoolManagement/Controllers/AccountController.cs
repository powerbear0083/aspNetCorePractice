﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MockSchoolManagement.ViewModels;

namespace MockSchoolManagement.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<IdentityUser> _userManager;

        private SignInManager<IdentityUser> _signInManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
        }
        // GET
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
       
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                // 將 registerViewModel 的資料複製到 IdentityUser
                var user = new IdentityUser
                {
                    UserName = model.Email,
                    Email = model.Email
                };
                
                // 將使用者資料存在 asp net users 資料庫中
                var result = await _userManager.CreateAsync(user, model.Password);

                // 如果成功建立新帳戶，則使用登入服務註冊用戶訊息
                // 註冊成功將 USER 轉導致 首頁
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("index", "home");
                }

                // 如果有錯 將錯誤加入至 ModelState Object 中
                // 由驗證摘邀標記駐手顯示到 view
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            
            
            return View(model);
        }
    }
}