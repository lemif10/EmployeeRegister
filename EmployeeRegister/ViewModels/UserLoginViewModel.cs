using System.ComponentModel.DataAnnotations;

namespace EmployeeRegister.ViewModels
{
    public class UserLoginViewModel
    {
        [Required]
        public string Login { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}