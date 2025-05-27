using Haru.App.Features.Authentication.TwoFactorAuth.DTOs;
using Haru.App.Common.Responses;
using System.Threading.Tasks;

namespace Haru.App.Features.Authentication.Services;

public interface ITwoFactorAuthService
{
    Task<GenericResponse> VerifyCodeAsync(VerifyTwoFactorCodeRequestDto request);
}
