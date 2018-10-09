using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace BookStoreInfoMgtSys.Models
{
    public class Student
    {
        public int ID { get; set; }
        
        [Required]
        [StringLength(20)]
        public string FirstName { get; set; }
        
        [Required]
        [StringLength(20)]
        public string LastName { get; set; }
        
        [Required]
        [StringLength(30)]
        public string Department { get; set; }
                
        [Required]
        [StringLength(30)]
        public string College { get; set; }

        [Required]
        public int EnrollmentYear { get; set; }

        public int Section { get; set; }

        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}")]
        public string StudentEmail { get; set; }

    }

    //public class BookStoreDBContext : DbContext
    //{
    //    public DbSet<Student> Students { get; set; }
    //}

}