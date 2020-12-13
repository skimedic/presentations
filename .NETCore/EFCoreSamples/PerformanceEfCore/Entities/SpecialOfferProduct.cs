using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PerformanceEfCore.Entities
{
    [Table("SpecialOfferProduct", Schema = "Sales")]
    public partial class SpecialOfferProduct
    {
        public SpecialOfferProduct()
        {
            SalesOrderDetail = new HashSet<SalesOrderDetail>();
        }

        [Key]
        [Column("SpecialOfferID")]
        public int SpecialOfferId { get; set; }
        [Key]
        [Column("ProductID")]
        public int ProductId { get; set; }
        [Column("rowguid")]
        public Guid Rowguid { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }

        [ForeignKey(nameof(ProductId))]
        [InverseProperty("SpecialOfferProduct")]
        public virtual Product Product { get; set; }
        [ForeignKey(nameof(SpecialOfferId))]
        [InverseProperty("SpecialOfferProduct")]
        public virtual SpecialOffer SpecialOffer { get; set; }
        [InverseProperty("SpecialOfferProduct")]
        public virtual ICollection<SalesOrderDetail> SalesOrderDetail { get; set; }
    }
}
