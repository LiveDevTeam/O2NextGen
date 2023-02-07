using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using O2Bionics.Services.IdPortal.DbContexts;
using O2Bionics.Services.IdPortal.Mappings;
using O2Bionics.Services.IdPortal.Models;
using O2Bionics.Services.IdPortal.ViewModels;

namespace O2Bionics.Services.IdPortal.Controllers;

[Route("Users")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;

    public UserController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var user = await _userManager.Users.ToListAsync();
        return Ok(user.ToService());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id)
    {
        var users = await _userManager.Users.ToListAsync();
        var findUser = users.FirstOrDefault(_ => _.Id == id);
        if (findUser == null)
            return NotFound();
        return Ok(findUser.ToService());
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(string id, User user)
    {
        var users = await _userManager.Users.ToListAsync();
        var findUser = users.FirstOrDefault(_ => _.Id == id);
        if (findUser == null)
            return NotFound();

        findUser.FirstName = user.FirstName;
        findUser.LastName = user.LastName;
        findUser.Email = user.Email;
        findUser.UserName = user.UserName;
        findUser.EmailConfirmed = user.EmailConfirmed;
        findUser.PhoneNumber = user.PhoneNumber;
        findUser.LockoutEnabled = user.LockoutEnabled;

        await _userManager.UpdateAsync(findUser);
        return Ok(findUser.ToService());
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteById(string id)
    {
        var users = await _userManager.Users.ToListAsync();
        var findUser = users.FirstOrDefault(_ => _.Id == id);
        await _userManager.DeleteAsync(findUser);
        return NoContent();
    }
}