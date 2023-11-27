using System.ComponentModel.DataAnnotations;

namespace WebApiEF.Models
{
    public class AddRoleModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Role { get; set; }
    }
}
