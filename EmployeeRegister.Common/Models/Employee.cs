namespace EmployeeRegister.Common.Models
{
    public class Employee
    {
        public int Id { get; set; }

        public string Photo { get; set; }
        
        public string FullName { get; set; }
        
        public int DepartmentId { get; set; }

        public string Address { get; set; }
        
        public int FamilyStatus { get; set; }

        public decimal WorkExperience { get; set; }

        public decimal Salary { get; set; }
    }
}