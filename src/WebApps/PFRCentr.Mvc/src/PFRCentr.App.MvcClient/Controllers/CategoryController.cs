using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PFRCentr.App.MvcClient.Models.Dto;
using PFRCentr.App.MvcClient.Services;

namespace PFRCentr.App.MvcClient.Controllers;

[Authorize]
public class CategoryController : Controller
{
    private readonly ICGenCategoryService _icGenCategoryService;

    public CategoryController(ICGenCategoryService icGenCategoryService)
    {
        _icGenCategoryService = icGenCategoryService;
    }

    public async Task<ViewResult> CategoryIndex()
    {
        var token = await HttpContext.GetTokenAsync("access_token");
        var response = await _icGenCategoryService.GetCategoriesAsync<List<CategoryDto>>(token);
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
            var token = await HttpContext.GetTokenAsync("access_token");
            var response = await _icGenCategoryService.CreateCategoryAsync<CategoryDto>(model, token);
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
        var token = await HttpContext.GetTokenAsync("access_token");
        var response = await _icGenCategoryService.GetCategoryByIdAsync<CategoryDto>(categoryId, token);
        List<ResponseDto> list = null;
        if (response != null)
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
            var token = await HttpContext.GetTokenAsync("access_token");
            var response = await _icGenCategoryService.UpdateCategoryAsync<CategoryDto>(model.Id, model, token);
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
        var token = await HttpContext.GetTokenAsync("access_token");
        var response = await _icGenCategoryService.GetCategoryByIdAsync<CategoryDto>(categoryId, token);
        List<ResponseDto> list = null;
        if (response != null)
            return View(response);
        return NotFound();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteCategory(CategoryDto model)
    {
        var token = await HttpContext.GetTokenAsync("access_token");
        await _icGenCategoryService.DeleteCategoryAsync<CategoryDto>(model.Id, token);
        return RedirectToAction(nameof(CategoryIndex));
    }
}