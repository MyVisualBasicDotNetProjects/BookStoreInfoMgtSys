using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace BookStoreInfoMgtSys.Models
{
    public class BookReserve
    {
        public int ID { get; set; }

        [Required]
        public Book BookReserved { get; set; }

        [Required]
        public Instructor InstructorReserved { get; set; }

    }

    //public class BookStoreDBContext : DbContext
    //{
    //    public DbSet<BookReserve> BookReserves { get; set; }
    //}
    
}