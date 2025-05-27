namespace Haru.App.Features.Authentication.TwoFactorAuth.DTOs;

public class VerifyTwoFactorCodeRequestDto
{
    public string UserId { get; set; } // Or another identifier like username/email
    public string Code { get; set; }
}
