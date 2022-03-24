using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTOs.UserProfile
{
    public class UserProfileDto
    {
        public Guid Id { get; set; }
        public string IdentityUserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DisplayPic { get; set; }
        public string Bio { get; set; }
        public DateTime CreateOn { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedOn { get; set; }
        public byte[] ImageContent { get; set; }
    }
}
