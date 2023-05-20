using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecipeApp.Models
{
    public class RecipeLike
    {
        public string UserId { get; set; }
        public int RecipeId { get; set; }
    }
}
