using System.ComponentModel.DataAnnotations;

namespace EmployeeRegister.ViewModels
{
    public class ContactViewModel
    {
        [Required]
        [StringLength(50)]
        public string PhoneNumber { get; set; }
                
        [Required]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        [StringLength(100)]
        public string Email { get; set; }
    }
}