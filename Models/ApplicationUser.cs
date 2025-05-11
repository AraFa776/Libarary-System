using Microsoft.AspNetCore.Identity;

namespace BookShoppingCartMvcUI.Models;

public class ApplicationUser : IdentityUser
{
    public string FullName { get; set; }
}