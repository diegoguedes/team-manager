using AutoMapper;
using TeamManager.Application.DTOs;
using TeamManager.Application.Interfaces;
using TeamManager.Domain.Entities;
using TeamManager.Domain.Interfaces;

namespace TeamManager.Application.Services;

public class RoleService : IRoleService
{
    private IRoleRepository _roleRepository;
    private readonly IMapper _mapper;

    public RoleService(IRoleRepository roleRepository, IMapper mapper)
    {
        _roleRepository = roleRepository;
        _mapper = mapper;
    }

    public async Task<RoleDTO> GetById(int? id)
    {
        var roleEntity = await _roleRepository.GetById(id);
        return roleEntity is not null? _mapper.Map<RoleDTO>(roleEntity):null;
    }

    public async Task Add(RoleDTO roleDto)
    {
        var roleEntity = _mapper.Map<Role>(roleDto);
        await _roleRepository.Create(roleEntity);
    }

    public async Task Update(RoleDTO roleDto)
    {
        var roleEntity = _mapper.Map<Role>(roleDto);
        await _roleRepository.Update(roleEntity);
    }

    public async Task Remove(int? id)
    {
        var roleEntity = _roleRepository.GetById(id).Result;
        await _roleRepository.Remove(roleEntity);
    }
}