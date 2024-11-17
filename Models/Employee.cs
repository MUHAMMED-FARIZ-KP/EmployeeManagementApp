using System;
namespace EmployeeManagementApp
{
    public class Employee
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Department { get; set; }
        public DateTime DateOfJoining { get; set; }
    }
}