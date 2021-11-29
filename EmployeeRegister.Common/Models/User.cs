namespace EmployeeRegister.Common.Models
{
    public class User
    {
        public int Id { get; set; }
        
        public string Login { get; set; }
        
        public string Password { get; set; } //TODO изменить когда скинут скинут ссылки.

        public int Role { get; set; } 
    }
}