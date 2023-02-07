using IdPortal.App.MvcClient.Models.Dto;
using IdPortal.App.MvcClient.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace IdPortal.App.MvcClient.Controllers;

[Authorize]
public class UserController:Controller
{
    private readonly IIdPortalService _icGenCategoryService;

    public UserController(IIdPortalService icGenCategoryService)
    {
        _icGenCategoryService = icGenCategoryService;
    }
    public async Task<ViewResult> CategoryIndex()
    {
        var response = await _icGenCategoryService.GetCategoriesAsync<List<UserDto>>();
        List<ResponseDto> list = null;
        // if (response != null && response.IsSuccess)
        // {
        //     list = JsonConvert.DeserializeObject<List<ResponseDto>>(response.ToString());
        // }
        return View(response);
    }

    public IActionResult CreateUser()
    {
        return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateUser(UserDto model)
    {
        if (ModelState.IsValid)
        {
            var response = await _icGenCategoryService.CreateCategoryAsync<UserDto>(model);
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
    
    public async Task<IActionResult> EditUser(string categoryId)
    {
        var response = await _icGenCategoryService.GetCategoryByIdAsync<UserDto>(categoryId);
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
    public async Task<IActionResult> EditUser(UserDto model)
    {
        if (ModelState.IsValid)
        {
            var response = await _icGenCategoryService.UpdateCategoryAsync<UserDto>(model.Id, model);
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
    
    public async Task<IActionResult> DeleteUser(string categoryId)
    {
        var response = await _icGenCategoryService.GetCategoryByIdAsync<UserDto>(categoryId);
        List<ResponseDto> list = null;
        if (response != null )
            return View(response);
        return NotFound();

    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteUser(UserDto model)
    {
        
            await _icGenCategoryService.DeleteCategoryAsync<UserDto>(model.Id);
            return RedirectToAction(nameof(CategoryIndex));
            
    }
}