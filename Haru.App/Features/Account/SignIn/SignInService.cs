using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Haru.App.Features.Account.SignIn;

public class SignInService : ISignInService
{
    private readonly HttpClient _httpClient;

    public SignInService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<SignInResponse> SignInAsync(SignInRequest request)
    {
        var response = await _httpClient.PostAsJsonAsync("api/auth/signin", request);

        if (response.IsSuccessStatusCode)
        {
            // Assuming SignInResponse will not be null if IsSuccessStatusCode is true
            // and ReadFromJsonAsync<SignInResponse> will throw if deserialization fails or content is null.
            // If it can be null, the return type of the interface method might need to be Task<SignInResponse?>
            return await response.Content.ReadFromJsonAsync<SignInResponse>() ?? new SignInResponse();
        }

        // For simplicity, returning an empty response or you could throw a custom exception
        // or return a response object indicating failure, depending on error handling strategy.
        return new SignInResponse(); // Or throw an exception, e.g., throw new HttpRequestException($"Request failed with status code {response.StatusCode}");
    }
}