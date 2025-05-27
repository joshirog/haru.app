using Haru.App.Features.Authentication.Services; // For IForgotPasswordService
using Haru.App.Features.Authentication.ForgotPassword.DTOs;
using Haru.App.Common.Responses;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations; // For EmailAddressAttribute

namespace Haru.App.Features.Authentication.Services.Mock;

public class ForgotPasswordService : IForgotPasswordService
{
    public async Task<GenericResponse> SendPasswordResetLinkAsync(ForgotPasswordRequestDto request)
    {
        await Task.Delay(1000); // Simulate network latency

        if (string.IsNullOrWhiteSpace(request.Email) || !new EmailAddressAttribute().IsValid(request.Email))
        {
            return new GenericResponse(false, "Please enter a valid email address.");
        }

        // Simulate sending a link
        System.Diagnostics.Debug.WriteLine($"Mock: Password reset link sent to {request.Email}");
        return new GenericResponse(true, "If an account exists for this email, a password reset link has been sent.");
    }
}
