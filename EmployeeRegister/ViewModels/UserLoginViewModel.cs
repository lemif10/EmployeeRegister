using System.ComponentModel.DataAnnotations;

namespace EmployeeRegister.ViewModels
{
    public class UserLoginViewModel
    {
        [Required]
        [StringLength(30)]
        [MinLength(5)]
        public string Login { get; set; }
        
        [Required]
        [MinLength(5)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}