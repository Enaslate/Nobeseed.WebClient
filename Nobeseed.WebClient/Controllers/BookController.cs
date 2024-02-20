using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Nobeseed.WebClient.Controllers
{
    public class BookController : Controller
    {
        public async Task<ActionResult> Index(Guid id)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7289/");

                try
                {
                    HttpResponseMessage response = await client.GetAsync($"/api/book/id?id={id}");

                    string data = await response.Content.ReadAsStringAsync();

                    ViewBag.Book = data;

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
