using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Identity.Client;

namespace MeMoney.Pages
{
    public class MemAuthorModel : PageModel
    {
       
        public string NickName { get; set; }    
        public string Imie { get; set; }

        public string Nazwisko { get; set; }

        public string BankAccountNumber { get; set; }


        public MemAuthorModel() 
        {

        }
        public void OnGet()
        {
        }
        public string debugger()
        {
            return "";
        }
    }
}
