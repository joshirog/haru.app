using System.Net.Http.Json;

namespace Haru.App.Features.Account.SignIn;

public class SignInService(HttpClient httpClient)
{
    public async Task<SignInResponse?> SignInAsync(SignInRequest request)
    {
        var response = await httpClient.PostAsJsonAsync("api/auth/signin", request);

        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<SignInResponse>();
        }

        return null;
    }
}