using System.Text.Json.Serialization;

namespace ContainerAppsDemo.Models;

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