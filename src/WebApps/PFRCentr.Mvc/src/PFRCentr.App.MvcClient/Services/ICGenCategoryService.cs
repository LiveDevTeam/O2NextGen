using PFRCentr.App.MvcClient.Models.Dto;

namespace PFRCentr.App.MvcClient.Services;

public interface ICGenCategoryService: IBaseService
{
    Task<T> GetCategoriesAsync<T>();
    Task<T> GetCategoryByIdAsync<T>(long id);
    Task<T> CreateCategoryAsync<T>(T model);
    Task<T> UpdateCategoryAsync<T>(long id,T model);
    Task<T> DeleteCategoryAsync<T>(long id);
}