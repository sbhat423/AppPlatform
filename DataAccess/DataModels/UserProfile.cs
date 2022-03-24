using DataAccess.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.DataModels
{
    public class UserProfile
    {
        [Key]
        public Guid Id { get; set; }
        [ForeignKey("User")]
        public string IdentityUserId { get; set; }
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        public string? DisplayPic { get; set; }
        public string? Bio { get; set; }
        public DateTime CreateOn { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedOn { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
