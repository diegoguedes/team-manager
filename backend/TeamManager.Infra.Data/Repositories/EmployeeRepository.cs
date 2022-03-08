using Microsoft.EntityFrameworkCore;
using TeamManager.Domain.Entities;
using TeamManager.Domain.Interfaces;
using TeamManager.Infra.Data.Context;

namespace TeamManager.Infra.Data.Repositories;

public class EmployeeRepository : IEmployeeRepository
{
    private ApplicationDbContext _employeeContext;
    public EmployeeRepository(ApplicationDbContext context)
    {
        _employeeContext = context;
    }

    public async Task<Employee> GetById(int? id)
    {
        return await _employeeContext.Employee.FindAsync(id);
    }

    public async Task<Employee> Create(Employee employee)
    {
        _employeeContext.Add(employee);
        await _employeeContext.SaveChangesAsync();
        return employee;
    }

    public async Task<Employee> Update(Employee employee)
    {
        _employeeContext.Update(employee);
        await _employeeContext.SaveChangesAsync();
        return employee;
    }

    public async Task<Employee> Remove(Employee employee)
    {
        _employeeContext.Remove(employee);
        await _employeeContext.SaveChangesAsync();
        return employee;
    }
    
    public async Task<Employee> GetRole(int? id)
    {
        return await _employeeContext.Employee.Include(e => e.Role)
            .SingleAsync(r => r.Id == id);
    }
    
}