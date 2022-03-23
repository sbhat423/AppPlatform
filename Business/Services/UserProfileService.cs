using Business.Interfaces;
using Business.Mappers;
using DataAccess.Data;
using DataAccess.DataServices;
using Models.DTOs.UserProfile;

namespace Business.Services
{
    public class UserProfileService : IUserProfileService
    {
        private readonly ApplicationDbContext _db;
        private readonly IFileStorageService _azureStorageService;

        public UserProfileService(ApplicationDbContext db,
            IFileStorageService azureStorageService)
        {
            _db = db;
            _azureStorageService = azureStorageService;
        }

        public async Task<UserProfileDto> Create(string userId, UserProfileDto userProfileDto)
        {
            try
            {
                if (userProfileDto.ImageContent != null)
                {
                    userProfileDto.DisplayPic = await _azureStorageService.SaveFile(userProfileDto.ImageContent, ".jpg", "profiles");
                }
                var dbUserProfile = UserProfilesMapper.Map(userProfileDto, userId);
                _db.UserProfiles.Add(dbUserProfile);
                await _db.SaveChangesAsync();
                return UserProfilesMapper.Map(dbUserProfile);
            }
            catch (Exception)
            {
                throw;
            }
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

            if (userProfileDto.ImageContent != null)
            {
                if (userProfileDto.DisplayPic == null)
                {
                    userProfileDto.DisplayPic = await _azureStorageService.SaveFile(userProfileDto.ImageContent, ".jpg", "profiles");
                }
                else
                { 
                    userProfileDto.DisplayPic = await _azureStorageService.EditFile(
                        userProfileDto.ImageContent, ".jpg", "profiles", userProfileDto.DisplayPic);
                }
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
