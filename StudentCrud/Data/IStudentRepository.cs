using StudentCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentCrud.Data
{
    //ezeket kell tudnia egy repónak!
    public interface IStudentRepository
    {
        void AddStudent(Student s);

        IEnumerable<Student> GetAll();

        void DeleteStudentById(string id);

        Student GetStudentById(string id);
    }
}
