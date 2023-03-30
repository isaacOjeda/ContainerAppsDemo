using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ContainerAppsDemo.Pages;
public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly HttpClient _client;

    public IndexModel(ILogger<IndexModel> logger, HttpClient client, IConfiguration config)
    {
        _logger = logger;
        _client = client;

        _client.BaseAddress = new Uri(config["ApiHost"]);
    }

    public List<ProductDto> Products { get; set; } = new();

    public async Task OnGet()
    {
        Products = await _client.GetFromJsonAsync<List<ProductDto>>("api/products");
    }
}




public class ProductDto
{
    public int ProductId { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
}
