using Microsoft.AspNetCore.Http;
using StudentCrud.ViewModels.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StudentCrud.Models
{
    public class Student
    {
        [Required(ErrorMessage = "Név kitöltése kötelező")]
        [StringLength(20, ErrorMessage = "Max 20 karakter!")]
        [Display(Name = "Hallgató neve")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Neptunkód kitöltése kötelező")]
        [StringLength(20, ErrorMessage = "Max 20 karakter!")]
        [Display(Name = "Hallgató neptunkódja")]
        public string NeptunCode { get; set; }

        [Required(ErrorMessage = "Évfolyam kitöltése kötelező")]
        [Display(Name = "Hallgató évfolyama")]
        [StudentClassValidation(1, 3)]
        public int Class { get; set; }

        [Required(ErrorMessage = "Szak kitöltése kötelező")]
        [StringLength(20, ErrorMessage = "Max 20 karakter!")]
        [Display(Name = "Hallgató szakja")]
        public string Faculty { get; set; }

        [Key] //elsődleges kulcs megszorítás
        public string UID { get; set; }

        [NotMapped] //=ezt ne rakd az adatbázisba
        public IFormFile PhotoUpload { get; set; }

        public byte[] PhotoData { get; set; }

        public string ContentType { get; set; } //pl: jpeg, bmp, stb.

        public Student()
        {
            UID = Guid.NewGuid().ToString();
        }
    }
}
