using Microsoft.EntityFrameworkCore;
using MockSchoolManagement.Models;
using MockSchoolManagement.Models.EnumTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MockSchoolManagement.Infrastructure
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasData(
                new Student
                {
                    Id = 1,
                    Name = "Mike",
                    Major = MajorEnum.ElectronicCommerce,
                    Email = "abc@gmail.com"
                },

                new Student
                {
                    Id = 2,
                    Name = "John",
                    Major = MajorEnum.Mathematics,
                    Email = "def@gmail.com"
                }
            );
        }
    }
}
