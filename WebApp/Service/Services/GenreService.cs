using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApp.Data.IRepositories;
using WebApp.Domain.Entities;
using WebApp.Service.DTOs.Genres;
using WebApp.Service.Exceptions;
using WebApp.Service.Interfaces;

namespace WebApp.Service.Services;
public class GenreService : IGenreService
{
    private readonly IRepository<Genre> repository;
    private readonly IMapper mapper;

    public GenreService(IRepository<Genre> repository, IMapper mapper)
    {
        this.repository = repository;
        this.mapper = mapper;
    }

    public async ValueTask<GenreResultDto> AddAsync(GenreCreationDto dto)
    {
        var genre = await this.repository.SelectAsync(g => g.Name == dto.Name);
        if(genre is not null && genre.IsDeleted)
        {
            throw new AppException(409, "Already exsists");
        }

        var mappedGenre = this.mapper.Map<Genre>(dto);
        await  this.repository.InsertAsync(mappedGenre);

        await this.repository.SaveAsync();

        return this.mapper.Map<GenreResultDto>(mappedGenre);
    }

    public async ValueTask<GenreResultDto> ModifyAsync(GenreUpdateDto dto)
    {
        var genre = await this.repository.SelectAsync(g => g.Name == dto.Name);
        if(genre is null || genre.IsDeleted)
        {
            throw new AppException(404, "Coudnot found genre for given id");
        }

        var modifiedGenre = this.mapper.Map(dto, genre);
        modifiedGenre.UpdatedAt = DateTime.Now;

        await this.repository.SaveAsync();

        return this.mapper.Map<GenreResultDto>(modifiedGenre);
    }

    public async ValueTask<bool> RemoveAsync(long id)
    {
        var genre = await this.repository.SelectAsync(g => g.Id == id);
        if(genre is null || genre.IsDeleted)
        {
            throw new AppException(404, "Could not found genre for given id");
        }

        await this.repository.DeleteAsync(g => g.Id == id);
        await this.repository.SaveAsync();

        return true;
    }

    public async ValueTask<IEnumerable<GenreResultDto>> RetriveAllAsync()
    {
        var genres = await this.repository.SelectAll()
            .Where(g => !g.IsDeleted)
            .ToListAsync();

        return this.mapper.Map<IEnumerable<GenreResultDto>>(genres);
    }

    public async ValueTask<GenreResultDto> RetriveByIdAsync(long id)
    {
        var genre = await this.repository.SelectAsync(g => g.Id == id);
        if (genre is null || genre.IsDeleted)
        {
            throw new AppException(404, "Could not found genre for given id");
        }

        return this.mapper.Map<GenreResultDto>(genre);
    }
}
