namespace ProjectA.MyCustomHttpClient;

public class CustomHttpClient:ICustomHttpClient
{
    private readonly HttpClient _httpClient;

    public CustomHttpClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task SendAsync()
    {
        var request = new HttpRequestMessage(HttpMethod.Get, $"/test");
        var value = $"ih-rvp={DateTime.UtcNow:hh:mm:ss.ff};";
        request.Headers.Add("Cookie", $"ih-rvp={DateTime.UtcNow:hh:mm:ss.ff};");
        var response = await _httpClient.SendAsync(request);
        Console.WriteLine($"sent cookie with value:{value}");
    }
}