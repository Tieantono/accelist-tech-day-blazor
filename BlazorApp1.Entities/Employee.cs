using System;
using System.ComponentModel.DataAnnotations;

namespace BlazorApp1.Entities
{
    public class Employee
    {
        [Key]
        public Guid EmployeeID { set; get; }

        [Required]
        public string Name { set; get; }

        [Required]
        public string Email { set; get; }
    }
}
