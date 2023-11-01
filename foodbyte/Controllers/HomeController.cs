using System.Diagnostics; 
using Microsoft.AspNetCore.Mvc; 
using foodbyte.Models; 
using foodbyte.Data;
using Microsoft.EntityFrameworkCore;

namespace foodbyte.Controllers; 
 
public class HomeController : Controller 
{ 
    private ApplicationDbContext _db; 
 
    public HomeController(ApplicationDbContext db) 
    { 
        _db = db; 
    }

    
    [HttpGet] 
    public IActionResult Index() 
    { 
        var recipes = _db.Recipes.ToList(); 
         
        return View(recipes); 
    } 
 
    public async Task<IActionResult> Search(string searchString)
    {
       
        var recipes = from r in _db.Recipes
            select r;

        if (!String.IsNullOrEmpty(searchString))
        {
            recipes = recipes.Where(r => r.Title!.Contains(searchString));
            
        }

        return View(await recipes.ToListAsync());
    }
 
    public IActionResult Privacy() 
    { 
        return View(); 
    } 
 
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)] 
    public IActionResult Error() 
    { 
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier }); 
    } 
}