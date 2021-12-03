using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EmployeeRegister.Common.Enums;
using EmployeeRegister.Common.Models;

namespace EmployeeRegister.Common.ViewModels
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(100)]
        public string FullName { get; set; }
        
        public Department Department { get; set; }
        
        public Contact Contact { get; set; }

        [Required]
        [StringLength(100)]
        public string Address { get; set; }
        
        public FamilyStatus FamilyStatus { get; set; }

        [Required]
        public decimal WorkExperience { get; set; }
        
        [Required]
        public decimal Salary { get; set; }
        
        public IEnumerable<Department> Departments { get; set; }
    }
}