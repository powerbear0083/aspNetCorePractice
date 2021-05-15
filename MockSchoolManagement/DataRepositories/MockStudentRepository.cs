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
        /// 實作 IStudentRepository 底下的 Insert
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public Student Insert(Student student)
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
        public Student GetStudentById(int? id)
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

        /// <summary>
        /// 實作 IStudentRepository 底下的 Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Student Delete(int id)
        {
            Student student = _studentList.FirstOrDefault(s => s.Id == id);

            if(student != null)
            {
                _studentList.Remove(student);
            }

            return student;

        }

        /// <summary>
        /// 實作 IStudentRepository 底下的 Update
        /// </summary>
        /// <param name="updateStudent"></param>
        /// <returns></returns>
        public Student Update(Student updateStudent)
        {
            Student student = _studentList.FirstOrDefault(s => s.Id == updateStudent.Id);

            if (student != null)
            {
                student.Name = updateStudent.Name;
                student.Email = updateStudent.Email;
                student.Major = updateStudent.Major;
            }

            return student;
        }
    }
}
