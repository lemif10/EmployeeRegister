using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using EmployeeRegister.Common.Enums;

namespace EmployeeRegister.ViewModels
{
    public class UserViewModel
    {
        [Required]
        public string Email { get; set; }
        
        [Required]
        public string Login { get; set; }
        
        [Required]
        [PasswordPropertyText]
        public string Password { get; set; }
        
        public Role Role { get; set; }
    }
}