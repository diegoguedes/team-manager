using AutoMapper;
using TeamManager.Application.DTOs;
using TeamManager.Domain.Entities;

namespace TeamManager.Application.Mappings;

public class DomainToDTOMappingProfile:Profile
{
    public DomainToDTOMappingProfile()
    {
        CreateMap<Contractor, ContractorDTO>().ReverseMap();
        CreateMap<Employee, EmployeeDTO>().ReverseMap();
        CreateMap<Role, RoleDTO>().ReverseMap();
        CreateMap<Tag, TagDTO>().ReverseMap();
        CreateMap<TeamMember, TeamMemberDTO>().ReverseMap();
    }
}