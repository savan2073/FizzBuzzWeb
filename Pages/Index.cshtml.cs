using FizzBuzzWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace FizzBuzzWeb.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        [BindProperty]
        public FizzBuzz FizzBuzz { set; get; }
        [BindProperty(SupportsGet = true)]
        public string Name { get; set; }
        public string AlertMessage { get; set; }
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                Name = "User";
            }

        }

        public IActionResult OnPost()
        {
            var dataList = new List<FizzBuzz>();

            var sessionData = HttpContext.Session.GetString("Data");
            if (!string.IsNullOrEmpty(sessionData))
            {
                dataList = JsonConvert.DeserializeObject<List<FizzBuzz>>(sessionData);
            }



            if (FizzBuzz.BirthYear == 0)
            {
                ModelState.Remove("FizzBuzz.BirthYear");
                ModelState.AddModelError("FizzBuzz.BirthYear", "Pole Rok urodzenia nie może być puste");
            }
            if (ModelState.IsValid)
            {
                AlertMessage = "Podane wartości są nieprawidłowe";
                return Page();
            }
            if(FizzBuzz.BirthYear >= 1899 && FizzBuzz.BirthYear <=2022)
            {
                dataList.Add(FizzBuzz);
            }

            FizzBuzz.CheckLeapYear();
            HttpContext.Session.SetString("Data", JsonConvert.SerializeObject(dataList));

            if (FizzBuzz.LeapYear)
            {
                AlertMessage = $"{FizzBuzz.FirstName} urodził/a się w {FizzBuzz.BirthYear} roku. To był rok przestępny";
            }
            else
            {
                AlertMessage = $"{FizzBuzz.FirstName} urodził/a się w {FizzBuzz.BirthYear} roku. To nie był rok przestępny";
            }

            return Page();
        }
    }
}