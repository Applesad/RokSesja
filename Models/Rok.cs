using System.ComponentModel.DataAnnotations;

namespace FizzBuzz2.Models
{
    public class Rok
    {

        [Display(Name = "Podaj rok urodzenia")]
        [Required, Range(1899, 2022, ErrorMessage = "Oczekiwana wartość {0} z zakredu {1} i {2}.")]
        public int? Number { get; set; }
        [Display(Name = "Podaj imie")]
        [Required,MaxLength(100, ErrorMessage = "Oczekiwana wartość {0} z zakredu {1}.")]
        public string? Imie { get; set; }
        public string? Powiadomienie { get; set; }
        public string Check()
        {
            if (Number % 4 == 0) return "przystepny";
            else return "nieprzystepny";
        }
        
    }
}
