using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Identity.Client;

namespace MeMoney.Pages
{
    public class MemAuthorModel : PageModel
    {

        public string Name { get; set; }    
        public string Imie { get; set; }

        public string Nazwisko { get; set; }

        public string BankAccountNumber { get; set; }
        public void OnGet()
        {
        }
    }
}
