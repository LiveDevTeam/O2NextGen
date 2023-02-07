using IdPortal.App.MvcClient.Models.Dto;

namespace IdPortal.App.MvcClient.Services;

public interface IIdPortalService: IBaseService
{
    Task<T> GetCategoriesAsync<T>();
    Task<T> GetCategoryByIdAsync<T>(string id);
    Task<T> CreateCategoryAsync<T>(T model);
    Task<T> UpdateUserAsync<T>(string id,T model);
    Task<T> DeleteUserAsync<T>(string id);
}