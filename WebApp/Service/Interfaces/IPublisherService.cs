
using WebApp.Service.DTOs.Publishers;

namespace WebApp.Service.Interfaces;
public interface IPublisherService
{
    ValueTask<PublisherResultDto> AddAsync(PublisherCreationDto dto);
    ValueTask<PublisherResultDto> ModifyAsync(PublisherUpdateDto dto);
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<IEnumerable<PublisherResultDto>> RetriveAllAsync(string search = null);
    ValueTask<PublisherResultDto> RetriveByIdAsync(long id);

}
