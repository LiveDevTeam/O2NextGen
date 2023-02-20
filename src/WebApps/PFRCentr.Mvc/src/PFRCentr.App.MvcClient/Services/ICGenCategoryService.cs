using PFRCentr.App.MvcClient.Models.Dto;

namespace PFRCentr.App.MvcClient.Services;

public interface ICGenCategoryService: IBaseService
{
    Task<T> GetCategoriesAsync<T>(string token);
    Task<T> GetCategoryByIdAsync<T>(long id, string token);
    Task<T> CreateCategoryAsync<T>(T model, string token);
    Task<T> UpdateCategoryAsync<T>(long id,T model, string token);
    Task<T> DeleteCategoryAsync<T>(long id, string token);
}