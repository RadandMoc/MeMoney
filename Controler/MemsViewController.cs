using MeMoney.Pages;
using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace MeMoney.Controler
{
    public class MemsViewController : Controller
    {
        // Get: /MemsView/
        public IActionResult Index()
        {
            return View();
        }

        // Get: /MemsView/pv?id=/
        async public Task<IActionResult> pv(int id)
        {
            ViewMemsForOffertModel.offerId = id;
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync("https://localhost:7158/ViewMemsForOffert/");
            
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return Content(content, "text/html");
            }
            else
            {
                return StatusCode((int)response.StatusCode);
            }
        }
    }
}
