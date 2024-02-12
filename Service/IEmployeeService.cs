using TestNetCore_Castor.Entities;

namespace TestNetCore_Castor.Service
{
    public interface IEmployeeService
    {
        Task<bool> InsertEmployee(Employee employee);
        Task<bool> UpdateEmployeeById(int id, Employee employee);

        Task<List<Employee>> GetAllEmployees();
        Task<Employee> GetEmployeeById(int id);
        Task<bool> DeleteEmployeeById(int id);
    }
}
