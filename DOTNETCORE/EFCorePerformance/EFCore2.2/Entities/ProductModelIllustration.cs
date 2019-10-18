using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore2.Entities
{
    [Table("ProductModelIllustration", Schema = "Production")]
    public partial class ProductModelIllustration
    {
        [Column("ProductModelID")]
        public int ProductModelId { get; set; }
        [Column("IllustrationID")]
        public int IllustrationId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }

        [ForeignKey("IllustrationId")]
        [InverseProperty("ProductModelIllustration")]
        public virtual Illustration Illustration { get; set; }
        [ForeignKey("ProductModelId")]
        [InverseProperty("ProductModelIllustration")]
        public virtual ProductModel ProductModel { get; set; }
    }
}
