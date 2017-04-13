using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recipe.Models
{
    public partial class RecipeCategory
    {
        public long RecipeId { get; set; }
        public long CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        [InverseProperty("RecipeCategory")]
        public virtual Category Category { get; set; }
        [ForeignKey("RecipeId")]
        [InverseProperty("RecipeCategory")]
        public virtual Recipe Recipe { get; set; }
    }
}
