using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MockSchoolManagement.Models;
using MockSchoolManagement.Models.EnumTypes;

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
                    Major = MajorEnum.ComputerScince,
                    Email = "abc@gmail.com"

                },
                new Student()
                {
                    Id = 2,
                    Name =  "John",
                    Major = MajorEnum.Mathematics,
                    Email = "def@gmail.com"

                },
                new Student()
                {
                    Id = 3,
                    Name =  "jane",
                    Major = MajorEnum.ElectronicCommerce,
                    Email = "ghi@gmail.com"

                },
            };
        }

        /// <summary>
        /// 實作 IStudentRepository 底下的 Add
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public Student Add(Student student)
        {
            student.Id = _studentList.Max(s => s.Id) + 1;
            _studentList.Add(student);

            return student;
        }
        /// <summary>
        /// 實作 IStudentRepository 底下的 GetStudent
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Student GetStudent(int id)
        {
            return _studentList.FirstOrDefault(a => a.Id == id);
        }

        /// <summary>
        /// 實作 IStudentRepository 底下的 GetAllStudents
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Student> GetAllStudents()
        {
            return _studentList;
        }
    }
}
