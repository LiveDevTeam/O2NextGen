using IdPortal.App.MvcClient.Models.Dto;
using IdPortal.App.MvcClient.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IdPortal.App.MvcClient.Controllers;

[Authorize]
public class UserController:Controller
{
    private readonly IIdPortalService _idPortalService;

    public UserController(IIdPortalService idPortalService)
    {
        _idPortalService = idPortalService;
    }
    public async Task<ViewResult> UserIndex()
    {
        var response = await _idPortalService.GetCategoriesAsync<List<UserDto>>();
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
            var response = await _idPortalService.CreateCategoryAsync<UserDto>(model);
            List<ResponseDto> list = null;
            // if (response != null && response.IsSuccess)
            // {
            //     list = JsonConvert.DeserializeObject<List<ResponseDto>>(response.ToString());
            // }
            // if (response == null)
            //     return View(model);
            return RedirectToAction(nameof(UserIndex));
        }
        return View(model);
    }
    
    public async Task<IActionResult> EditUser(string userId)
    {
        var response = await _idPortalService.GetCategoryByIdAsync<UserDto>(userId);
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
            var response = await _idPortalService.UpdateUserAsync<UserDto>(model.Id, model);
            List<ResponseDto> list = null;
            // if (response != null && response.IsSuccess)
            // {
            //     list = JsonConvert.DeserializeObject<List<ResponseDto>>(response.ToString());
            // }
            // if (response == null)
            //     return View(model);
            return RedirectToAction(nameof(UserIndex));
        }
        return View(model);
    }
    
    public async Task<IActionResult> DeleteUser(string userId)
    {
        var response = await _idPortalService.GetCategoryByIdAsync<UserDto>(userId);
        List<ResponseDto> list = null;
        if (response != null )
            return View(response);
        return NotFound();

    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteUser(UserDto model)
    {
        await _idPortalService.DeleteUserAsync<UserDto>(model.Id);
            return RedirectToAction(nameof(UserIndex));
            
    }
}