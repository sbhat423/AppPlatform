using DataAccess.Data;
using Models.DTOs.UserProfile;

namespace Business.Mappers
{
    public static class UserProfilesMapper
    {
        public static UserProfile Map(UserProfileDto userProfileDto, string userId)
        {
            return new UserProfile
            {
                UserId = userId,
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
                UserId = userProfile.UserId,
                FirstName = userProfile.FirstName,
                LastName = userProfile.LastName,
                Bio = userProfile.Bio,
                DisplayPic = userProfile.DisplayPic,
            };
        }
    }
}
