using Haru.App.Features.Authentication.Services; // For ISignInService
using Haru.App.Features.Authentication.SignIn.DTOs;
using Haru.App.Common.Responses; // For GenericResponse - though not used in this example yet, good to have
using System.Threading.Tasks;

namespace Haru.App.Features.Authentication.Services.Mock;

public class SignInService : ISignInService
{
    public async Task<SignInResponseDto> SignInAsync(SignInRequestDto request)
    {
        await Task.Delay(1000); // Simulate network latency

        if (request.Username == "shiba" && request.Password == "inu")
        {
            return new SignInResponseDto 
            { 
                Token = "mock-jwt-token-shiba-inu", 
                IsTwoFactorEnabled = false, 
                UserId = "userShiba1" 
            };
        }
        else if (request.Username == "test" && request.Password == "test")
        {
             return new SignInResponseDto 
             { 
                 Token = "mock-jwt-token-test", 
                 IsTwoFactorEnabled = false, 
                 UserId = "userTest2" 
             };
        }
        else if (request.Username == "shiba2fa" && request.Password == "inu2fa") // User with 2FA
        {
             return new SignInResponseDto 
             { 
                 Token = "mock-jwt-token-shiba-2fa", // Could be a pre-2FA token or full token
                 IsTwoFactorEnabled = true, 
                 UserId = "userShiba2fa3" 
             };
        }
        
        return new SignInResponseDto { Token = null, IsTwoFactorEnabled = false, UserId = null }; // Failed login
    }
}
