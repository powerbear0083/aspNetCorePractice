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
        
        public string Name { get; set; }
        
        //public string Major { get; set; }
        // 將 Major 型別設置為 MajorEnum
        // MajorEnum? 使 Major 屬性值可為空
        
        public MajorEnum? Major { get; set; }
        
        
        public string Email { get; set; }

        public string PhotoPath { get; set; }
    }
}
