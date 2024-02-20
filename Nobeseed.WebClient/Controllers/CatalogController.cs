using Dropbox.Api;
using Microsoft.AspNetCore.Mvc;

namespace Nobeseed.WebClient.Controllers
{
    public class CatalogController : Controller
    {
        public async Task<IActionResult> Index()
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7289/");
                
                try
                {
                    HttpResponseMessage response = await client.GetAsync("/api/book/");

                    string data = await response.Content.ReadAsStringAsync();

                    ViewBag.Data = data;

                    return View();
                } 
                catch (Exception ex)
                {
                    return View(ex);
                }
            }
        }
    }
}
