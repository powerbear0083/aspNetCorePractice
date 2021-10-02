using System.ComponentModel.DataAnnotations;

namespace MockSchoolManagement.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public  string Email { get; set; }
        
       [Required]
       [DataType(DataType.Password)]
       public string Password { get; set; }
       
       [Display(Name = "記住我")]
       public bool RememberMe { get; set; }
    }
}