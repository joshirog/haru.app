using Haru.App.Features.Authentication.ForgotPassword.DTOs;
using Haru.App.Common.Responses;
using System.Threading.Tasks;

namespace Haru.App.Features.Authentication.Services;

public interface IForgotPasswordService
{
    Task<GenericResponse> SendPasswordResetLinkAsync(ForgotPasswordRequestDto request);
}
