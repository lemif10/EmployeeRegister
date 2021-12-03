using System.ComponentModel.DataAnnotations;

namespace EmployeeRegister.Common.Models
{
    public class Contact
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(50)]
        public string PhoneNumber { get; set; }
        
        [Required]
        [StringLength(100)]
        public string Email { get; set; }
    }
}