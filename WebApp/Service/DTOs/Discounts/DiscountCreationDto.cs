using System.ComponentModel.DataAnnotations;

namespace WebApp.Service.DTOs.Discounts;
public class DiscountCreationDto
{
    [Required]
    public decimal Percentage { get; set; }
    [Required]
    public DateTime StartDate { get; set; }
    [Required]
    public DateTime EndDate { get; set; }
}
