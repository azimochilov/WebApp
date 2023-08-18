using Microsoft.AspNetCore.Mvc;
using WebApp.Service.DTOs.Authors;
using WebApp.Service.Interfaces;

namespace WebApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthorController : ControllerBase
{
    private readonly IAuthorService authorService;
    public AuthorController(IAuthorService authorService)
    {
        this.authorService = authorService;
    }

    [HttpPost]
    public async ValueTask<IActionResult> InsertAsync([FromBody]AuthorCreationDto dto) =>
           Ok(await this.authorService.AddAsync(dto));

    [HttpGet]
    public async ValueTask<IActionResult> GetAllAsync() =>
        Ok(await this.authorService.RetriveAllAsync());

    [HttpGet("{id}")]
    public async ValueTask<IActionResult> GetByIdAsync(long id) =>
        Ok(await this.authorService.RetriveByIdAsync(id));

    [HttpDelete("{id}")]
    public async ValueTask<IActionResult> DeleteById(long id) =>
        Ok(await this.authorService.RemoveAsync(id));

    [HttpPut("{id}")]
    public async ValueTask<IActionResult> UpdateAsync(AuthorUpdateDto dto) =>
        Ok(await this.authorService.ModifyAsync(dto));
    

}
