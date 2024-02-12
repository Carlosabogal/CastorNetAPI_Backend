using TestNetCore_Castor.Entities;

namespace TestNetCore_Castor.Repository
{
    public interface IEmployeeRepository
    {
        //   Task<List<Employee>> GetAll();
        // Task<Employee> GetById(int id);
        Task<bool> Insert(Employee employee);
        // Task Update(Employee employee);
        // Task Delete(int id);
        Task<bool> UpdateEmployeeById(int id, Employee employee);
        Task<List<Employee>> GetAllEmployees();
        Task<Employee> GetById(int id);
        Task<bool> DeleteEmployeeById(int id);
    }
}
