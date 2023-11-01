using foodbyte.Data;
using foodbyte.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace foodbyte.Controllers;

public class MyRecipesController : Controller
{
    private readonly ApplicationDbContext _db;
    private readonly UserManager<ApplicationUser> _um;
    public MyRecipesController(ApplicationDbContext db, UserManager<ApplicationUser> um)
    {
        _db = db;
        _um = um;
    }
    
    [Authorize]
    [HttpGet]
    public IActionResult Index()
    {
        var user = _um.GetUserAsync(User).Result;
        if (user != null)
        {
            var recipes = _db.Recipes.Where(r =>r.User == user);
            return View(recipes);
        }
        return RedirectToAction(nameof(Index));
        
    }
    
    //add
    
    // GET: Blog/Create
    [HttpGet]
    [Authorize]
    public IActionResult Add()
    {
        ViewData["UserId"] = new SelectList(_db.Users, "Id", "Id");
        return View();
    }

   
    // To protect from overposting attacks, enable the specific properties you want to bind to.// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize]
    public async Task<IActionResult> Add([Bind("Title,Description,Ingredients,Method")] Recipes recipes)
    {

        var userId = _um.GetUserAsync(User).Result;
        recipes.User = userId;
            
        
            _db.Add(recipes);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        
        
    }
    
    //Edit action
    [Authorize]
    [HttpGet]
    public IActionResult Edit(int id)
    {
        var user = _um.GetUserAsync(User).Result;
        var recipe = _db.Recipes.Single(b => b.Id == id);
        if (user != null)
        {
            if (user == recipe.User)
            {
                return View(recipe);
            }
        }
        return RedirectToAction(nameof(Index));
    }
    [HttpPost]
    public IActionResult Edit(Recipes recipe)
    {
        var user = _um.GetUserAsync(User).Result;
        var old = _db.Recipes.Single(r => r.Id == recipe.Id);
        _db.Recipes.Remove(old);
        recipe.User = user;
        _db.Recipes.Add(recipe);
        _db.SaveChanges();

        return RedirectToAction(nameof(Index));
    }
    
    //Delete Action
    [Authorize]
    [HttpGet]
    public IActionResult Delete(int id)
    {
        var user = _um.GetUserAsync(User).Result;
        var recipe = _db.Recipes.Single(b => b.Id == id);
        if (user != null)
        {
            if (user == recipe.User)
            {
                return View(recipe);
            }
        }
        return RedirectToAction(nameof(Index));
    }
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int id)
    {
        Recipes recipe = _db.Recipes.Find(id);
        _db.Recipes.Remove(recipe);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }
    
    
    
    
}