using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Delivery.Entities
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [MaxLength(50)]
        public string Login { get; set; }

        [Required]
        [MaxLength(50)]
        public string Password { get; set; }
    }
}
