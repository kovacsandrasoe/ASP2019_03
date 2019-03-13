using Microsoft.EntityFrameworkCore;
using StudentCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentCrud.Data
{
    public class StudentContext : DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> opt) : base(opt)
        {

        }

        //milyen adattáblák legyenek??
        //1db adattábla kellene: ami Student-eket tartalmaz
        public DbSet<Student> Students { get; set; } //<- ez maga az adattábla


    }
}
