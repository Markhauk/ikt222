using Microsoft.AspNetCore.Identity;
using Microsoft.Build.Framework;

namespace foodbyte.Models;

public class ApplicationUser : IdentityUser
{
    [Required]
    public string Nickname { get; set; } = string.Empty;
    
    public byte[]? ProfilePicture { get; set; }
}