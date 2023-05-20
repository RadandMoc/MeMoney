using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Identity.Client;

namespace MeMoney.Pages
{
    public class MemAuthorModel : PageModel
    {
        private readonly HttpContext _httpContext;

        public MemAuthorModel(HttpContext httpContext)
        {
            _httpContext = httpContext ?? throw new ArgumentNullException(nameof(httpContext));
        }
        public string NickName { get; set; }    
        public string Imie { get; set; }

        public string Nazwisko { get; set; }

        public string BankAccountNumber { get; set; }
        public void OnGet()
        {
        }
        public string debugger()
        {
            return "";
        }
    }
}
