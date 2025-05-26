using System.Threading.Tasks;

namespace Haru.App.Features.Account.SignIn;

// Ensure SignInRequest and SignInResponse are defined and accessible.
// If they are not in a shared DTOs folder, define them here or in a relevant shared location.
// For this subtask, we'll assume they need to be defined if not already globally available.

public class SignInRequest 
{ 
    public string Username { get; set; } 
    public string Password { get; set; } 
}

public class SignInResponse 
{ 
    public string Token { get; set; } 
    // Add other relevant response fields if any, e.g., UserId, DisplayName
}

public interface ISignInService
{
    Task<SignInResponse> SignInAsync(SignInRequest request);
}
