using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;



namespace FizzBuzzWeb.Models
{
    public class FizzBuzz
    {
        [Range(1899, 2022, ErrorMessage = "Oczekiwana wartość {0} z zakresu <{1} i {2}>.")]
        [Required(ErrorMessage = "Pole Rok Urodzenia nie może być puste")]
        [Display(Name = "Rok urodzenia")]
        public int BirthYear { get; set; }

        [RegularExpression("[A-Za-z]*", ErrorMessage = "Nie możesz używać liczb oraz znaków specjalnych")]
        [Required(ErrorMessage = "Pole Imię nie może być puste")]
        [Display(Name = "Imię")]
        [MaxLength(100)]

        public string FirstName { get; set; }

        public bool LeapYear { get; set; }

        public void CheckLeapYear()
        {
            LeapYear = ((BirthYear % 4 == 0) && (BirthYear % 100 != 0)) || (BirthYear % 400 == 0);
        }

    }
}
