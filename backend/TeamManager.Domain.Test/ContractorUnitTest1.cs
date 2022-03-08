using System;
using System.Collections.Generic;
using FluentAssertions;
using TeamManager.Domain.Entities;
using Xunit;

namespace TeamManager.Domain.Tests;

public class ContractorUnitTest1
{
    [Fact(DisplayName = "Create Contractor With Valid State")]
    public void CreateContractor_WithValidParameters_ResultObjectValidState()
    {
        var tag = new Tag("C#");
        
        Action action = () => new Contractor(1, "Diego", 12,tag);
        action.Should()
            .NotThrow<TeamManager.Domain.Validation.DomainExceptionValidation>();
    }
    
    [Fact(DisplayName = "Create Contractor With Invalid Id")]
    public void CreateContractor_NegativeIdValue_DomainExceptionInvalidId()
    {
        var tag = new Tag("C#");
        
        Action action = () => new Contractor(-1, "Diego", 12,tag);
        action.Should()
            .Throw<TeamManager.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid Id value");
    }
    
    [Fact(DisplayName = "Create Contractor With Short Name")]
    public void CreateContractor_ShortNameValue_DomainExceptionShortName()
    {
        var tag = new Tag("C#");
        
        Action action = () => new Contractor(1, "Di", 12,tag);
        action.Should()
            .Throw<TeamManager.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid name, too short, minimum 3 characters");
    }
    
    [Fact(DisplayName = "Create Contractor With Empty Name")]
    public void CreateContractor_EmptyNameValue_DomainExceptionEmptyName()
    {
        var tag = new Tag("C#");
        
        Action action = () => new Contractor(1, "", 12,tag);
        action.Should()
            .Throw<TeamManager.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid name. Name is required");
    }
}