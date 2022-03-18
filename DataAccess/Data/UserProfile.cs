using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data
{
    public class UserProfile
    {
        [Key, ForeignKey("User")]
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? DisplayPic { get; set; }
        public string? Bio { get; set; }
        public DateTime CreateOn { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedOn { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
