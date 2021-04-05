using MockSchoolManagement.Models.EnumTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MockSchoolManagement.Models
{
    public class Student
    {
        public int Id { get; set; }
        
        [Display(Name = "名字")]
        [
            Required(ErrorMessage = "請輸入名字，不能為空"),
            MaxLength(50, ErrorMessage = "名字字數不能超過 50 個字")
        ]
        public string Name { get; set; }
        
        //public string Major { get; set; }
        // 將 Major 型別設置為 MajorEnum
        // MajorEnum? 使 Major 屬性值可為空
        
        [Required(ErrorMessage = ("請選擇一門主修"))]
        [Display(Name = "主修")]
        public MajorEnum? Major { get; set; }
        
        [Display(Name = "Email")]
        [
            RegularExpression(
                @"^[a-zA-z0-9_.+-]+@[a-zA-z0-9-]+\.[a-zA-z0-9-.]+$",
                ErrorMessage = "Email 格式不正確"
                )
        ]
        [Required(ErrorMessage = "請輸入 Email，不能為空")]
        public string Email { get; set; }

        public string PhotoPath { get; set; }
    }
}
