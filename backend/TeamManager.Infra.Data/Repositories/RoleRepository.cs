using TeamManager.Domain.Entities;
using TeamManager.Domain.Interfaces;
using TeamManager.Infra.Data.Context;

namespace TeamManager.Infra.Data.Repositories;

public class RoleRepository : IRoleRepository
{
    private ApplicationDbContext _roleContext;
    public RoleRepository(ApplicationDbContext context)
    {
        _roleContext = context;
    }

    public async Task<Role> GetById(int? id)
    {
        return await _roleContext.Role.FindAsync(id);
    }

    public async Task<Role> Create(Role role)
    {
        _roleContext.Add(role);
        await _roleContext.SaveChangesAsync();
        return role;
    }

    public async Task<Role> Update(Role role)
    {
        _roleContext.Update(role);
        await _roleContext.SaveChangesAsync();
        return role;
    }

    public async Task<Role> Remove(Role role)
    {
        _roleContext.Remove(role);
        await _roleContext.SaveChangesAsync();
        return role;
    }
}