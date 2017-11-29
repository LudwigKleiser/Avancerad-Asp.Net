using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebbApi.Models
{
    public class Person
    {
        [Required(ErrorMessage ="Du måste ange ett namn")]
        [StringLength(20, ErrorMessage ="Namnet får högst vara 20 tecken långt")]
        public string Name { get; set; }

       
        [Range(0, 120, ErrorMessage = "Åldern får bara vara mellan 0-120 år")]
        [Required(ErrorMessage = "Du måste ange en ålder")]
        public int Age { get; set; }

    }
}
