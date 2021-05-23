using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Northwind.Dal21.Models
{
    [Table("SalesOrderHeader", Schema = "Sales")]
    public partial class SalesOrderHeader
    {
        public SalesOrderHeader()
        {
            SalesOrderDetail = new HashSet<SalesOrderDetail>();
            SalesOrderHeaderSalesReason = new HashSet<SalesOrderHeaderSalesReason>();
        }

        [Key]
        [Column("SalesOrderID")]
        public int SalesOrderId { get; set; }
        public byte RevisionNumber { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime OrderDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DueDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ShipDate { get; set; }
        public byte Status { get; set; }
        [Required]
        [Column(TypeName = "Flag")]
        public bool? OnlineOrderFlag { get; set; }
        [Required]
        [StringLength(25)]
        public string SalesOrderNumber { get; set; }
        [Column(TypeName = "OrderNumber")]
        [StringLength(25)]
        public string PurchaseOrderNumber { get; set; }
        [Column(TypeName = "AccountNumber")]
        [StringLength(15)]
        public string AccountNumber { get; set; }
        [Column("CustomerID")]
        public int CustomerId { get; set; }
        [Column("SalesPersonID")]
        public int? SalesPersonId { get; set; }
        [Column("TerritoryID")]
        public int? TerritoryId { get; set; }
        [Column("BillToAddressID")]
        public int BillToAddressId { get; set; }
        [Column("ShipToAddressID")]
        public int ShipToAddressId { get; set; }
        [Column("ShipMethodID")]
        public int ShipMethodId { get; set; }
        [Column("CreditCardID")]
        public int? CreditCardId { get; set; }
        [StringLength(15)]
        public string CreditCardApprovalCode { get; set; }
        [Column("CurrencyRateID")]
        public int? CurrencyRateId { get; set; }
        [Column(TypeName = "money")]
        public decimal SubTotal { get; set; }
        [Column(TypeName = "money")]
        public decimal TaxAmt { get; set; }
        [Column(TypeName = "money")]
        public decimal Freight { get; set; }
        [Column(TypeName = "money")]
        public decimal TotalDue { get; set; }
        [StringLength(128)]
        public string Comment { get; set; }
        [Column("rowguid")]
        public Guid Rowguid { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }

        [ForeignKey("BillToAddressId")]
        [InverseProperty("SalesOrderHeaderBillToAddress")]
        public Address BillToAddress { get; set; }
        [ForeignKey("CreditCardId")]
        [InverseProperty("SalesOrderHeader")]
        public CreditCard CreditCard { get; set; }
        [ForeignKey("CurrencyRateId")]
        [InverseProperty("SalesOrderHeader")]
        public CurrencyRate CurrencyRate { get; set; }
        [ForeignKey("CustomerId")]
        [InverseProperty("SalesOrderHeader")]
        public Customer Customer { get; set; }
        [ForeignKey("SalesPersonId")]
        [InverseProperty("SalesOrderHeader")]
        public SalesPerson SalesPerson { get; set; }
        [ForeignKey("ShipMethodId")]
        [InverseProperty("SalesOrderHeader")]
        public ShipMethod ShipMethod { get; set; }
        [ForeignKey("ShipToAddressId")]
        [InverseProperty("SalesOrderHeaderShipToAddress")]
        public Address ShipToAddress { get; set; }
        [ForeignKey("TerritoryId")]
        [InverseProperty("SalesOrderHeader")]
        public SalesTerritory Territory { get; set; }
        [InverseProperty("SalesOrder")]
        public ICollection<SalesOrderDetail> SalesOrderDetail { get; set; }
        [InverseProperty("SalesOrder")]
        public ICollection<SalesOrderHeaderSalesReason> SalesOrderHeaderSalesReason { get; set; }
    }
}
