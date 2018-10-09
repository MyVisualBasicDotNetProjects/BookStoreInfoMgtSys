using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace BookStoreInfoMgtSys.Models
{
    public class Book
    {
        public int ID { get; set; }

        public int ISBN { get; set; }
        
        [Required]
        public string Title { get; set; }
        
        [Required]
        public string AuthorName { get; set; }

        [StringLength(200)]
        public string BookDescription { get; set; }

        public int Edition { get; set; }

        public string Publisher { get; set; }
        
        [Required]
        public int PublicationYear { get; set; }

        [Required]
        public string BookCategory { get; set; }

        [Required]
        public string ShelfNumber { get; set; }
        
        [Range(1,5000)]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public decimal Price { get; set; }

        [Required]
        public int TotalNumberOfCopies { get; set; }

        public int NumberOfBooksOnLoan { get; set; }

        public int NumberOfBooksAvailable { get; set; }
    }

    public class BookStoreDBContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<BookStoreEmployee> BookStoreEmployees { get; set; }
        public DbSet<BookLoan> BookLoans { get; set; }
        public DbSet<BookReserve> BookReserves { get; set; }
    }

}