using System.ComponentModel.DataAnnotations;

namespace Pronia.UI.Areas.ViewModels
{
    public class LoginVM
    {
        [Required,DataType(DataType.EmailAddress)]
        public string Email { get; set; } = null!;
        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
        public bool RememberMe { get; set; }    
    }
}
