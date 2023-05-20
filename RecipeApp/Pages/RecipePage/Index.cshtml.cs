using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RecipeApp.Data;
using RecipeApp.Models;

namespace RecipeApp.Pages.RecipePage
{
    public class IndexModel : PageModel
    {
        private readonly RecipeApp.Data.ApplicationDbContext _context;

        public IndexModel(RecipeApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Recipe> Recipe { get;set; } = default!;

        [BindProperty(SupportsGet =true)] //required for binding on http get request
        public string? SearchString { get; set; }

        public SelectList? Categories { get; set; }

        [BindProperty(SupportsGet =true)]
        public string? RecipeCategory { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<String> categoryQuery = from r in _context.Recipes
                                               orderby r.Category
                                               select r.Category;

            var recipes = from recipe in _context.Recipes select recipe;
            if(!string.IsNullOrEmpty(SearchString))
            {
                recipes = recipes.Where(s=>s.Name.Contains(SearchString));
            }

            if(!string.IsNullOrEmpty(RecipeCategory))
            {
                recipes = recipes.Where(x => x.Category == RecipeCategory);
            }

            Categories = new SelectList(await categoryQuery.Distinct().ToListAsync());
            Recipe = await recipes.ToListAsync();
            
        }
    }
}
