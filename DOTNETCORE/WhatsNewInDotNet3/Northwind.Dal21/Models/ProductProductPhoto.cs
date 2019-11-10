using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Northwind.Dal21.Models
{
    [Table("ProductProductPhoto", Schema = "Production")]
    public partial class ProductProductPhoto
    {
        [Column("ProductID")]
        public int ProductId { get; set; }
        [Column("ProductPhotoID")]
        public int ProductPhotoId { get; set; }
        [Column(TypeName = "Flag")]
        public bool Primary { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }

        [ForeignKey("ProductId")]
        [InverseProperty("ProductProductPhoto")]
        public Product Product { get; set; }
        [ForeignKey("ProductPhotoId")]
        [InverseProperty("ProductProductPhoto")]
        public ProductPhoto ProductPhoto { get; set; }
    }
}
