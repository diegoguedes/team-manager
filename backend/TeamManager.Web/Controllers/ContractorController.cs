using Microsoft.AspNetCore.Mvc;
using TeamManager.Application.DTOs;
using TeamManager.Application.Interfaces;

namespace TeamManager.Web.Controllers;

[ApiController]
[Route("api/team-manager/v1/[controller]")]
public class ContractorController : ControllerBase
{
    private readonly IContractorService _contractorService;
    
    public ContractorController(IContractorService contractorService)
    {
        _contractorService = contractorService;
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<ContractorDTO>> GetContractor(int? id)
    {
        var contractorDto = await _contractorService.GetById(id);

        return contractorDto is not null? Ok(contractorDto):NotFound("Contractor not found");
    }
    
    [HttpPost]
    public async Task<ActionResult> CreateContractor(ContractorDTO contractor)
    {
        if(contractor is null)
            return BadRequest("Invalid Data");
        
        await _contractorService.Add(contractor);
        
        return  new CreatedAtRouteResult("", new { id = contractor.Id }, 
            contractor);;
    }
    
    [HttpPut]
    [Route("{id:int}")]
    public async Task<ActionResult> UpdateContractor(int id, ContractorDTO contractorDto)
    {
        if(id != contractorDto.Id)
            return BadRequest();
        
        if(contractorDto is null)
            return BadRequest();
       
        await _contractorService.Update(contractorDto);
        
        return Ok(contractorDto);

    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<ContractorDTO>> Delete(int id)
    {
        var contractor = await _contractorService.GetById(id);

        if (contractor is null)
        {
            return NotFound("Contractor not found");
        }

        await _contractorService.Remove(id);

        return Ok(contractor);
    }

    
}