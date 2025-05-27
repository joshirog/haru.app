namespace Haru.App.Features.UserProfile.DTOs;

public class UserProfileDto
{
    public string UserId { get; set; } // Added UserId
    public string Email { get; set; }
    public string Username { get; set; }
    public string ProfileImageUrl { get; set; } // Can be a placeholder URL initially
    public string FullName { get; set; } // Added FullName
    public DateOnly? DateOfBirth { get; set; } // Added DateOfBirth, nullable DateOnly
}
