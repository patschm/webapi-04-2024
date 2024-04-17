
using Microsoft.AspNetCore.Mvc;
using ProductReviews.Interfaces;
using ProductReviews.DAL.EntityFramework.Entities;
using ProductReviews.DTO;

namespace ProductReviews.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductGroupController : ControllerBase
{
    private readonly IProductGroupRepository _repository;

    public ProductGroupController(IProductGroupRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<ICollection<ProductGroupDTO>> Get(int page = 1, int count = 10)
    {
        var q = await _repository.GetAsync(page, count);
        return q.Select(p => ProductGroupDTO.Create(p)).ToList();
    }
    [HttpGet("{id}")]
    public async Task<ProductGroupDTO> Get(int id)
    {
        var pg =await _repository.GetByIdAsync(id);
        return ProductGroupDTO.Create(pg);
    }
    [HttpPost]
    public async Task<ProductGroup> Post([FromBody]ProductGroup productGroup)
    {
        return await _repository.AddAsync(productGroup);
    }
    [HttpPut("{id}")]
    public async Task<ProductGroup> Put(int id, [FromBody]ProductGroup productGroup)
    {
        productGroup.Id = id;
        return await _repository.UpdateAsync(productGroup);
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _repository.DeleteAsync(id);
        return Ok();
    }
}