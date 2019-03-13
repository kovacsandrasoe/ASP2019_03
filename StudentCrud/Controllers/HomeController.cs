using Microsoft.AspNetCore.Mvc;
using StudentCrud.Data;
using StudentCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentCrud.Controllers
{
    public class HomeController : Controller
    {
        IStudentRepository repo;

        public HomeController(IStudentRepository repo)
        {
            this.repo = repo;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Student student)
        {

            //fel kell dolgozni a képet
            //IFormFile -> byte[] és ContentType

            byte[] data = new byte[student.PhotoUpload.Length];

            using (var stream = student.PhotoUpload.OpenReadStream())
            {
                stream.Read(data, 0, (int)student.PhotoUpload.Length);
            }

            //elkészült a data
            student.PhotoData = data;
            student.ContentType = student.PhotoUpload.ContentType;

                repo.AddStudent(student);
            return RedirectToAction("Index");
        }

        public IActionResult GetAll()
        {
            return View(repo.GetAll());
        }

        public FileContentResult GetImage(string id)
        {
            //mit küldjünk vissza?
            //1: byte[]
            //2: ContentType
            var model = repo.GetStudentById(id);
            return new FileContentResult
                (model.PhotoData, model.ContentType);
        }

        public IActionResult Delete(string id)
        {
            repo.DeleteStudentById(id);
            return RedirectToAction("GetAll");
        }

        public IActionResult Print(string id)
        {
            var stud = repo.GetStudentById(id);
            return View(stud);
        }

        public IActionResult Modify(string id)
        {
            var student = repo.GetStudentById(id);

            ViewData["headertext"] = "Modify data for: " + student.Name;

            return View(student);
        }

        [HttpPost]
        public IActionResult Modify(Student newstudent)
        {
            if (!ModelState.IsValid)
            {
                return View(newstudent);
            }

            try
            {
                var oldstudent = repo.GetStudentById(newstudent.UID);
                newstudent.PhotoData = oldstudent.PhotoData;

                repo.DeleteStudentById(newstudent.UID);
                repo.AddStudent(newstudent);
            }
            catch(Exception e)
            {
                //saját hibakóddal visszatérés
                return StatusCode(777);
            }
            
            
            return RedirectToAction("GetAll");
        }


    }
}
