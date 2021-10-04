using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace MockSchoolManagement.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Remote(action: "IsEmailInUse", controller: "Account")]
        [Display(Name = "電子郵件")]
        public  string Email { get; set; }
       
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "密碼")]
        public string Password { get; set; }
        
        [DataType(DataType.Password)]
        [Display(Name = "確認密碼")]
        [Compare("Password", ErrorMessage = "密碼與確認密碼不一致，請重新輸入")]
        public string ConfirmPassword { get; set; }
        
    }
}