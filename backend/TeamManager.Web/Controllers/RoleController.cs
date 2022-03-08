using Microsoft.AspNetCore.Mvc;
using TeamManager.Application.DTOs;
using TeamManager.Application.Interfaces;

namespace TeamManager.Web.Controllers;

[ApiController]
[Route("api/team-manager/v1/[controller]")]
public class RoleController : ControllerBase
{
    private readonly IRoleService _roleService;
    
    public RoleController(IRoleService roleService)
    {
        _roleService = roleService;
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<RoleDTO>> GetRole(int? id)
    {
        var roleDto = await _roleService.GetById(id);

        return roleDto is not null? Ok(roleDto):NotFound("Role not found");
    }

    [HttpPost]
    public async Task<ActionResult> CreateRole(RoleDTO role)
    {
        if(role is null)
            return BadRequest("Invalid Data");
        
        await _roleService.Add(role);
        
        return  new CreatedAtRouteResult("", new { id = role.Id }, 
            role);;
    }
    
    [HttpPut]
    [Route("{id:int}")]
    public async Task<ActionResult> UpdateRole(int id, RoleDTO roleDto)
    {
        if(id != roleDto.Id)
            return BadRequest();
        
        if(roleDto is null)
            return BadRequest();
       
        await _roleService.Update(roleDto);
        
        return Ok(roleDto);

    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<RoleDTO>> Delete(int id)
    {
        var role = await _roleService.GetById(id);

        if (role is null)
        {
            return NotFound("Role not found");
        }

        await _roleService.Remove(id);

        return Ok(role);
    }
    
}