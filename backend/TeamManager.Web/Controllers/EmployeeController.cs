using Microsoft.AspNetCore.Mvc;
using TeamManager.Application.DTOs;
using TeamManager.Application.Interfaces;

namespace TeamManager.Web.Controllers;

[ApiController]
[Route("api/team-manager/v1/[controller]")]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeService _employeeService;
    
    public EmployeeController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<EmployeeDTO>> GetEmployee(int? id)
    {
        var employeeDto = await _employeeService.GetById(id);

        return employeeDto is not null? Ok(employeeDto):NotFound("Employee not found");
    }
    
    [HttpPost]
    public async Task<ActionResult> CreateEmployee(EmployeeDTO employee)
    {
        if(employee is null)
            return BadRequest("Invalid Data");
        
        await _employeeService.Add(employee);
        
        return  new CreatedAtRouteResult("", new { id = employee.Id }, 
            employee);;
    }
    
    [HttpPut]
    [Route("{id:int}")]
    public async Task<ActionResult> UpdateEmployee(int id, EmployeeDTO employeeDto)
    {
        if(id != employeeDto.Id)
            return BadRequest();
        
        if(employeeDto is null)
            return BadRequest();
       
        await _employeeService.Update(employeeDto);
        
        return Ok(employeeDto);

    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<EmployeeDTO>> Delete(int id)
    {
        var employee = await _employeeService.GetById(id);

        if (employee is null)
        {
            return NotFound("Employee not found");
        }

        await _employeeService.Remove(id);

        return Ok(employee);
    }

    
}