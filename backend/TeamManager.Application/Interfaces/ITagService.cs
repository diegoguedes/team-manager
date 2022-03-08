using TeamManager.Application.DTOs;

namespace TeamManager.Application.Interfaces;

public interface ITagService
{
    Task<TagDTO> GetById(int? id);
    Task Add(TagDTO tagDto);
    Task Update(TagDTO tagDto);
    Task Remove(int? id);

}