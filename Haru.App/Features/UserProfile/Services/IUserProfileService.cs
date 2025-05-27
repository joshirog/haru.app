using Haru.App.Features.UserProfile.DTOs;
using System.Threading.Tasks;

namespace Haru.App.Features.UserProfile.Services;

public interface IUserProfileService
{
    Task<UserProfileDto> GetUserProfileAsync(string userId); 
    // We'll need a way to get userId, perhaps from a simulated auth state later.
    // For now, the mock can return a default profile.
}
