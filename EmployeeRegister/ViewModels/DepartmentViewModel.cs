using System.ComponentModel.DataAnnotations;

namespace EmployeeRegister.ViewModels
{
    public class DepartmentViewModel
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        
        [Required]
        [StringLength(50)]
        public string PhoneNumber { get; set; }
       
        [Required]
        [StringLength(100)]
        public string Address { get; set; }
        
        [Required]
        [StringLength(300)]
        public string Description { get; set; }
    }
}