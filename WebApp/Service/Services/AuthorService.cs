using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApp.Data.IRepositories;
using WebApp.Domain.Entities;
using WebApp.Service.DTOs.Authors;
using WebApp.Service.Exceptions;
using WebApp.Service.Interfaces;

namespace WebApp.Service.Services;
public class AuthorService : IAuthorService
{
    private readonly IRepository<Author> repository;
    private readonly IMapper mapper;

    public AuthorService(IRepository<Author> repository,IMapper mapper)
    {
            this.mapper = mapper;
            this.repository = repository;
    }

    public async ValueTask<AuthorResultDto> AddAsync(AuthorCreationDto dto)
    {
        var exsist = await this.repository.SelectAsync(a => a.Name.Equals(dto.Name));

        if(exsist is not null && exsist.IsDeleted)
        {
            throw new AppException(409, "Author already exsist!");
        }

        var mappedDto = this.mapper.Map<Author>(dto);
        var addedDto = await this.repository.InsertAsync(mappedDto);

        await repository.SaveAsync();

        return mapper.Map<AuthorResultDto>(addedDto);   
    }

    public async ValueTask<AuthorResultDto> ModifyAsync(AuthorUpdateDto dto)
    {
        var author = await this.repository.SelectAsync(a => a.Id.Equals(dto.Id));
        if(author is null || author.IsDeleted)
        {
            throw new AppException(404, "Coud not found author for given id");
        }
        
        var modifiedAuthor = this.mapper.Map(dto, author);
        modifiedAuthor.UpdatedAt = DateTime.UtcNow;

        await repository.SaveAsync();

        return this.mapper.Map<AuthorResultDto>(modifiedAuthor);

    }

    public async ValueTask<bool> RemoveAsync(long id)
    {
        var author = await this.repository.SelectAsync(a => a.Id == id);
        if (author is null || author.IsDeleted)
        {
            throw new AppException(404, "Coud not found author for given id");
        }

        await this.repository.DeleteAsync(a => a.Id == id);
        await this.repository.SaveAsync();

        return true;
    }

    public async ValueTask<IEnumerable<AuthorResultDto>> RetriveAllAsync()
    {
        var authors = await this.repository.SelectAll()
            .Where(a => !a.IsDeleted)
            .ToListAsync();

        return mapper.Map<IEnumerable<AuthorResultDto>>(authors);
    }

    public async ValueTask<AuthorResultDto> RetriveByIdAsync(long id)
    {
        var author = await this.repository.SelectAsync(a => a.Equals(id));

        if(author is null || author.IsDeleted)
        {
            throw new AppException(404, "Auhtor not found");
        }

        return mapper.Map<AuthorResultDto>(author);
    }
}
