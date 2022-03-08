using Microsoft.EntityFrameworkCore;
using TeamManager.Domain.Entities;
using TeamManager.Domain.Interfaces;
using TeamManager.Infra.Data.Context;

namespace TeamManager.Infra.Data.Repositories;

public class TeamMemberRepository : ITeamMemberRepository
{
    private ApplicationDbContext _teamMemberContext;
    
    public TeamMemberRepository(ApplicationDbContext context)
    {
        _teamMemberContext = context;
    }
    public async Task<List<TeamMember>> GetTags()
    {
        return await _teamMemberContext.TeamMember.ToListAsync();
    }

    public async Task<TeamMember> GetById(int? id)
    {
        return await _teamMemberContext.TeamMember.FindAsync(id);
    }

    public async Task<TeamMember> Create(TeamMember teamMember)
    {
        _teamMemberContext.Add(teamMember);
        await _teamMemberContext.SaveChangesAsync();
        return teamMember;
    }

    public async Task<TeamMember> Update(TeamMember teamMember)
    {
        _teamMemberContext.Update(teamMember);
        await _teamMemberContext.SaveChangesAsync();
        return teamMember;
    }

    public async Task<TeamMember> Remove(TeamMember teamMember)
    {
        _teamMemberContext.Remove(teamMember);
        await _teamMemberContext.SaveChangesAsync();
        return teamMember;
    }
}