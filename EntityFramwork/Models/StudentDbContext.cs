using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EntityFramwork.Models
{
    public class StudentDbContext :DbContext
    {
        public DbSet<Student> students { get; set; }


    }
}