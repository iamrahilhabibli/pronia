using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pronia.Core.Utilities;
using Pronia.DataAccess.Contexts;

namespace Pronia.UI.Areas.ProniaAdmin.Controllers;
[Area("ProniaAdmin")]
[Authorize(Roles = UserRole.Admin)]
public class SliderController : Controller
{
	private readonly AppDbContext _context;
    public SliderController(AppDbContext context)
    {
        _context = context;
    }
    public async Task<IActionResult> Index()
	{
		return View(await _context.Sliders.ToListAsync());
	}
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }
}
