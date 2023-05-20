using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace RecipeApp.Areas.Identity.Data;

// Add profile data for application users by adding properties to the RecipeAppUser class
public class RecipeAppUser : IdentityUser
{
    public string? FullName { get; set; }
}

