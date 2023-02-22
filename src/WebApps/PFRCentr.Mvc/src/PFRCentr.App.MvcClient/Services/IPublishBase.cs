using Microsoft.AspNetCore.Mvc.Rendering;
using PFRCentr.App.MvcClient.Models.Dto;

namespace PFRCentr.App.MvcClient.Services;

public interface IPublishBase: IBaseService
{
    Task<T> GetItems<T>(int page, int take, long? type);
    Task<IEnumerable<SelectListItem>> GetTypes();
}