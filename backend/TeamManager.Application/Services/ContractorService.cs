using AutoMapper;
using TeamManager.Application.DTOs;
using TeamManager.Application.Interfaces;
using TeamManager.Domain.Entities;
using TeamManager.Domain.Interfaces;

namespace TeamManager.Application.Services;

public class ContractorService : IContractorService
{
    private IContractorRepository _contractorRepository;
    private ITeamMemberRepository _teamMemberRepository;
    private ITagRepository _tagRepository;
    private readonly IMapper _mapper;
    
    public ContractorService(IContractorRepository contractorRepository, ITeamMemberRepository teamMemberRepository, ITagRepository tagRepository, IMapper mapper)
    {
        _contractorRepository = contractorRepository;
        _teamMemberRepository = teamMemberRepository;
        _tagRepository = tagRepository;
        _mapper = mapper;
    }

    public async Task<ContractorDTO> GetById(int? id)
    {
        var contractorEntity = await _contractorRepository.GetById(id);
        var teamMemberEntity = await _teamMemberRepository.GetById(id);
        
        var contractorDto = _mapper.Map<ContractorDTO>(contractorEntity);
        _mapper.Map(teamMemberEntity, contractorDto);

        return contractorDto;
    }

    public async Task Add(ContractorDTO contractorDto)
    {
        var tagEntity = await _tagRepository.GetById(contractorDto.Tag);

        var contractorEntity = new Contractor(contractorDto.Name, contractorDto.Duration, tagEntity);
        await _contractorRepository.Create(contractorEntity);
    }

    public async Task Update(ContractorDTO contractorDto)
    {
        var tagEntity = await _tagRepository.GetById(contractorDto.Tag);

        var contractorEntity = new Contractor(contractorDto.Id, contractorDto.Name, contractorDto.Duration, tagEntity);
        await _contractorRepository.Update(contractorEntity);
    }

    public async Task Remove(int? id)
    {
        var contractorEntity = _contractorRepository.GetById(id).Result;
        await _contractorRepository.Remove(contractorEntity);
    }
}