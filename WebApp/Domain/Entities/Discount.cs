using WebApp.Domain.Commons;

namespace WebApp.Domain.Entities;
public class Discount : Auditable
{
    public long DiscountId { get; set; }
    public decimal Percentage { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}
