using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using TeamManager.Domain.Entities;

namespace TeamManager.Application.DTOs;

public class EmployeeDTO
{
    [Required(ErrorMessage = "The Id is Required")]
    [DisplayName("Id")]
    public int Id { get; set; }
    
    [Required(ErrorMessage = "The Name is Required")]
    [MinLength(3)]
    [MaxLength(100)]
    [DisplayName("Name")]
    public string Name { get; set; }
    
    [DisplayName("Role")]
    public int Role { get; set; }
    
    [Required(ErrorMessage = "The Tag is Required")]
    [DisplayName("Tag")]
    public int Tag { get; set; }
}