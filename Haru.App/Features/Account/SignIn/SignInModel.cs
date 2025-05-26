namespace Haru.App.Features.Account.SignIn;

public class SignInRequest
{
    public string Username { get; set; }
    
    public string Password { get; set; }
}

public class SignInResponse
{
    public string Token { get; set; }
}