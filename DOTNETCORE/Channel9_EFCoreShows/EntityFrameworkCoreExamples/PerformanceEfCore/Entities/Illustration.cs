using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PerformanceEfCore.Entities
{
    [Table("Illustration", Schema = "Production")]
    public partial class Illustration
    {
        public Illustration()
        {
            ProductModelIllustration = new HashSet<ProductModelIllustration>();
        }

        [Key]
        [Column("IllustrationID")]
        public int IllustrationId { get; set; }
        [Column(TypeName = "xml")]
        public string Diagram { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }

        [InverseProperty("Illustration")]
        public virtual ICollection<ProductModelIllustration> ProductModelIllustration { get; set; }
    }
}
