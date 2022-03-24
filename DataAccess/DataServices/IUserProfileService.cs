using Models.DTOs.UserProfile;

namespace DataAccess.DataServices
{
    public interface IUserProfileService
    {
        Task<UserProfileDto> Get(Guid userId);
        Task<UserProfileDto> Create(Guid userId, UserProfileDto userProfileDto);
        Task<UserProfileDto> Update(Guid userId, UserProfileDto userProfileDto);
    }
}
