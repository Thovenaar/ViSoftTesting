using System.Net;
using System.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();

app.MapGet("/test", async () =>
{
    var handler = new HttpClientHandler {
        CookieContainer = new CookieContainer(),
        AutomaticDecompression = DecompressionMethods.All
    };

    var httpClient = new HttpClient(handler);
    httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/119.0.0.0 Safari/537.36");

    var httpRequest = new HttpRequestMessage(HttpMethod.Get, "https://www.douglas.nl/nl/p/1069044295?variant=019719");
    httpRequest.Headers.Accept.Add(MediaTypeWithQualityHeaderValue.Parse("text/html"));
    httpRequest.Headers.Accept.Add(MediaTypeWithQualityHeaderValue.Parse("text/plain"));
    httpRequest.Headers.Accept.Add(MediaTypeWithQualityHeaderValue.Parse("application/xhtml+xml"));
    httpRequest.Headers.Accept.Add(MediaTypeWithQualityHeaderValue.Parse("application/xml;q=0.9"));
    httpRequest.Headers.Accept.Add(MediaTypeWithQualityHeaderValue.Parse("image/avif"));
    httpRequest.Headers.Accept.Add(MediaTypeWithQualityHeaderValue.Parse("image/webp"));
    httpRequest.Headers.Accept.Add(MediaTypeWithQualityHeaderValue.Parse("image/apng"));
    httpRequest.Headers.Accept.Add(MediaTypeWithQualityHeaderValue.Parse("*/*;q=0.8"));
    httpRequest.Headers.Accept.Add(MediaTypeWithQualityHeaderValue.Parse("application/signed-exchange;v=b3;q=0.7"));
    httpRequest.Headers.AcceptLanguage.Add(StringWithQualityHeaderValue.Parse("en"));
    httpRequest.Headers.AcceptLanguage.Add(StringWithQualityHeaderValue.Parse("en-US;q=0.9"));
    httpRequest.Headers.AcceptLanguage.Add(StringWithQualityHeaderValue.Parse("nl;q=0.8"));
    httpRequest.Headers.AcceptLanguage.Add(StringWithQualityHeaderValue.Parse("nl-NL;q=0.7"));
    httpRequest.Headers.Connection.Add("keep-alive");
    httpRequest.Headers.CacheControl = CacheControlHeaderValue.Parse("no-cache");
    var response = await httpClient.SendAsync(httpRequest);

    var content = await response.Content.ReadAsStringAsync();
    return content;
}).WithOpenApi();

app.Run();