using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PerformanceEfCore.Entities
{
    [Table("ProductModelIllustration", Schema = "Production")]
    public partial class ProductModelIllustration
    {
        [Key]
        [Column("ProductModelID")]
        public int ProductModelId { get; set; }
        [Key]
        [Column("IllustrationID")]
        public int IllustrationId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }

        [ForeignKey(nameof(IllustrationId))]
        [InverseProperty("ProductModelIllustration")]
        public virtual Illustration Illustration { get; set; }
        [ForeignKey(nameof(ProductModelId))]
        [InverseProperty("ProductModelIllustration")]
        public virtual ProductModel ProductModel { get; set; }
    }
}
