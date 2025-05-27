using Haru.App.Features.Authentication.SignUp.DTOs;
using Haru.App.Common.Responses; // For GenericResponse
using System.Threading.Tasks;

namespace Haru.App.Features.Authentication.Services;

public interface ISignUpService
{
    Task<GenericResponse> SignUpAsync(SignUpRequestDto request);
}
