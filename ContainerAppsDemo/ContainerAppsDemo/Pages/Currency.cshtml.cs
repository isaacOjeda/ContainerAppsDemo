using ContainerAppsDemo.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ContainerAppsDemo.Pages
{
    public class CurrencyModel : PageModel
    {
        private readonly HttpClient _httpClient;

        public CurrencyModel(HttpClient httpClient, IConfiguration config)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(config["ApiHost"]);
        }

        public string Title { get; set; }
        public Datos BanxicoData { get; set; }

        public async Task OnGet()
        {
            var banxicoData = await _httpClient.GetFromJsonAsync<BanxicoResponse>("/api/banxico");

            var dollarSerie = banxicoData.Bmx.Series
                .FirstOrDefault();

            Title = dollarSerie.Titulo;

            BanxicoData = dollarSerie.Datos
                .FirstOrDefault();
        }
    }
}


