using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PFRCentr.App.MvcClient.Models.Dto;
using PFRCentr.App.MvcClient.Services;

namespace PFRCentr.App.MvcClient.Controllers;
public class PaginationInfo
{
    public int TotalItems { get; set; }
    public int ItemsPerPage { get; set; }
    public int ActualPage { get; set; }
    public int TotalPages { get; set; }
    public string Previous { get; set; }
    public string Next { get; set; }
}
public class CatalogIndexViewModel
{
    public IEnumerable<PublishCertificateDto> CatalogItems { get; set; }
    public IEnumerable<SelectListItem> Types { get; set; }
    
    public int? BrandFilterApplied { get; set; }
    public int? TypesFilterApplied { get; set; }
    public PaginationInfo PaginationInfo { get; set; }
}

public class PublishBaseController: Controller
{
    private readonly IPublishBase _publishBase;

    public PublishBaseController(IPublishBase publishBase)
    {
        _publishBase = publishBase;
    }
    public async Task<IActionResult> Index(int? TypesFilterApplied, int? page)
    {
        int itemsPage=10 ;
        var catalog = await _publishBase.GetItems<Catalog>(page ?? 0, itemsPage, TypesFilterApplied);
        var vm = new CatalogIndexViewModel()
        {
            CatalogItems = catalog.Data,
            //Types = await _publishBase.GetTypes(),
            TypesFilterApplied = TypesFilterApplied ?? 0,
            PaginationInfo = new PaginationInfo()
            {
                ActualPage = page ?? 0,
                ItemsPerPage = itemsPage , 
                TotalItems = catalog.Count,
                TotalPages = (int)Math.Ceiling(((decimal)catalog.Count / itemsPage))
            }
        };

        vm.PaginationInfo.Next = (vm.PaginationInfo.ActualPage == vm.PaginationInfo.TotalPages - 1) ? "is-disabled" : "";
        vm.PaginationInfo.Previous = (vm.PaginationInfo.ActualPage == 0) ? "is-disabled" : "";

        return View(vm);
    }
}