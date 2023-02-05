using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PFRCentr.App.MvcClient.Models.Dto;
using PFRCentr.App.MvcClient.Services;

namespace PFRCentr.App.MvcClient.Controllers;

public class CategoryController:Controller
{
    private readonly ICGenCategoryService _icGenCategoryService;

    public CategoryController(ICGenCategoryService icGenCategoryService)
    {
        _icGenCategoryService = icGenCategoryService;
    }
    public async Task<ViewResult> CategoryIndex()
    {
        var response = await _icGenCategoryService.GetCategoriesAsync<List<CategoryDto>>();
        List<ResponseDto> list = null;
        // if (response != null && response.IsSuccess)
        // {
        //     list = JsonConvert.DeserializeObject<List<ResponseDto>>(response.ToString());
        // }
        return View(response);
    }

    public IActionResult CreateCategory()
    {
        return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateCategory(CategoryDto model)
    {
        if (ModelState.IsValid)
        {
            var response = await _icGenCategoryService.CreateCategoryAsync<CategoryDto>(model);
            List<ResponseDto> list = null;
            // if (response != null && response.IsSuccess)
            // {
            //     list = JsonConvert.DeserializeObject<List<ResponseDto>>(response.ToString());
            // }
            // if (response == null)
            //     return View(model);
            return RedirectToAction(nameof(CategoryIndex));
        }
        return View(model);
    }
    
    public async Task<IActionResult> EditCategory(long categoryId)
    {
        var response = await _icGenCategoryService.GetCategoryByIdAsync<CategoryDto>(categoryId);
        List<ResponseDto> list = null;
        if (response != null )
            return View(response);
        return NotFound();
        // {
        //     list = JsonConvert.DeserializeObject<List<ResponseDto>>(response.ToString());
        // }
        // if (response == null)
        //     return View(model);

    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> EditCategory(CategoryDto model)
    {
        if (ModelState.IsValid)
        {
            var response = await _icGenCategoryService.UpdateCategoryAsync<CategoryDto>(model.Id, model);
            List<ResponseDto> list = null;
            // if (response != null && response.IsSuccess)
            // {
            //     list = JsonConvert.DeserializeObject<List<ResponseDto>>(response.ToString());
            // }
            // if (response == null)
            //     return View(model);
            return RedirectToAction(nameof(CategoryIndex));
        }
        return View(model);
    }
    
    public async Task<IActionResult> DeleteCategory(long categoryId)
    {
        var response = await _icGenCategoryService.GetCategoryByIdAsync<CategoryDto>(categoryId);
        List<ResponseDto> list = null;
        if (response != null )
            return View(response);
        return NotFound();

    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteCategory(CategoryDto model)
    {
        
            await _icGenCategoryService.DeleteCategoryAsync<CategoryDto>(model.Id);
            return RedirectToAction(nameof(CategoryIndex));
            
    }
}