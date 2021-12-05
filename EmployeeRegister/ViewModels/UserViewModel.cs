using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using EmployeeRegister.Common.Enums;

namespace EmployeeRegister.ViewModels
{
    public class UserViewModel
    {
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        
        [Required]
        public string Login { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        [Compare("ConfirmPassword")]
        public string Password { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        
        public Role Role { get; set; }
    }
}