using Models.DTOs.UserProfile;

namespace DataAccess.DataServices
{
    public interface IUserProfileService
    {
        Task<UserProfileDto> Get(string userId);
        Task<UserProfileDto> Create(string userId, UserProfileDto userProfileDto);
        Task<UserProfileDto> Update(string userId, UserProfileDto userProfileDto);
    }
}
