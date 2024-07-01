
namespace Emi.TechnicalTest.Repository.Interfaces
{
    using Emi.TechnicalTest.BusinessLogic.Model;

    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAll();
        Task<Employee> GetById(int id);
        Task<int> Add(Employee employee);
        Task Update(Employee employee);
        Task Delete(int id);
        Task<IEnumerable<PositionHistory>> Getbonus();
        Task<IList<Employee>> GetEmployeesByDepartmentAndProject(int departmentId);
    }
}
