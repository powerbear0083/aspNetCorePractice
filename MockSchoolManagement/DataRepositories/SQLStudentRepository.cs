using MockSchoolManagement.Infrastructure;
using MockSchoolManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace MockSchoolManagement.DataRepositories
{
    public class SQLStudentRepository : IStudentRepository
    {

        private readonly ILogger _logger;
        private readonly AppDbContext _context;

        public SQLStudentRepository(
            AppDbContext context,
            ILogger<SQLStudentRepository> logger
        )
        {
            _context = context;
            _logger = logger;
        }

        public Student Delete(int id)
        {
            Student student = _context.Students.Find(id);

            if(student != null)
            {
                _context.Students.Remove(student);
                _context.SaveChanges();
            }

            return student;
        }

        public IEnumerable<Student> GetAllStudents()
        {
            _logger.LogTrace("Students Trace 追蹤 Log");
            _logger.LogDebug("Students Debug 除錯 log");
            _logger.LogInformation("Students Information 資訊 Log");
            _logger.LogWarning("Students Warning 警告 log");
            _logger.LogError("Students Error 錯誤 Log");
            _logger.LogCritical("Students Critical 嚴重 log");
            return _context.Students;
        }

        public Student GetStudentById(int? id)
        {
            return _context.Students.Find(id);
        }

        public Student Insert(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();

            return student;
        }

        public Student Update(Student updateStudent)
        {
            var student = _context.Students.Attach(updateStudent);
            student.State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            _context.SaveChanges();

            return updateStudent;
        }
    }
}
