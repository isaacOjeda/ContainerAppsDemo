using ContainerAppsDemo.Api.Common.Services;
using System.Text.Json.Serialization;

namespace ContainerAppsDemo.Api.Infrastructure.Services;

public class BanxicoService : ICurrencyProvider
{
    private const string _token = "10703ef7b181d91d8b94fa6ab1e2da7b51f9d85bbf7408e7176295641f7dff30";
    private readonly HttpClient _httpClient;

    public BanxicoService(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("Banxico");
    }

    public async Task<BanxicoResponse> GetDollarValue()
    {

        var response = await _httpClient
            .GetAsync($"/SieAPIRest/service/v1/series/SF43785/datos/oportuno?token={_token}");


        response.EnsureSuccessStatusCode();


        return await response.Content.ReadFromJsonAsync<BanxicoResponse>();
    }
}

public class Bmx
{
    [JsonPropertyName("series")]
    public List<Series> Series { get; set; }
}

public class Datos
{
    [JsonPropertyName("fecha")]
    public string Fecha { get; set; }

    [JsonPropertyName("dato")]
    public string Dato { get; set; }
}

public class BanxicoResponse
{
    [JsonPropertyName("bmx")]
    public Bmx Bmx { get; set; }
}

public class Series
{
    [JsonPropertyName("idSerie")]
    public string IdSerie { get; set; }

    [JsonPropertyName("titulo")]
    public string Titulo { get; set; }

    [JsonPropertyName("datos")]
    public List<Datos> Datos { get; set; }
}

