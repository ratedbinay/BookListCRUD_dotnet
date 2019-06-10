using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Model
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name="Book Name")]
        public String Name { get; set; }
        public String ISBN { get; set; }
        public String Auther { get; set; }
    }
}
