using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApp.Data.IRepositories;
using WebApp.Domain.Entities;
using WebApp.Service.DTOs.Authors;
using WebApp.Service.DTOs.Publishers;
using WebApp.Service.Exceptions;
using WebApp.Service.Interfaces;

namespace WebApp.Service.Services;
public class PublisherService : IPublisherService
{
    private readonly IRepository<Publisher> repository;
    private readonly IMapper mapper;

    public PublisherService(IRepository<Publisher> repository, IMapper mapper)
    {
        this.mapper = mapper;
        this.repository = repository;
    }

    public async ValueTask<PublisherResultDto> AddAsync(PublisherCreationDto dto)
    {
        var exsist = await this.repository.SelectAsync(a => a.Name.Equals(dto.Name));

        if (exsist is not null && exsist.IsDeleted)
        {
            throw new AppException(409, "Publisher already exsist!");
        }

        var mappedDto = this.mapper.Map<Publisher>(dto);
        var addedDto = await this.repository.InsertAsync(mappedDto);

        await repository.SaveAsync();

        return mapper.Map<PublisherResultDto>(addedDto);
    }

    public async ValueTask<PublisherResultDto> ModifyAsync(PublisherUpdateDto dto)
    {
        var publisher = await this.repository.SelectAsync(a => a.Id.Equals(dto.Id));
        if (publisher is null || publisher.IsDeleted)
        {
            throw new AppException(404, "Coud not found publisher for given id");
        }

        var modifiedPublisher = this.mapper.Map(dto, publisher);
        modifiedPublisher.UpdatedAt = DateTime.UtcNow;

        await repository.SaveAsync();

        return this.mapper.Map<PublisherResultDto>(modifiedPublisher);
    }

    public async ValueTask<bool> RemoveAsync(long id)
    {
        var publisher = await this.repository.SelectAsync(a => a.Id == id);
        if (publisher is null || publisher.IsDeleted)
        {
            throw new AppException(404, "Coud not found publisher for given id");
        }

        await this.repository.DeleteAsync(a => a.Id == id);
        await this.repository.SaveAsync();

        return true;
    }

    public async ValueTask<IEnumerable<PublisherResultDto>> RetriveAllAsync()
    {
        var publishers = await this.repository.SelectAll()
            .Where(a => !a.IsDeleted)
            .ToListAsync();

        return mapper.Map<IEnumerable<PublisherResultDto>>(publishers);
    }

    public async ValueTask<PublisherResultDto> RetriveByIdAsync(long id)
    {
        var publisher = await this.repository.SelectAsync(a => a.Id == id);

        if (publisher is null || publisher.IsDeleted)
        {
            throw new AppException(404, "Publisher not found");
        }

        return mapper.Map<PublisherResultDto>(publisher);
    }
}
