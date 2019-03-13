using StudentCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentCrud.Data
{
    public class StudentRepository : IStudentRepository
    {
        List<Student> students;

        public StudentRepository()
        {
            students = new List<Student>();
        }

        public void AddStudent(Student s)
        {
            students.Add(s);
        }

        public IEnumerable<Student> GetAll()
        {
            return students;
        }

        public void DeleteStudentById(string id)
        {
            var student = students.Where(t => t.NeptunCode == id).First();


            students.RemoveAll(t => t.NeptunCode == id);

            //Student actual = students.Where(t => t.NeptunCode == id)
            //    .FirstOrDefault();
            //students.Remove(actual);
        }

        public Student GetStudentById(string id)
        {
            return students.Where(t => t.UID == id).FirstOrDefault();
        }
    }
}
