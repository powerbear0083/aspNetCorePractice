﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MockSchoolManagement.Models;

namespace MockSchoolManagement.ViewModels
{
    public class StudentEditViewModel:StudentCreateViewModel
    {
        public int Id { get; set; }
        public string ExistingPhotoPath { get; set; }
        
    }
}
