using DataAccess.Data;
using DataAccess.DataModels;
using Models.DTOs.UserProfile;

namespace Business.Mappers
{
    public static class UserProfilesMapper
    {
        public static UserProfile Map(UserProfileDto userProfileDto, Guid userId)
        {
            return new UserProfile
            {
                Id = userId,
                IdentityUserId = userId.ToString(),
                FirstName = userProfileDto.FirstName,
                LastName = userProfileDto.LastName,
                Bio = userProfileDto.Bio,
                DisplayPic = userProfileDto.DisplayPic,
            };
        }

        public static UserProfileDto Map(UserProfile userProfile)
        {
            return new UserProfileDto
            {
                Id = userProfile.Id,
                IdentityUserId = userProfile.IdentityUserId,
                FirstName = userProfile.FirstName,
                LastName = userProfile.LastName,
                Bio = userProfile.Bio,
                DisplayPic = userProfile.DisplayPic,
            };
        }
    }
}
