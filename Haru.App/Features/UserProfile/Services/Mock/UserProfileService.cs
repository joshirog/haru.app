using Haru.App.Features.UserProfile.DTOs;
using Haru.App.Features.UserProfile.Services;
using System; // For DateOnly
using System.Threading.Tasks;

namespace Haru.App.Features.UserProfile.Services.Mock;

public class UserProfileService : IUserProfileService
{
    public async Task<UserProfileDto> GetUserProfileAsync(string userId)
    {
        await Task.Delay(500); // Simulate network latency

        // Return a default mock profile. userId is ignored for now in mock.
        return new UserProfileDto
        {
            UserId = userId ?? "mockUserId123",
            Email = "shiba.fan@example.com",
            Username = "ShibaFan1",
            ProfileImageUrl = "shiba_profile_placeholder.png", // Placeholder image
            FullName = "Haru Inu",
            DateOfBirth = new DateOnly(2022, 5, 10) 
        };
    }
}
