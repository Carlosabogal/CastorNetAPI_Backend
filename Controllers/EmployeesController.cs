using Microsoft.AspNetCore.Mvc;
using System;
using TestNetCore_Castor.DTO;
using TestNetCore_Castor.Entities;
using TestNetCore_Castor.Service;

namespace TestNetCore_Castor
{

    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        [HttpPost]
        public async Task<IActionResult> CreateEmployee([FromForm] EmployeeDTO employeeDTO)
        {
            try
            {
                byte[] photo = null;
                if (employeeDTO.Photo != null && employeeDTO.Photo.Length > 0)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await employeeDTO.Photo.CopyToAsync(memoryStream);
                        photo = memoryStream.ToArray();
                    }
                }

                var employee = new Employee
                {
                    Identification = employeeDTO.Identification,
                    Name = employeeDTO.Name,
                    Photo = photo,
                    HireDate = employeeDTO.HireDate,
                    PositionId = employeeDTO.PositionId
                };

                var result = await _employeeService.InsertEmployee(employee);

                if (result)
                {
                    return Ok("Employee created successfully.");
                }
                else
                {
                    return BadRequest("Failed to create employee.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in CreateEmployee: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, [FromForm] EmployeeDTO employeeDTO)
        {
            try
            {
                byte[] photo = null;
                if (employeeDTO.Photo != null && employeeDTO.Photo.Length > 0)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await employeeDTO.Photo.CopyToAsync(memoryStream);
                        photo = memoryStream.ToArray();
                    }
                }

                var employee = new Employee
                {
                    Identification = employeeDTO.Identification,
                    Name = employeeDTO.Name,
                    Photo = photo,
                    HireDate = employeeDTO.HireDate,
                    PositionId = employeeDTO.PositionId
                };

                var result = await _employeeService.UpdateEmployeeById(id, employee);

                if (result)
                {
                    return Ok("Employee updated successfully.");
                }
                else
                {
                    return BadRequest("Failed to update employee.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in UpdateEmployee: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            try
            {
                var employee = await _employeeService.GetEmployeeById(id);
                if (employee == null)
                {
                    return NotFound("Employee not found.");
                }
                return Ok(employee);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetEmployeeById: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

       

        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            try
            {
                var employees = await _employeeService.GetAllEmployees();
                return Ok(employees);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetAllEmployees: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            try
            {
                var result = await _employeeService.DeleteEmployeeById(id);
                if (result)
                {
                    return Ok("Employee deleted successfully.");
                }
                else
                {
                    return NotFound("Employee not found or failed to delete.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in DeleteEmployee: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
 }
