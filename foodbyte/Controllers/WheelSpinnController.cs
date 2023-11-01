using foodbyte.Data;
using Microsoft.AspNetCore.Mvc;

namespace foodbyte.Controllers;

public class WheelSpinnController : Controller
{
    private ApplicationDbContext _db; 
 
    public WheelSpinnController(ApplicationDbContext db) 
    { 
        _db = db; 
    }
    
    
    
    public IActionResult SpinnWheel()
    {
        var recipes = _db.Recipes.ToList();
        return View(recipes);
    } 
    
    public IActionResult ViewRecipe()
    {
        Thread.Sleep(6000);
        Random rand = new Random();
        int toSkip = rand.Next(0, _db.Recipes.Count());
        
        _db.Recipes.Skip(toSkip).Take(1).First();
        
        //int index = _db.Recipes.FindIndex(a => a.Prop == oProp);
        var recepies = _db.Recipes.ToList();
        
        
        return View(recepies);
    }

    
    [HttpGet]
    public IActionResult Oppskrift(int id)
    {
        var recepies = _db.Recipes.ToList();
        var recipe = _db.Recipes.Single(b => b.Id == id);


        Random rand = new Random();
        int toSkip = rand.Next(0, _db.Recipes.Count());

        var personToCall = _db.Recipes.OrderBy(r => Guid.NewGuid()).Skip(toSkip).Take(1).First();
        
        return RedirectToAction(nameof(ViewRecipe));
        
    }
}