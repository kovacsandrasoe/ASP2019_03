using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentCrud.Models;

namespace StudentCrud.Data
{
    public class StudentSQLRepository : IStudentRepository
    {
        //datacontext... <- EF kapcsolódási pont
        StudentContext database;

        public StudentSQLRepository(StudentContext db)
        {
            this.database = db;
        }

        public void AddStudent(Student s)
        {
            database.Students.Add(s);
            database.SaveChanges();
        }

        public void DeleteStudentById(string id)
        {
            var studenttodelete = GetStudentById(id);
            database.Students.Remove(studenttodelete);
            database.SaveChanges();
        }

        public IEnumerable<Student> GetAll()
        {
            return database.Students;
        }

        public Student GetStudentById(string id)
        {
            return database.Students.Where(t => t.UID == id)
                .FirstOrDefault();
        }
    }
}
