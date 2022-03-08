using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TeamManager.Application.DTOs;

public class ContractorDTO
{
    [Required(ErrorMessage = "The Id is Required")]
    [DisplayName("Id")]
    public int Id { get; set; }
    
    [Required(ErrorMessage = "The Name is Required")]
    [MinLength(3)]
    [MaxLength(100)]
    [DisplayName("Name")]
    public string Name { get; set; }
    
    [Required(ErrorMessage = "The Duration is Required")]
    [Range(1,999)]
    [DisplayName("Duration")]
    public int Duration { get; set; }
    
    [Required(ErrorMessage = "The Tag is Required")]
    [DisplayName("Tag")]
    public int Tag { get; set; }
}