using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace BookStoreInfoMgtSys.Models
{
    public class BookStoreEmployee
    {
        public int ID { get; set; }
        
        [Required]
        [StringLength(20)]
        public string FirstName { get; set; }
        
        [Required]
        [StringLength(20)]
        public string LastName { get; set; }
        
        [Required]
        [StringLength(15)]
        public string Role { get; set; }
                
    }

    //public class BookStoreDBContext : DbContext
    //{
    //    public DbSet<BookStoreEmployee> BookStoreEmployees { get; set; }
    //}
    
}