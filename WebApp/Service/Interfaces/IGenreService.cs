
using WebApp.Service.DTOs.Genres;

namespace WebApp.Service.Interfaces;
public interface IGenreService
{
    ValueTask<GenreResultDto> AddAsync(GenreCreationDto dto);
    ValueTask<GenreResultDto> ModifyAsync(GenreUpdateDto dto);
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<IEnumerable<GenreResultDto>> RetriveAllAsync(string search = null);
    ValueTask<GenreResultDto> RetriveByIdAsync(long id);
}
