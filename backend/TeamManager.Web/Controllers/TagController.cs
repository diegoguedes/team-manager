using Microsoft.AspNetCore.Mvc;
using TeamManager.Application.DTOs;
using TeamManager.Application.Interfaces;

namespace TeamManager.Web.Controllers;

[ApiController]
[Route("api/team-manager/v1/[controller]")]
public class TagController : ControllerBase
{
    private readonly ITagService _tagService;
    
    public TagController(ITagService tagService)
    {
        _tagService = tagService;
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<TagDTO>> GetTag(int? id)
    {
        var tagDto = await _tagService.GetById(id);

        return tagDto is not null? Ok(tagDto):NotFound("Tag not found");
    }

    [HttpPost]
    public async Task<ActionResult> CreateTag(TagDTO tag)
    {
        if(tag is null)
            return BadRequest("Invalid Data");
        
        await _tagService.Add(tag);
        
        return  new CreatedAtRouteResult("", new { id = tag.Id }, 
            tag);;
    }
    
    [HttpPut]
    [Route("{id:int}")]
    public async Task<ActionResult> UpdateTag(int id, TagDTO tagDto)
    {
        if(id != tagDto.Id)
            return BadRequest();
        
        if(tagDto is null)
            return BadRequest();
       
        await _tagService.Update(tagDto);
        
        return Ok(tagDto);

    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<TagDTO>> Delete(int id)
    {
        var tag = await _tagService.GetById(id);

        if (tag is null)
        {
            return NotFound("Tag not found");
        }

        await _tagService.Remove(id);

        return Ok(tag);
    }
    
}