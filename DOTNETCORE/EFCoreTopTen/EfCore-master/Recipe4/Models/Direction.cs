using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recipe.Models
{
    public partial class Direction
    {
        public long Id { get; set; }
        public long LineNumber { get; set; }
        public string Description { get; set; }
        public long? RecipeId { get; set; }

        [ForeignKey("RecipeId")]
        [InverseProperty("Direction")]
        public virtual Recipe Recipe { get; set; }
    }
}
