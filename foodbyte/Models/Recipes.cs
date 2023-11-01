using System.ComponentModel;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net.Mime;

namespace foodbyte.Models;

public class Recipes
{
    public Recipes(){}

    public Recipes(string title,string image, int stars, string description, string ingredients, string method, int xp, string timeToMake, string difficulty, ApplicationUser user)
    {
        Title = title;
        Image = image;
        Stars = stars;
        Description = description;
        Ingredients = ingredients;
        Method = method;
        Xp = xp;
        TimeToMake = timeToMake;
        Difficulty = difficulty;
        User = user;
    }
    
    public int Id { get; set; }

    [Required]
    [DisplayName("Title")]
    public string? Title { get; set; } = string.Empty;
    
    [Required]
    [DisplayName("Image")]
    public string? Image { get; set; } = string.Empty;
    
    [Required]
    [DisplayName("Description")]
    public string? Description { get; set; } = string.Empty;
    
    public int Stars { get; set; }
    
    [Required]
    [DisplayName("Ingredients")]
    public string? Ingredients { get; set; } = String.Empty;

    [Required]
    [DisplayName("Method")]
    public string? Method { get; set; } = string.Empty;
    
    public ApplicationUser User { get; set; }
    
    [Required]
    [DisplayName("Xp")]
    public int Xp { get; set; }
    
    [Required]
    [DisplayName("TimeToMake")]
    public string? TimeToMake { get; set; } = string.Empty;
    
    [Required]
    [DisplayName("Difficulty")]
    public string? Difficulty { get; set; } = string.Empty;
    
}
