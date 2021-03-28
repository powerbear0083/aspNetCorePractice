using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MockSchoolManagement.Models;

namespace MockSchoolManagement.DataRepositories
{
    public interface IStudentRepository
    {
        /// <summary>
        /// 取得一個學生
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Student GetStudent(int id);

        /// <summary>
        /// 取得學生列表
        /// </summary>
        /// <returns></returns>
        IEnumerable<Student> GetAllStudents();

        /// <summary>
        /// 增加新學生
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        Student Add(Student student);

    }
}
