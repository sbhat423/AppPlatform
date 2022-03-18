using Business.Mappers;
using DataAccess.Data;
using DataAccess.DataServices;
using Models.DTOs.UserProfile;

namespace Business.Services
{
    public class UserProfileService : IUserProfileService
    {
        private readonly ApplicationDbContext _db;

        public UserProfileService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<UserProfileDto> Create(string userId, UserProfileDto userProfileDto)
        {
            var dbUserProfile = UserProfilesMapper.Map(userProfileDto, userId);
            _db.UserProfiles.Add(dbUserProfile);
            await _db.SaveChangesAsync();

            return UserProfilesMapper.Map(dbUserProfile);
        }

        public async Task<UserProfileDto> Get(string userId)
        {
            var dbUserProfile = await _db.UserProfiles.FindAsync(userId);
            if (dbUserProfile == null)
            {
                throw new Exception("UserProfileId not found");
            }

            return UserProfilesMapper.Map(dbUserProfile);
        }

        public async Task<UserProfileDto> Update(string userId, UserProfileDto userProfileDto)
        {
            var dbUserProfile = await _db.UserProfiles.FindAsync(userId);
            if (dbUserProfile == null)
            {
                throw new Exception("UserProfileId not found");
            }

            dbUserProfile.FirstName = userProfileDto.FirstName;
            dbUserProfile.LastName = userProfileDto.LastName;
            dbUserProfile.Bio = userProfileDto.Bio;
            dbUserProfile.DisplayPic = userProfileDto.DisplayPic;
            dbUserProfile.UpdatedOn = DateTime.UtcNow;

            _db.UserProfiles.Update(dbUserProfile);
            await _db.SaveChangesAsync();

            return UserProfilesMapper.Map(dbUserProfile);
        }
    }
}
