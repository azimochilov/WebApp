namespace WebApp.Service.DTOs.Discounts;
public class DiscountResultDto
{
    public long Id { get; set; }
    public decimal Percentage { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}
