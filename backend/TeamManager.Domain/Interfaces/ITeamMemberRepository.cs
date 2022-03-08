using TeamManager.Domain.Entities;

namespace TeamManager.Domain.Interfaces;

public interface ITeamMemberRepository
{
    Task<List<TeamMember>> GetTags();
    Task<TeamMember> GetById(int? id);
    Task<TeamMember> Create(TeamMember teamMember);
    Task<TeamMember> Update(TeamMember teamMember);
    Task<TeamMember> Remove(TeamMember teamMember);
}