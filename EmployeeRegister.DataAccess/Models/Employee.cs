namespace EmployeeRegister.DataAccess.Models
{
    public class Employee
    {
        public int Id { get; set; }
        
        public string FullName { get; set; }
        
        public int DepartmentId { get; set; }
        
        public int ContactId { get; set; }
        
        public string Address { get; set; }
        
        public int FamilyStatus { get; set; }

        public decimal WorkExperience { get; set; }
        
        //TODO тут будет поле для фотографий, просто разберуюсь с их хранением и выводом)

        public decimal Salary { get; set; }
    }
}