using Haru.App.Features.Authentication.Services;
using Haru.App.Features.Authentication.TwoFactorAuth.DTOs;
using Haru.App.Common.Responses;
using System.Threading.Tasks;

namespace Haru.App.Features.Authentication.Services.Mock;

public class TwoFactorAuthService : ITwoFactorAuthService
{
    private const string Mock2FACode = "112233"; // Example 2FA code

    public async Task<GenericResponse> VerifyCodeAsync(VerifyTwoFactorCodeRequestDto request)
    {
        await Task.Delay(500); // Simulate network latency

        if (string.IsNullOrWhiteSpace(request.Code))
        {
            return new GenericResponse(false, "2FA code cannot be empty.");
        }

        // In a real app, you'd verify the code against a user-specific setup.
        // For this mock, we'll use a generic code, perhaps tied to a specific mock user if needed later.
        if (request.Code == Mock2FACode)
        {
            System.Diagnostics.Debug.WriteLine($"Mock: 2FA code verified successfully for UserId {request.UserId}.");
            return new GenericResponse(true, "2FA code verified successfully!");
        }
        else
        {
            return new GenericResponse(false, "Invalid 2FA code.");
        }
    }
}
