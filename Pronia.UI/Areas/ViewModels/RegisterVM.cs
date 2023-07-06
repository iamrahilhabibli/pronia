
using System.ComponentModel.DataAnnotations;

namespace Pronia.UI.Areas.ViewModels
{
    public class RegisterVM
    {
        [Required]
        public string Fullname { get; set; } = null!;
        [Required]
        public string Username { get; set; } = null!;
        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
        [Required, DataType(DataType.Password), Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
    }
}
