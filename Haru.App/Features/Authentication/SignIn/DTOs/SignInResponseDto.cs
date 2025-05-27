namespace Haru.App.Features.Authentication.SignIn.DTOs;

public class SignInResponseDto 
{ 
    public string Token { get; set; } 
    public bool IsTwoFactorEnabled { get; set; } // New property
    // Add other relevant response fields if any, e.g., UserId, DisplayName
    // For example, let's also ensure UserId is part of the response to pass to 2FA page
    public string UserId { get; set; } 
}
