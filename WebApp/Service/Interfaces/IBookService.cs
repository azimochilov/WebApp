using WebApp.Service.DTOs.Books;

namespace WebApp.Service.Interfaces;
public interface IBookService
{
    ValueTask<BookResultDto> AddAsync(BookCreationDto dto);
    ValueTask<BookResultDto> ModifyAsync(BookUpdateDto dto);
    ValueTask<bool> RemoveAsync(long id);
    ValueTask<BookResultDto> RetriveByIdAsync(long id);
    ValueTask<IEnumerable<BookResultDto>> RetriveAllAsync(string search = null);
}
