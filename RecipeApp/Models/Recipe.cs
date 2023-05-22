using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecipeApp.Models
{
    public class Recipe
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        [Required]
        [StringLength(30)]
        public string Category { get; set; }

        public string? UserId { get; set; }

        [Required]
        [Range(1, 300)]
        public int PrepareTime { get; set; } = 1;

        [Required]
        [Range(1, 50)]
        public int Portions { get; set; } = 1;

        public int Likes { get; set; } = 0;

        public byte[]? ImageData { get; set; }
    }
}
