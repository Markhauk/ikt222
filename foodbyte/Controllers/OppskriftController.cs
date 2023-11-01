using foodbyte.Data;
using foodbyte.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace foodbyte.Controllers;

public class OppskriftController : Controller
{
    
    private ApplicationDbContext _db;

    
    public OppskriftController(ApplicationDbContext db)
    {
        _db = db;
        
    }
    
    // GET
    public IActionResult Oppskrift()
    {
        var recepies = _db.Recipes.ToList();
        return View(recepies);
        

    }

    public async Task<IActionResult> ViewRecipe(int? id)
    {
        if (id == null || _db.Recipes == null)
        {
            return NotFound();
        }

        var recipes = await _db.Recipes 
            .Include(p => p.User)
            .FirstOrDefaultAsync(m => m.Id == id);
        if (recipes == null)
        {
            return NotFound();
        }

        return View(recipes);
    }

    
    
}