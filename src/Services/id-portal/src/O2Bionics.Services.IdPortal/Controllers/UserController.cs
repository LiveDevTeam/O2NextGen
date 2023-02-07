using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using O2Bionics.Services.IdPortal.DbContexts;
using O2Bionics.Services.IdPortal.Mappings;
using O2Bionics.Services.IdPortal.Models;

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
        var findUser = users.FirstOrDefault(_=>_.Id ==id);
        if (findUser == null)
            return NotFound();
        return Ok(findUser.ToService());
    }
}