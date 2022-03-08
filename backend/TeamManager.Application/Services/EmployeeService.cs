using AutoMapper;
using TeamManager.Application.DTOs;
using TeamManager.Application.Interfaces;
using TeamManager.Domain.Entities;
using TeamManager.Domain.Interfaces;

namespace TeamManager.Application.Services;

public class EmployeeService : IEmployeeService
{
    private IEmployeeRepository _employeeRepository;
    private ITeamMemberRepository _teamMemberRepository;
    private IRoleRepository _roleRepository;
    private ITagRepository _tagRepository;
    private readonly IMapper _mapper;

    public EmployeeService(IEmployeeRepository employeeRepository,ITeamMemberRepository teamMemberRepository, IRoleRepository roleRepository, ITagRepository tagRepository, IMapper mapper)
    {
        _employeeRepository = employeeRepository;
        _teamMemberRepository = teamMemberRepository;
        _roleRepository = roleRepository;
        _tagRepository = tagRepository;
        _mapper = mapper;
    }

    public async Task<EmployeeDTO> GetById(int? id)
    {
        var teamMemberEntity = await _teamMemberRepository.GetById(id);
        var employeeEntity = await _employeeRepository.GetById(id);

        if (teamMemberEntity is not null && employeeEntity is not null)
        {
            var employeeDto = _mapper.Map<EmployeeDTO>(employeeEntity);
            _mapper.Map(teamMemberEntity, employeeDto);
        
            return employeeDto;    
        }

        return null;

    }

    public async Task Add(EmployeeDTO employeeDto)
    {
        var roleEntity = await _roleRepository.GetById(employeeDto.Role);
        var tagEntity = await _tagRepository.GetById(employeeDto.Tag);

        if (roleEntity is not null && tagEntity is not null)
        {
            var employeeEntity = new Employee(employeeDto.Name, roleEntity, tagEntity);
            await _employeeRepository.Create(employeeEntity);
        }

    }

    public async Task Update(EmployeeDTO employeeDto)
    {
        var roleEntity = await _roleRepository.GetById(employeeDto.Role);
        var tagEntity = await _tagRepository.GetById(employeeDto.Tag);

        if (roleEntity is not null && tagEntity is not null)
        {
            var employeeEntity = new Employee(employeeDto.Id, employeeDto.Name, roleEntity, tagEntity);
            await _employeeRepository.Update(employeeEntity);
        }

    }

    public async Task Remove(int? id)
    {
        var employeeEntity = _employeeRepository.GetById(id).Result;
        await _employeeRepository.Remove(employeeEntity);
    }
}