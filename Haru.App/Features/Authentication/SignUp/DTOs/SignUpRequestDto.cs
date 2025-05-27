namespace Haru.App.Features.Authentication.SignUp.DTOs;

public class SignUpRequestDto
{
    public string Email { get; set; }
    public string Phone { get; set; } // Assuming phone is a string
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
}
