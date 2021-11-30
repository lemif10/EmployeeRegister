namespace EmployeeRegister.Common.Models
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }
        
        public string FullName { get; set; }
        
        public Department Department { get; set; }
        
        public Contact Contact { get; set; }

        public string Address { get; set; }
        
        public string FamilyStatus { get; set; }

        public decimal WorkExperience { get; set; }
        
        //TODO тут будет поле для фотографий, просто разберуюсь с их хранением и выводом)

        public decimal Salary { get; set; }
    }
}