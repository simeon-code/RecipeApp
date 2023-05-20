using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RecipeApp.Areas.Identity.Data;
using RecipeApp.Data;
using RecipeApp.Models;

namespace RecipeApp.Pages.RecipePage
{
    public class DetailsModel : PageModel
    {
        private readonly RecipeApp.Data.ApplicationDbContext _context;
        private readonly UserManager<RecipeAppUser> _userManager;

        public DetailsModel(RecipeApp.Data.ApplicationDbContext context, UserManager<RecipeAppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

      public Recipe Recipe { get; set; } = default!;

        [BindProperty]
        public string LikeDislike { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Recipes == null)
            {
                return NotFound();
            }

            var recipe = await _context.Recipes.FirstOrDefaultAsync(m => m.Id == id);
            if (recipe == null)
            {
                return NotFound();
            }
            else 
            {
                Recipe = recipe;
                if (_context.RecipeLikes.Any(rl => rl.RecipeId == id && rl.UserId == _userManager.GetUserId(User)))
                {
                    LikeDislike = "Dislike";
                }
                else
                {
                    LikeDislike = "Like";
                };
            }
            return Page();
        }

        public async Task<IActionResult> OnPostLikeAsync(int id)
        {
            var recipe = await _context.Recipes.FirstOrDefaultAsync(m => m.Id == id);
            if (recipe == null)
            {
                return NotFound();
            }
            var userId = _userManager.GetUserId(User);

            var alreadyLiked = _context.RecipeLikes.Any(rl => rl.RecipeId == id && rl.UserId == userId);
            if (alreadyLiked)
            {
                var existingLike = _context.RecipeLikes.FirstOrDefault(rl => rl.RecipeId == id && rl.UserId == userId);
                if(existingLike != null)
                {
                    recipe.Likes--;
                    _context.RecipeLikes.Remove(existingLike);
                    await _context.SaveChangesAsync();
                }
            }
            else
            {
                recipe.Likes++;
                _context.RecipeLikes.Add(new RecipeLike { RecipeId = id , UserId = userId});
                await _context.SaveChangesAsync();
            }
            return Redirect("~/RecipePage/Details?id=" + id) ;
         }
    }
}
