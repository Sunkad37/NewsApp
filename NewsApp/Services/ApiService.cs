using NewsApp.Models;
using Newtonsoft.Json;

namespace NewsApp.Services;

public class ApiService
{
    private static readonly HttpClient HttpClient = new HttpClient();

    private const string ApiUrl = "https://gnews.io/api/v4/top-headlines";
    private const string ApiToken = "5564f965a8fd20a317ce05c0aebdeeee";

    public async Task<Root?> GetNewsAsync(string category)
    {
        if (string.IsNullOrWhiteSpace(category))
            throw new ArgumentException("Category cannot be null or empty.", nameof(category));

        try
        {
            // Add lang and country for valid results
            var requestUrl = $"{ApiUrl}?category={category.ToLower()}&lang=en&country=in&apikey={ApiToken}";
        
            using var client = new HttpClient();
            var response = await client.GetStringAsync(requestUrl).ConfigureAwait(false);

            return JsonConvert.DeserializeObject<Root>(response);
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine($"Network error: {ex.Message}");
            return null;
        }
        catch (JsonException ex)
        {
            Console.WriteLine($"JSON parse error: {ex.Message}");
            return null;
        }
    }

}