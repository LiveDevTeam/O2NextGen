using IdPortal.App.MvcClient.Models.Dto;

namespace IdPortal.App.MvcClient.Services;

public interface IIdPortalService: IBaseService
{
    Task<T> GetCategoriesAsync<T>();
    Task<T> GetCategoryByIdAsync<T>(string id);
    Task<T> CreateCategoryAsync<T>(T model);
    Task<T> UpdateCategoryAsync<T>(string id,T model);
    Task<T> DeleteCategoryAsync<T>(string id);
}