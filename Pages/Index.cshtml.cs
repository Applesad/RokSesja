using FizzBuzz2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
namespace FizzBuzz2.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        [BindProperty(SupportsGet = true)]
        public string?   Name { get; set; }

        [BindProperty]
        public Rok? Rok { get;set; }
        public List<Rok>? Latalista = new() { };
        public string Urodzenie;
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
            if (!ModelState.IsValid)
            {
                if (string.IsNullOrWhiteSpace(Name))
                {
                    Name = "User";
                }
                return Page();
            }
            if ((Rok.Imie[Rok.Imie.Length - 1] != 'a') || (Rok.Imie == "Kuba"))
            {
                Urodzenie = "urodzil";
            }
            else Urodzenie = "urodzila";
            TempData["AlertMessage"] = Rok.Check();
            Rok.Powiadomienie = Rok.Check();

            if (string.IsNullOrWhiteSpace(Name))
            {
                Name = "User";
            }
            if (ModelState.IsValid)
            {
                var Data = HttpContext.Session.GetString("Data");
                if (Data == null)
                {
                    Latalista = new List<Rok>();
                    Latalista.Add(Rok);
                    HttpContext.Session.SetString("Data", JsonConvert.SerializeObject(Latalista));

                }
                else
                {
                    Latalista = JsonConvert.DeserializeObject<List<Rok>>(Data);
                    Latalista.Add(Rok);
                    HttpContext.Session.SetString("Data", JsonConvert.SerializeObject(Latalista));

                }
                

            }
            return Page();

        }

    }
}