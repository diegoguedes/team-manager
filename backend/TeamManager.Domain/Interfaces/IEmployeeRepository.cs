using TeamManager.Domain.Entities;

namespace TeamManager.Domain.Interfaces;

public interface IEmployeeRepository
{
    
    Task<Employee> GetById(int? id);
    Task<Employee> Create(Employee employee);
    Task<Employee> Update(Employee employee);
    Task<Employee> Remove(Employee employee);
    Task<Employee> GetRole(int? id);
}