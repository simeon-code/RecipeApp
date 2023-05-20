using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RecipeApp.Areas.Identity.Data;
using RecipeApp.Data;
using RecipeApp.Models;

namespace RecipeApp.Pages.RecipePage
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly RecipeApp.Data.ApplicationDbContext _context;
        private readonly UserManager<RecipeAppUser> _userManager;

        public CreateModel(RecipeApp.Data.ApplicationDbContext context, UserManager<RecipeAppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public SelectList Categories { get; set; }

        [BindProperty]
        public Recipe Recipe { get; set; } = default!;

        [BindProperty]
        public IFormFile ImageFile { get; set; }


        public IActionResult OnGet()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToPage("./Index");
            }
            else
            {
                Categories = new SelectList(new[]
                {
                    new {Value="Appertizer", Text = "Appetizer"},
                    new {Value="Main Dish", Text = "Main Dish"},
                    new {Value="Side Dish", Text = "Side Dish"},
                    new {Value="Dessert", Text = "Dessert"},
                    new {Value="Drink", Text = "Drink"},
                    new {Value="Other", Text = "Other"},
                }, "Value", "Text");

                return Page();
            }
        }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Categories = new SelectList(new[]
               {
                    new {Value="Appertizer", Text = "Appetizer"},
                    new {Value="Main Dish", Text = "Main Dish"},
                    new {Value="Side Dish", Text = "Side Dish"},
                    new {Value="Dessert", Text = "Dessert"},
                    new {Value="Drink", Text = "Drink"},
                    new {Value="Other", Text = "Other"},
                }, "Value", "Text");

                return Page();
            }

            var recipe = new Recipe
            {
                Name = Recipe.Name,
                Description = Recipe.Description,
                Portions = Recipe.Portions,
                PrepareTime = Recipe.PrepareTime,
                Category = Recipe.Category,
            };

            var currentUser = await _userManager.GetUserAsync(User);
            var currentUserId = currentUser.Id;

            recipe.UserId = currentUserId;

            if(ImageFile!=null && ImageFile.Length > 0)
            {
                using (var ms=new MemoryStream())
                {
                    await ImageFile.CopyToAsync(ms);
                    recipe.ImageData = ms.ToArray();
                }
            }


            _context.Recipes.Add(recipe);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
