using EmployeeRegister.Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace EmployeeRegister.ViewModels
{
    public class UserEditViewModel
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

        public Role Role { get; set; }
    }
}
