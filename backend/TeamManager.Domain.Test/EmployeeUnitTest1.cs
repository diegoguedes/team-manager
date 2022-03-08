using System;
using System.Collections.Generic;
using FluentAssertions;
using TeamManager.Domain.Entities;
using Xunit;

namespace TeamManager.Domain.Tests;

public class EmployeeUnitTest1
{
    [Fact(DisplayName = "Create Employee With Valid State")]
    public void CreaterEmployee_WithValidParameters_ResultObjectValidState()
    {
        var tag = new Tag("C#");

        var role = new Role("Software Engineer");
        
        Action action = () => new Employee(1, "Diego", role,tag);
        action.Should()
            .NotThrow<TeamManager.Domain.Validation.DomainExceptionValidation>();
    }
    
    [Fact(DisplayName = "Create Employee With Invalid Id")]
    public void CreaterEmployee_NegativeIdValue_DomainExceptionInvalidId()
    {
        var tag = new Tag("C#");
        
        var role = new Role("Software Engineer");
        
        Action action = () => new Employee(-1, "Diego", role,tag);
        action.Should()
            .Throw<TeamManager.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid Id value");
    }
    
    [Fact(DisplayName = "Create Employee With Short Name")]
    public void CreaterEmployee_ShortNameValue_DomainExceptionShortName()
    {
        var tag = new Tag("C#");
        
        var role = new Role("Software Engineer");
        
        Action action = () => new Employee(1, "Di", role,tag);
        action.Should()
            .Throw<TeamManager.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid name, too short, minimum 3 characters");
    }
    
    [Fact(DisplayName = "Create Employee With Empty Name")]
    public void CreaterEmployee_EmptyNameValue_DomainExceptionEmptyName()
    {
        var tag = new Tag("C#");
        
        var role = new Role("Software Engineer");
        
        Action action = () => new Employee(1, "", role,tag);
        action.Should()
            .Throw<TeamManager.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid name. Name is required");
    }
}