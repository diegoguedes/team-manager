using TeamManager.Application.DTOs;

namespace TeamManager.Application.Interfaces;

public interface IEmployeeService
{
    Task<EmployeeDTO> GetById(int? id);

    Task Add(EmployeeDTO employeeDto);
    Task Update(EmployeeDTO employeeDto);
    Task Remove(int? id);

}