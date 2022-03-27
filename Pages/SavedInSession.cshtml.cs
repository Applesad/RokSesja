using FizzBuzz2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace FizzBuzz2.Pages
{
    public class SavedInSessionModel : PageModel
    {
        public Rok? Lata { get; set; }

        public List<Rok>? Latalista = new() { };
        public void OnGet()
        {
            var Data = HttpContext.Session.GetString("Data");
            if (Data != null)
            {
                Latalista = JsonConvert.DeserializeObject<List<Rok>>(Data);

            }
            
        }

    }
}
