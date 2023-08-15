using System.ComponentModel.DataAnnotations;

namespace WebApp.Service.DTOs.Publishers;
public class PublisherCreationDto
{
    [Required]
    public string Name { get; set; }
}
