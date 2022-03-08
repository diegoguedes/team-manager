using TeamManager.Application.DTOs;

namespace TeamManager.Application.Interfaces;

public interface IRoleService
{
    Task<RoleDTO> GetById(int? id);

    Task Add(RoleDTO roleDto);
    Task Update(RoleDTO roleDto);
    Task Remove(int? id);

}