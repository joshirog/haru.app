using Haru.App.Features.Authentication.SignIn.DTOs;
using System.Threading.Tasks;

namespace Haru.App.Features.Authentication.Services; // Updated namespace

public interface ISignInService
{
    Task<SignInResponseDto> SignInAsync(SignInRequestDto request);
}
