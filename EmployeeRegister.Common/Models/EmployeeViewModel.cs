using System.Collections.Generic;
using EmployeeRegister.Common.Enums;

namespace EmployeeRegister.Common.Models
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }
        
        public string FullName { get; set; }
        
        public Department Department { get; set; }
        
        public Contact Contact { get; set; }

        public string Address { get; set; }
        
        public FamilyStatus FamilyStatus { get; set; }

        public decimal WorkExperience { get; set; }
        
        public decimal Salary { get; set; }
        
        public List<Department> Departments { get; set; }
    }
}