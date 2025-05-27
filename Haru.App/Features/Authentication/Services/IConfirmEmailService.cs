using Haru.App.Features.Authentication.ConfirmEmail.DTOs;
using Haru.App.Common.Responses;
using System.Threading.Tasks;

namespace Haru.App.Features.Authentication.Services;

public interface IConfirmEmailService
{
    Task<GenericResponse> ConfirmEmailAsync(ConfirmEmailRequestDto request);
    Task<GenericResponse> ResendConfirmationCodeAsync(ResendEmailCodeRequestDto request);
}
