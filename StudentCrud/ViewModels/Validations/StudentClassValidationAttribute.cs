using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentCrud.ViewModels.Validations
{
    public class StudentClassValidationAttribute : ValidationAttribute 
    {
        int min;
        int max;
        public StudentClassValidationAttribute(int min, int max)
        {
            this.min = min;
            this.max = max;
        }

        public override bool IsValid(object value)
        {
            //object = amit beírtunk
            int number = int.Parse(value.ToString());
            return number >= min && number <= max;
        }

        public override string FormatErrorMessage(string name)
        {
            return $"Évfolyam csak {min} és {max} között lehet!";
        }
    }
}
