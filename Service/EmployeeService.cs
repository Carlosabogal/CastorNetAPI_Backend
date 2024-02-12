using TestNetCore_Castor.Entities;
using TestNetCore_Castor.Repository;

namespace TestNetCore_Castor.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<bool> InsertEmployee(Employee employee)
        {
            try
            {
                return await _employeeRepository.Insert(employee);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in EmployeeService.InsertEmployee: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> UpdateEmployeeById(int id, Employee employee)
        {
            try
            {
                return await _employeeRepository.UpdateEmployeeById(id, employee);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in EmployeeService.UpdateEmployeeById: {ex.Message}");
                throw; 
            }
        }


    
        public async Task<List<Employee>> GetAllEmployees()
        {
            try
            {
                return await _employeeRepository.GetAllEmployees();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in EmployeeService.GetAllEmployees: {ex.Message}");
                throw; 
            }
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            try
            {
                return await _employeeRepository.GetById(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in EmployeeService.GetEmployeeById: {ex.Message}");
                throw; 
            }
        }



        public async Task<bool> DeleteEmployeeById(int id)
        {
            try
            {
                return await _employeeRepository.DeleteEmployeeById(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in EmployeeService.DeleteEmployeeById: {ex.Message}");
                throw;
            }
        }

    }
}
