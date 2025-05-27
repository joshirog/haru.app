using Haru.App.Features.Authentication.Services; // For ISignUpService
using Haru.App.Features.Authentication.SignUp.DTOs;
using Haru.App.Common.Responses;
using System.Threading.Tasks;
using System.Linq; // For basic validation example

namespace Haru.App.Features.Authentication.Services.Mock;

public class SignUpService : ISignUpService
{
    public async Task<GenericResponse> SignUpAsync(SignUpRequestDto request)
    {
        await Task.Delay(1000); // Simulate network latency

        if (string.IsNullOrWhiteSpace(request.Email) || 
            string.IsNullOrWhiteSpace(request.Password) ||
            request.Password != request.ConfirmPassword)
        {
            return new GenericResponse(false, "Invalid input. Please check your details.");
        }

        // Simulate a successful sign-up
        // In a real scenario, you might check if the email is already taken, etc.
        if (request.Email.ToLower() == "shibainu@example.com") {
             return new GenericResponse(false, "This email is already registered by a very good dog!");
        }

        return new GenericResponse(true, "Sign up successful! Please check your email to confirm your account.");
    }
}
