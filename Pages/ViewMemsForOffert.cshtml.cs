using MeMoney.DBases;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MeMoney.Pages
{
    public class ViewMemsForOffertModel : PageModel
    {
        public static int offerId;
        public int OfferId;
        public void OnGet()
        {
            OfferId = offerId;
        }
    }
}
