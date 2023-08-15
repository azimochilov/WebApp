using WebApp.Service.DTOs.Authors;

namespace WebApp.Service.Interfaces;
public interface IAuthorService
{
    ValueTask<AuthorResultDto> AddAsync(AuthorCreationDto dto);
    ValueTask<AuthorResultDto> ModifyAsync(AuthorUpdateDto dto);
    ValueTask<bool> RemoveAsync(long id);
    ValueTask<AuthorResultDto> RetriveByIdAsync(long id);
    ValueTask<IEnumerable<AuthorResultDto>> RetriveAllAsync();
}
