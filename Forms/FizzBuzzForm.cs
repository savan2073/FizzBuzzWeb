using System.ComponentModel.DataAnnotations;

namespace FizzBuzzWeb.Forms
{
    public class FizzBuzzForm
    {
        [Display(Name = "Twój szczęśliwy numerek")]
        [Required(ErrorMessage ="Pole jest obowiązkowe"),
            Range(1,1000, ErrorMessage ="Oczekiwana wartość {0} z zakresu {1} i {2}.")]
        public int? Number { get; set; }
        
        public string wyjscie()
        {
            if (Number % 3 == 0 && Number % 5 != 0)
            {
                return "Fizz";
            }
            else if (Number % 3 != 0 && Number % 5 == 0)
            {
                return "Buzz";
            }
            else if (Number % 3 == 0 && Number % 5 == 0)
            {
                return "FizzBuzz";
            }
            else
            {
                return "Liczba " + Number + "nie spełnia kryteriów FizzBuzz";
            }
        }
    }
}
