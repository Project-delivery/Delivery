using System.ComponentModel.DataAnnotations;

namespace Delivery.Models
{
    public class EditUserViewModel
    {
        public string Id { get; set; }

        [Required]
        public string Login { get; set; }

        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public IList<string> Roles { get; set; }
    }


}
