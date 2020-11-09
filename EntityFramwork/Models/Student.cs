using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Permissions;
using System.Web;

namespace EntityFramwork.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        [Display(Name ="Student Name")]
        [Required]
        
        public string  StudentName { get; set; }
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [Display(Name = "Date Of Birth")]
        public  DateTime StudentDateOfBirth  { get; set; }
        [Display(Name = " Address")]
        public string StudentAddress { get; set; }
        [Display(Name = "  Email id")]
        public string StudentEmailId { get; set; }
    }
}