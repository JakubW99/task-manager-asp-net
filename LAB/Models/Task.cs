using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace LAB.Models
{
    public class Task
    {
        [HiddenInput]
        public int Id { get; set; }
        [Required(ErrorMessage = "Podaj Autora")]
        public string Author { get; set; }
        [RegularExpression(".+\\@.+\\.[a-z]{2,3}")]
        [Required(ErrorMessage = "Podaj poprawny Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Podaj nazwe zadania")]
        public string TaskName { get; set; }
        [MinLength(length: 5,ErrorMessage ="Opis musi mieć conajmniej 5 znaków")]
        public string Description { get; set; }

    }
}
