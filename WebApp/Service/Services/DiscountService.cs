using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApp.Data.IRepositories;
using WebApp.Domain.Entities;
using WebApp.Service.DTOs.Discounts;
using WebApp.Service.Exceptions;
using WebApp.Service.Interfaces;

namespace WebApp.Service.Services;
public class DiscountService : IDiscountService
{
    private readonly IRepository<Discount> repository;
    private readonly IMapper mapper;

    public DiscountService(IRepository<Discount> repository, IMapper mapper)
    {
        this.mapper = mapper;
        this.repository = repository;
    }

    public async ValueTask<DiscountResultDto> AddAsync(DiscountCreationDto dto)
    {
        var discount = await this.repository.SelectAsync(d => d.Percentage == dto.Percentage);       
        if(discount is not null && !discount.IsDeleted)
        {
            throw new AppException(409, "Discount already exsists");
        }

        var mappedDiscount = this.mapper.Map<Discount>(discount);
        var addedDiscount = await this.repository.InsertAsync(mappedDiscount);

        await this.repository.SaveAsync();

        return this.mapper.Map<DiscountResultDto>(addedDiscount);
    }

    public async ValueTask<bool> RemoveAsync(long id)
    {
        var discount = await this.repository.SelectAsync(d => d.Id == id);
        if(discount is null || discount.IsDeleted)
        {
            throw new AppException(404, "Could not found discount for given id");
        }
        await this.repository.DeleteAsync(d => d.Id == id);
        await this.repository.SaveAsync();

        return true;
    }

    public async ValueTask<DiscountResultDto> ModifyAsync(DiscountUpdateDto dto)
    {
        var discount = await this.repository.SelectAsync(d => d.Id == dto.Id);
        if(discount is null || discount.IsDeleted)
        {
            throw new AppException(404, "Could not found discount for given id");
        }

        var modifiedDiscount = this.mapper.Map(dto, discount);
        modifiedDiscount.UpdatedAt = DateTime.UtcNow;

        await this.repository.SaveAsync();

        return this.mapper.Map<DiscountResultDto>(modifiedDiscount);
    }

    public async ValueTask<IEnumerable<DiscountResultDto>> RetriveAllAsync()
    {
        var discounts = await this.repository.SelectAll()
            .Where(d => !d.IsDeleted)
            .ToListAsync();

        return this.mapper.Map<IEnumerable<DiscountResultDto>>(discounts);
    }

    public async ValueTask<DiscountResultDto> RetriveByIdAsync(long id)
    {
        var discount = await this.repository.SelectAsync(d => d.Id == id);
        if(discount is null || discount.IsDeleted)
        {
            throw new AppException(404, "Could not found discount for given id");
        }

        return this.mapper.Map<DiscountResultDto>(discount);
    }
}
