using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recipe.Dal.Models
{
    [Table("Direction")]
    public partial class Direction
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public long LineNumber { get; set; }
        public string Description { get; set; }
        public long? RecipeId { get; set; }

        [ForeignKey("RecipeId")]
        [InverseProperty("Directions")]
        public virtual Recipe Recipe { get; set; }
    }
}
