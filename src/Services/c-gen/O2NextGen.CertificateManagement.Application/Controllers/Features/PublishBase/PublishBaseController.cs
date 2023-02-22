using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using O2NextGen.CertificateManagement.Domain.Entities;
using O2NextGen.CertificateManagement.Infrastructure.Data;

namespace O2NextGen.CertificateManagement.Application.Controllers.Features.PublishBase;

[ApiVersion("1.0")]
[Route("api/v{v:apiVersion}/[controller]")]
[ApiController]
public class PublishBaseController: ControllerBase
{
    private readonly CGenDbContext _context;

    public PublishBaseController(CGenDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> Items(int? categoryTypeId, [FromQuery]int pageSize = 6, [FromQuery]int pageIndex = 0)
    {
        var rootCategories = (IQueryable<CategoryEntity>)_context.Categories;
        var exist = rootCategories.FirstOrDefault(_ => _.Id == categoryTypeId);
        if (exist == null)
            throw new Exception("not found");
        var root = (IQueryable<CertificateEntity>)_context.Certificates;

        if (categoryTypeId.HasValue)
        {
            root = root.Where(ci => ci.CategoryId == categoryTypeId);
        }
        
        var totalItems = await root
            .LongCountAsync();
        
        var itemsOnPage = await root
            .Skip(pageSize * pageIndex)
            .Take(pageSize)
            .ToListAsync();
        
        var model = new PaginatedItemsViewModel<CertificateEntity>(
            pageIndex, pageSize, totalItems, itemsOnPage);

        return Ok(model);
    } 
}

public class PaginatedItemsViewModel<TEntity> where TEntity : class
{ 
    public int PageIndex { get; private set; }

    public int PageSize { get; private set; }

    public long Count { get; private set; }

    public IEnumerable<TEntity> Data { get; private set; }

    public PaginatedItemsViewModel(int pageIndex, int pageSize, long count, IEnumerable<TEntity> data)
    {
        this.PageIndex = pageIndex;
        this.PageSize = pageSize;
        this.Count = count;
        this.Data = data;
    }
}