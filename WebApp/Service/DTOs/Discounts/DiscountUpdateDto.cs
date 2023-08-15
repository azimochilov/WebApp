using System.ComponentModel.DataAnnotations;

namespace WebApp.Service.DTOs.Discounts;
public class DiscountUpdateDto
{
    [Required]
    public long Id { get; set; }
    [Required]
    public decimal Percentage { get; set; }
    [Required]
    public DateTime StartDate { get; set; }
    [Required]
    public DateTime EndDate { get; set; }
}
