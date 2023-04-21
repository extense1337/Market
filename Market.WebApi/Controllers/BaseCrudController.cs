using Market.DomainEntities.Entities;
using Market.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Market.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class BaseCrudController<T> : ControllerBase 
    where T : BaseEntity
{
    private readonly IBaseCrudService<T> _baseCrudService;

    public BaseCrudController(IBaseCrudService<T> baseCrudService)
    {
        _baseCrudService = baseCrudService;
    }

    [HttpGet("GetAll")]
    public async Task<List<T>> GetAll()
    {
        return await _baseCrudService.GetAll().ToListAsync();
    }

    [HttpGet("GetById")]
    public async Task<T> GetById(int id)
    {
        return await _baseCrudService.GetById(id);
    }

    [HttpPost("Add")]
    public async Task<bool> Add(T entity)
    {
        return await _baseCrudService.Add(entity);
    }

    [HttpDelete("Delete")]
    public async Task<bool> Delete(int id)
    {
        return await _baseCrudService.Delete(id);
    }

    [HttpPut("Update")]
    public async Task<bool> Update(int id)
    {
        return await _baseCrudService.Update(id);
    }
}