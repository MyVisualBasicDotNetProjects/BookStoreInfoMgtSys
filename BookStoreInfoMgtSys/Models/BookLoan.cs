using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace BookStoreInfoMgtSys.Models
{
    public class BookLoan
    {
        public int ID { get; set; }

        [Required]
        public Book BookLoaned { get; set; }

        [Required]
        public Instructor InstructorBorrowed { get; set; }

        [Required]
        public BookStoreEmployee EmployeeAuthenticatedLoan { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime LoanDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime LoanDueDate { get; set; }

        public Boolean Returned { get; set; }
                
    }

    //public class BookStoreDBContext : DbContext
    //{
    //    public DbSet<BookLoan> BookLoans { get; set; }
    //}
}