using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EmployeeRegister.ViewModels
{
    public class UserLoginViewModel
    {
        [Required]
        public string Login { get; set; }
        
        [Required]
        public string Password { get; set; }
    }
}