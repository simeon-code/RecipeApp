using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecipeApp.Models
{
    public class Recipe
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public string Category { get; set; }

        public string? UserId { get; set; }
        public int PrepareTime { get; set; } = 0;
        public int Portions { get; set; } = 0;

        public int Likes { get; set; } = 0;

        public byte[]? ImageData { get; set; }
    }
}
