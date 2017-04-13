using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recipe.Models
{
    public partial class Recipe
    {
        public Recipe()
        {
            Direction = new HashSet<Direction>();
            Ingredient = new HashSet<Ingredient>();
            RecipeCategory = new HashSet<RecipeCategory>();
        }

        public long Id { get; set; }
        [MaxLength(1024)]
        public string Title { get; set; }
        [Column(TypeName = "decimal")]
        public decimal? ServingQuantity { get; set; }
        [MaxLength(50)]
        public string ServingMeasure { get; set; }

        [InverseProperty("Recipe")]
        public virtual ICollection<Direction> Direction { get; set; }
        [InverseProperty("Recipe")]
        public virtual ICollection<Ingredient> Ingredient { get; set; }
        [InverseProperty("Recipe")]
        public virtual ICollection<RecipeCategory> RecipeCategory { get; set; }
    }
}
