using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Northwind.Dal21.Models
{
    [Table("SpecialOfferProduct", Schema = "Sales")]
    public partial class SpecialOfferProduct
    {
        public SpecialOfferProduct()
        {
            SalesOrderDetail = new HashSet<SalesOrderDetail>();
        }

        [Column("SpecialOfferID")]
        public int SpecialOfferId { get; set; }
        [Column("ProductID")]
        public int ProductId { get; set; }
        [Column("rowguid")]
        public Guid Rowguid { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }

        [ForeignKey("ProductId")]
        [InverseProperty("SpecialOfferProduct")]
        public Product Product { get; set; }
        [ForeignKey("SpecialOfferId")]
        [InverseProperty("SpecialOfferProduct")]
        public SpecialOffer SpecialOffer { get; set; }
        [InverseProperty("SpecialOfferProduct")]
        public ICollection<SalesOrderDetail> SalesOrderDetail { get; set; }
    }
}
