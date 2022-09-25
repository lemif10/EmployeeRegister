using System.ComponentModel.DataAnnotations;
using EmployeeRegister.Common.Enums;

namespace EmployeeRegister.ViewModels
{
    public class UserViewModel
    {
        [Required]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        [MinLength(5)]
        [StringLength(100)]
        public string Email { get; set; }
        
        [Required]
        [MinLength(5)]
        [StringLength(30)]
        public string Login { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        [StringLength(20)]
        [MinLength(5)]
        [Compare("ConfirmPassword")]
        public string Password { get; set; }
        
        [Required]
        [MinLength(5)]
        [StringLength(20)]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        
        public Role Role { get; set; }
    }
}