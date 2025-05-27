using Haru.App.Features.Authentication.Services;
using Haru.App.Features.Authentication.ConfirmEmail.DTOs;
using Haru.App.Common.Responses;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations; // For EmailAddressAttribute (if used for validation here)

namespace Haru.App.Features.Authentication.Services.Mock;

public class ConfirmEmailService : IConfirmEmailService
{
    private const string MockConfirmationCode = "123456"; // Example code

    public async Task<GenericResponse> ConfirmEmailAsync(ConfirmEmailRequestDto request)
    {
        await Task.Delay(500); // Simulate network latency

        if (string.IsNullOrWhiteSpace(request.ConfirmationCode))
        {
            return new GenericResponse(false, "Confirmation code cannot be empty.");
        }

        if (request.ConfirmationCode == MockConfirmationCode)
        {
            System.Diagnostics.Debug.WriteLine($"Mock: Email {request.Email} confirmed successfully with code {request.ConfirmationCode}.");
            return new GenericResponse(true, "Email confirmed successfully!");
        }
        else
        {
            return new GenericResponse(false, "Invalid confirmation code.");
        }
    }

    public async Task<GenericResponse> ResendConfirmationCodeAsync(ResendEmailCodeRequestDto request)
    {
        await Task.Delay(1000); // Simulate network latency
        
        if (string.IsNullOrWhiteSpace(request.Email) || !new EmailAddressAttribute().IsValid(request.Email))
        {
             return new GenericResponse(false, "Please provide a valid email address.");
        }
        System.Diagnostics.Debug.WriteLine($"Mock: New confirmation code sent to {request.Email}. (It's still {MockConfirmationCode} for mock purposes).");
        return new GenericResponse(true, "A new confirmation code has been sent to your email address.");
    }
}
