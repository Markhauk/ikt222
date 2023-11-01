using foodbyte.Models;
using Microsoft.AspNetCore.Identity;

namespace foodbyte.Data;

public class ApplicationDbInitializer
{
    public static void Initialize(ApplicationDbContext db, UserManager<ApplicationUser> um, RoleManager<IdentityRole> rm)
    {
        db.Database.EnsureDeleted();
        db.Database.EnsureCreated();
        
        var adminRole = new IdentityRole("Admin");
        rm.CreateAsync(adminRole).Wait();
        
        //add standard users

        var admin = new ApplicationUser
            { UserName = "admin@uia.no", 
                Email = "admin@uia.no", 
                Nickname = "AdminUser",
                EmailConfirmed = true};
        
        um.CreateAsync(admin, "Password1.").Wait();
        um.AddToRoleAsync(admin, "Admin").Wait();
        
        
        var user = new ApplicationUser
            { UserName = "user@uia.no", 
                Email = "user@uia.no", 
                Nickname = "User", 
                EmailConfirmed = true};
       
        um.CreateAsync(user, "Password1.").Wait();
        
        var recipes = new[]
        {
            new Recipes("Carbonara", "url", 4,"dette er en enkel suppe dette er en enkel suppe dette er en enkel suppe dette er en enkel suppe dette er en enkel suppe dette er en enkel suppe dette er en enkel suppe dette er en enkel suppe"
                , "ingredienser", "trinn 1. lag carbonara trinn 2. lage pasta trinn 3. lage saus trinn 4. lage blande alt trinn 5. spis maten", 3000, "20 min","Lett", user
                                                ),
            new Recipes("Tomatsuppe", "url", 5,"dette er en enkel suppe", "ingredients", "trinn 1. lag tomat suppe", 3000, "450 min","Vanskelig", admin),
            new Recipes("Pannekaker", "url", 5,"pannekaker er best", "egg, smør, salt, mel, melk", "trinn 1. lag pannekaker", 3000, "30 min","Medium", user),
            new Recipes("Lørdags Biff", "url", 5,"endelig lørdag", "biff, bernaisesaus, søtpotet, asparges", "trinn 1. stek biffen medium rare", 3000, "10 min","Lett", user)
        };
        
        
       
        
        
        db.Recipes.AddRange(recipes);
        
        db.SaveChanges();
    }

 
}