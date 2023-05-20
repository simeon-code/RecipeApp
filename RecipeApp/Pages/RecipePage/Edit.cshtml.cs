using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RecipeApp.Areas.Identity.Data;
using RecipeApp.Data;
using RecipeApp.Models;

namespace RecipeApp.Pages.RecipePage
{
    [Authorize]
    public class EditModel : PageModel
    {
        private readonly RecipeApp.Data.ApplicationDbContext _context;
        private readonly UserManager<RecipeAppUser> _userManager; 

        public EditModel(RecipeApp.Data.ApplicationDbContext context, UserManager<RecipeAppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [BindProperty]
        public Recipe Recipe { get; set; } = default!;
        [BindProperty]
        public IFormFile ImageFile { get; set; }

        public SelectList Categories { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Recipes == null)
            {
                return NotFound();
            }

            var recipe =  await _context.Recipes.FirstOrDefaultAsync(m => m.Id == id);
            if (recipe == null)
            {
                return NotFound();
            }
            var userId = _userManager.GetUserId(User);
            if (recipe.UserId != userId)
            {
                return RedirectToPage("../AccessDenied");
            }

            Categories = new SelectList(new[]
                {
                    new {Value="Appertizer", Text = "Appetizer"},
                    new {Value="Main Dish", Text = "Main Dish"},
                    new {Value="Side Dish", Text = "Side Dish"},
                    new {Value="Dessert", Text = "Dessert"},
                    new {Value="Drink", Text = "Drink"},
                    new {Value="Other", Text = "Other"},
                }, "Value", "Text");

            Recipe = recipe;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var currentUser = await _userManager.GetUserAsync(User);
            var currentUserId = currentUser.Id;

            Recipe.UserId = currentUserId;

            if (ImageFile != null && ImageFile.Length > 0)
            {
                using (var ms = new MemoryStream())
                {
                    await ImageFile.CopyToAsync(ms);
                    Recipe.ImageData = ms.ToArray();
                }
            }
            Recipe.Id = id;
            _context.Attach(Recipe).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecipeExists(Recipe.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool RecipeExists(int id)
        {
          return (_context.Recipes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
