using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recipe.Dal.Models
{
    [Table("RecipeCategory")]
    public partial class RecipeCategory
    {
        public long RecipeId { get; set; }
        public long CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        [InverseProperty("RecipeCategories")]
        public virtual Category Category { get; set; }
        [ForeignKey("RecipeId")]
        [InverseProperty("RecipeCategories")]
        public virtual Recipe Recipe { get; set; }
    }
}
