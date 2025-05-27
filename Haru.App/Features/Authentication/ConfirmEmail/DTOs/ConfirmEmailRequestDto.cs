namespace Haru.App.Features.Authentication.ConfirmEmail.DTOs;

public class ConfirmEmailRequestDto
{
    public string Email { get; set; }
    public string ConfirmationCode { get; set; }
}
