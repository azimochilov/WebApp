using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using WebApp.Data.IRepositories;
using WebApp.Domain.Entities;
using WebApp.Service.DTOs.Books;
using WebApp.Service.Exceptions;
using WebApp.Service.Interfaces;

namespace WebApp.Service.Services;
public class BookService : IBookService
{
    private readonly IRepository<Book> repository;
    private readonly IMapper mapper;

    public BookService(IRepository<Book> repository , IMapper mapper)
    {
        this.repository = repository;
        this.mapper = mapper;
    }

    public async ValueTask<BookResultDto> AddAsync(BookCreationDto dto)
    {
        var book = await this.repository.SelectAsync(b => b.Name == dto.Name);
        if(book is not null && !book.IsDeleted) 
        {
            throw new AppException(409, "User already exsists");
        }

        var mappedBook = mapper.Map<Book>(book);
        var addedBook = await this.repository.InsertAsync(mappedBook);

        await this.repository.SaveAsync();

        return this.mapper.Map<BookResultDto>(addedBook);
    }

    public async ValueTask<BookResultDto> ModifyAsync(BookUpdateDto dto)
    {
        var book = await this.repository.SelectAsync(b => b.Name == dto.Name);

        if(book is null || book.IsDeleted)
        {
            throw new AppException(404, "Coud not found book for given id");
        }

        var modifiedBook = mapper.Map(dto,book);
        modifiedBook.UpdatedAt = DateTime.UtcNow;

        await this.repository.SaveAsync();

        return mapper.Map<BookResultDto>(modifiedBook);
    }

    public async ValueTask<bool> RemoveAsync(long id)
    {
        var book = await this.repository.SelectAsync(b => b.Id == id);
        if (book is null || book.IsDeleted)
        {
            throw new AppException(404, "Coud not found book for given id");
        }

        await this.repository.DeleteAsync(a => a.Id == id);
        await this.repository.SaveAsync();

        return true;
    }

    public async ValueTask<IEnumerable<BookResultDto>> RetriveAllAsync()
    {
        var books = await this.repository.SelectAll(b => !b.IsDeleted, new string[] { "Author", "Publisher", "Genre" })
            .ToListAsync();
          
        return this.mapper.Map<IEnumerable<BookResultDto>>(books);
    }

    public async ValueTask<BookResultDto> RetriveByIdAsync(long id)
    {
        var book = await this.repository.SelectAsync(a => a.Id == id);
        if (book is null || book.IsDeleted)
        {
            throw new AppException(404, "Book not found");
        }

        return mapper.Map<BookResultDto>(book);
    }
}
