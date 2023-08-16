
using WebApp.Service.DTOs.Genres;

namespace WebApp.Service.Interfaces;
public interface IGenreService
{
    ValueTask<GenreResultDto> AddAsync(GenreCreationDto dto);
    ValueTask<GenreResultDto> ModifyAsync(GenreUpdateDto dto);
    ValueTask<bool> RemoveAsync(long id);
    ValueTask<IEnumerable<GenreResultDto>> RetriveAllAsync();
    ValueTask<GenreResultDto> RetriveByIdAsync(long id);
}
