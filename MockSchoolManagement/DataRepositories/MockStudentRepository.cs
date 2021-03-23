using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MockSchoolManagement.Models;


namespace MockSchoolManagement.DataRepositories
{
    public class MockStudentRepository: IStudentRepository
    {
        private List<Student> _studentList;
        
        public MockStudentRepository()
        {
            _studentList = new List<Student>()
            {
                new Student()
                {
                    Id = 1,
                    Name =  "Mike",
                    Major = "computer",
                    Email = "abc@gmail.com"

                },
                new Student()
                {
                    Id = 2,
                    Name =  "John",
                    Major = "sport",
                    Email = "abc@gmail.com"

                },
                new Student()
                {
                    Id = 1,
                    Name =  "jane",
                    Major = "socail",
                    Email = "abc@gmail.com"

                },
            };
        }

        public Student GetStudent(int id)
        {
            return _studentList.FirstOrDefault(a => a.Id == id);
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return _studentList;
        }
    }
}
