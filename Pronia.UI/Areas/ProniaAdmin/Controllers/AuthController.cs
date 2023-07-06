using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Pronia.Core.Entities;
using Pronia.Core.Utilities;
using Pronia.UI.Areas.ViewModels;

namespace Pronia.UI.Areas.ProniaAdmin.Controllers;

[Area("ProniaAdmin")]
public class AuthController : Controller
{
    private  readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    public AuthController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager,  RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _roleManager = roleManager;
    }
    public IActionResult Register()
	{
		return View();
	}
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(RegisterVM newUser)
    {
        if (!ModelState.IsValid)
        {
            return View(newUser);
        }
        AppUser user = new()
        {
            Fullname = newUser.Fullname,
            UserName = newUser.Username,
            Email = newUser.Email,
        };
       IdentityResult result = await _userManager.CreateAsync(user, newUser.Password);
        if (!result.Succeeded)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            return View(newUser);
        }
        //await _userManager.AddToRoleAsync(user, UserRole.Admin); First time to sign up as admin
        await _userManager.AddToRoleAsync(user, UserRole.Member);
        return RedirectToAction(nameof(Login));
    }

    public IActionResult Login()
    {
        return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
  
    public async Task<IActionResult> Login(LoginVM login)
    {
        if (!ModelState.IsValid)
        {
            return View(login);
        }
       AppUser user = await _userManager.FindByEmailAsync(login.Email);
        if (user == null)
        {
            ModelState.AddModelError("","Invalid input");
            return View(login);
        }
        Microsoft.AspNetCore.Identity.SignInResult signInResult = await _signInManager.PasswordSignInAsync(user, login.Password, login.RememberMe, true);
        if (signInResult.IsLockedOut)
        {
            ModelState.AddModelError("", "Your Account is locked! Try After");
            return View(login);
        }
        if (!signInResult.Succeeded)
        {
            ModelState.AddModelError("", "Invalid input");
            return View(login);
        }

        return RedirectToAction("Index", "Home", new { area = string.Empty });
    }

    [Authorize]
    public async Task<IActionResult> Logout()
    {
        if (User.Identity.IsAuthenticated)
        {
            await _signInManager.SignOutAsync();
        }

        return RedirectToAction("Index", "Home" ,new {area = string.Empty});   
    }

    #region CreateRole
    //[AllowAnonymous]
    //public async Task CreateRole()
    //{
    //    foreach (var role in Enum.GetValues(typeof(UserRole.Roles)))
    //    {
    //        bool isExist = await _roleManager.RoleExistsAsync(role.ToString());
    //        if (!isExist)
    //        {
    //            await _roleManager.CreateAsync(new IdentityRole
    //            {
    //                Name = role.ToString()
    //            });
    //        }
    //    }
    //}
    #endregion
}
