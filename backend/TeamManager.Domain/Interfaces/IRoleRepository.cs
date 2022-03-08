using TeamManager.Domain.Entities;

namespace TeamManager.Domain.Interfaces;

public interface IRoleRepository
{
    
    Task<Role> GetById(int? id);
    Task<Role> Create(Role role);
    Task<Role> Update(Role role);
    Task<Role> Remove(Role role);
}