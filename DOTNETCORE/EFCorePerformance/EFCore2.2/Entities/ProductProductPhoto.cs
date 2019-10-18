using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore2.Entities
{
    [Table("ProductProductPhoto", Schema = "Production")]
    public partial class ProductProductPhoto
    {
        [Column("ProductID")]
        public int ProductId { get; set; }
        [Column("ProductPhotoID")]
        public int ProductPhotoId { get; set; }
        public bool Primary { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }

        [ForeignKey("ProductId")]
        [InverseProperty("ProductProductPhoto")]
        public virtual Product Product { get; set; }
        [ForeignKey("ProductPhotoId")]
        [InverseProperty("ProductProductPhoto")]
        public virtual ProductPhoto ProductPhoto { get; set; }
    }
}
