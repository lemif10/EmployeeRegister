﻿using System.ComponentModel.DataAnnotations;

namespace EmployeeRegister.Common.Models
{
    public class Contact
    {
        public int Id { get; set; }
        
        public string PhoneNumber { get; set; }
        
        public string Email { get; set; }
    }
}