﻿
namespace Emi.TechnicalTest.BusinessLogic.Dto
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public decimal Salary { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public List<Project> Projects { get; set; }
    }
}
