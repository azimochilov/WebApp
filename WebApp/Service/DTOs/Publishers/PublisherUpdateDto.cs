using System.ComponentModel.DataAnnotations;

namespace WebApp.Service.DTOs.Publishers;
public class PublisherUpdateDto
{
    [Required]
    public long Id { get; set; }
    [Required]
    public string Name { get; set; }
}
