using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recipe.Models
{
    public partial class Category
    {
        public Category()
        {
            RecipeCategory = new HashSet<RecipeCategory>();
        }

        public long Id { get; set; }
        [MaxLength(50)]
        public string Description { get; set; }

        [InverseProperty("Category")]
        public virtual ICollection<RecipeCategory> RecipeCategory { get; set; }
    }
}
