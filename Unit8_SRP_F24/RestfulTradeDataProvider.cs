using System;
using System.Net.Http;
using System.Text.Json;
using Unit8_SRP_F24.Contracts;

namespace Unit8_SRP_F24;

public class RestfulTradeDataProvider : ITradeDataProvider
{
    private static readonly HttpClient httpClient = new();
    string url;
    ILogger logger;

    public RestfulTradeDataProvider(string url, ILogger logger)
    {
        this.url = url;
        this.logger = logger;
    }

    public IEnumerable<string> ReadTradeData()
    {
        logger.LogMessage("Reading trade data from Restful API: " + url);

        using var request = new HttpRequestMessage(HttpMethod.Get, url);
        using var response = httpClient.Send(request);
        response.EnsureSuccessStatusCode();

        using var responseStream = response.Content.ReadAsStream();
        return JsonSerializer.Deserialize<string[]>(responseStream) ?? Array.Empty<string>();
    }
}
