using WebApp.Service.DTOs.Discounts;

namespace WebApp.Service.Interfaces;
public interface IDiscountService
{
    ValueTask<DiscountResultDto> AddAsync(DiscountCreationDto dto);
    ValueTask<DiscountResultDto> ModifyAsync(DiscountUpdateDto dto);
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<IEnumerable<DiscountResultDto>> RetriveAllAsync(string search = null);
    ValueTask<DiscountResultDto> RetriveByIdAsync (long id);
}
