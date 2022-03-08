using AutoMapper;
using TeamManager.Application.DTOs;
using TeamManager.Application.Interfaces;
using TeamManager.Domain.Entities;
using TeamManager.Domain.Interfaces;

namespace TeamManager.Application.Services;

public class TagService : ITagService
{
    private ITagRepository _tagRepository;
    private readonly IMapper _mapper;

    public TagService(ITagRepository tagRepository, IMapper mapper)
    {
        _tagRepository = tagRepository;
        _mapper = mapper;
    }


    public async Task<TagDTO> GetById(int? id)
    {
        var tagEntity = await _tagRepository.GetById(id);
        return _mapper.Map<TagDTO>(tagEntity);
    }

    public async Task Add(TagDTO tagDto)
    {
        var tagEntity = _mapper.Map<Tag>(tagDto);
        await _tagRepository.Create(tagEntity);
    }

    public async Task Update(TagDTO tagDto)
    {
        var tagEntity = _mapper.Map<Tag>(tagDto);
        await _tagRepository.Update(tagEntity);
    }

    public async Task Remove(int? id)
    {
        var tagEntity = _tagRepository.GetById(id).Result;
        await _tagRepository.Remove(tagEntity);
    }
}