using model = Emi.TechnicalTest.BusinessLogic.Model;
using dto = Emi.TechnicalTest.BusinessLogic.Dto;
using Emi.TechnicalTest.Repository.Interfaces;
using Emi.TechnicalTest.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Emi.TechnicalTest.BusinessLogic.Dto;

namespace Emi.TechnicalTest.Services
{
    public class EmployeeService:IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public async Task<IEnumerable<dto.Employee>> GetAllEmployees()
        {
            var result = await _employeeRepository.GetAll();

            if(result == null)
            {
                return null;
            }

            var employeeDtos = result.Select(e => new dto.Employee
            {
                EmployeeId = e.EmployeeId,
                Name = e.Name,
                DepartmentId = e.DepartmentId,
                Department = new dto.Department
                {
                    Id = e.Department.Id,
                    Name = e.Department.Name
                },
                Projects = e.EmployeeProjects.Select(ep => new dto.Project
                {
                    Id = ep.Project.Id,
                    Name = ep.Project.ProjectName
                }).ToList()
            }).ToList();

            return employeeDtos;
        }

        public async Task<dto.Employee> GetEmployeeById(int id)
        {
            var employee = await _employeeRepository.GetById(id);

            if(employee == null)
            {
                return null;
            }

            var employeeResult = new dto.Employee
            {
                EmployeeId = employee.EmployeeId,
                Name = employee.Name,
                DepartmentId = employee.DepartmentId,
                Department = new dto.Department
                {
                    Id = employee.Department.Id,
                    Name = employee.Department.Name
                },
                Projects = employee.EmployeeProjects.Select(ep => new dto.Project
                {
                    Id = ep.Project.Id,
                    Name = ep.Project.ProjectName
                }).ToList()
            };

            return employeeResult;
        }

        public async Task<int> AddEmployee(dto.Employee employee)
        {

            var employeeModel = new model.Employee
            {
                Name = employee.Name,
                Salary = employee.Salary,
                DepartmentId = employee.DepartmentId
            };

            return await _employeeRepository.Add(employeeModel);
        }

        public async Task UpdateEmployee(dto.Employee employee)
        {

            var modelEmployee = await _employeeRepository.GetById(employee.EmployeeId);



            modelEmployee.Name = employee.Name;
            modelEmployee.Salary = employee.Salary;
            modelEmployee.EmployeeId = employee.EmployeeId;
            modelEmployee.DepartmentId = employee.DepartmentId;

            await _employeeRepository.Update(modelEmployee);
        }

        public async Task DeleteEmployee(int id)
        {

            await _employeeRepository.Delete(id);
        }

        public async Task<IEnumerable<dto.EmployeeBonus>> GetBonus()
        {
            var result = await _employeeRepository.Getbonus();

            if (result == null)
            {
                return null;
            }

            var employeeDtos = result.Select(e => new dto.EmployeeBonus
            {
                EmployeeName = e.Employee.Name,
                TypeEmployee = e.IsManager ? "Manager" : "Regular",
                Salary = e.Employee.Salary,
                CurrentPosition = e.Position,
                Bonus = e.IsManager ? (Convert.ToDouble(e.Employee.Salary) * 0.20) : (Convert.ToDouble(e.Employee.Salary) * 0.10),
                StartDate = e.StartDate.ToString()
            }).ToList();

            return employeeDtos;
        }

        public async Task<IList<dto.Employee>> GetEmployeesByDepartmentAndProject(int departmentId)
        {
            var result = await _employeeRepository.GetEmployeesByDepartmentAndProject(departmentId);

            if (result == null)
            {
                return null;
            }

            var employeeDtos = result.Select(e => new dto.Employee
            {
                EmployeeId = e.EmployeeId,
                Name = e.Name,
                DepartmentId = e.DepartmentId,
                Department = new dto.Department
                {
                    Id = e.Department.Id,
                    Name = e.Department.Name
                },
                Projects = e.EmployeeProjects.Select(ep => new dto.Project
                {
                    Id = ep.Project.Id,
                    Name = ep.Project.ProjectName
                }).ToList()
            }).ToList();

            return employeeDtos;
        }
    }
}
