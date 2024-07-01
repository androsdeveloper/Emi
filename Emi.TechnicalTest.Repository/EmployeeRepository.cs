using Emi.TechnicalTest.BusinessLogic.Model;
using Emi.TechnicalTest.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;

namespace Emi.TechnicalTest.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeManagementDbContext _context;

        public EmployeeRepository(EmployeeManagementDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Employee>> GetAll()
        {
            var employees = await _context.Employees
                .Include(e => e.Department)
                .Include(e => e.EmployeeProjects)
                    .ThenInclude(ep => ep.Project)
                .ToListAsync();

            return employees;
        }

        public async Task<Employee> GetById(int id)
        {
            var employee = await _context.Employees
                .Include(e => e.Department)
                .Include(e => e.EmployeeProjects)
                    .ThenInclude(ep => ep.Project)
                .FirstOrDefaultAsync(e => e.EmployeeId == id);
            return employee;
        }

        public async Task<IEnumerable<PositionHistory>> Getbonus()
        {
            var history = await _context.PositionHistories
                .Include(e => e.Employee).Where(c => c.EndDate == null).ToListAsync()
                ;

            return history;
        }

        public async Task<int> Add(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();

            return employee.EmployeeId;
        }

        public async Task Update(Employee employee)
        {
            _context.Entry(employee).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
        }

        public async Task<IList<Employee>> GetEmployeesByDepartmentAndProject(int departmentId)
        {
            return await _context.Employees
                .Where(e => e.DepartmentId == departmentId && e.EmployeeProjects.Any())
                .Include(e => e.Department)
                .Include(e => e.EmployeeProjects)
                    .ThenInclude(ep => ep.Project)
                .ToListAsync();
        }
    }
}
