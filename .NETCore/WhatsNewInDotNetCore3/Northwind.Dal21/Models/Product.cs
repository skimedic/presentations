using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Northwind.Dal21.Models
{
    [Table("Product", Schema = "Production")]
    public partial class Product
    {
        public Product()
        {
            BillOfMaterialsComponent = new HashSet<BillOfMaterials>();
            BillOfMaterialsProductAssembly = new HashSet<BillOfMaterials>();
            ProductCostHistory = new HashSet<ProductCostHistory>();
            ProductInventory = new HashSet<ProductInventory>();
            ProductListPriceHistory = new HashSet<ProductListPriceHistory>();
            ProductProductPhoto = new HashSet<ProductProductPhoto>();
            ProductReview = new HashSet<ProductReview>();
            ProductVendor = new HashSet<ProductVendor>();
            PurchaseOrderDetail = new HashSet<PurchaseOrderDetail>();
            ShoppingCartItem = new HashSet<ShoppingCartItem>();
            SpecialOfferProduct = new HashSet<SpecialOfferProduct>();
            TransactionHistory = new HashSet<TransactionHistory>();
            WorkOrder = new HashSet<WorkOrder>();
        }

        [Column("ProductID")]
        public int ProductId { get; set; }
        [Required]
        [Column(TypeName = "Name")]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(25)]
        public string ProductNumber { get; set; }
        [Required]
        [Column(TypeName = "Flag")]
        public bool? MakeFlag { get; set; }
        [Required]
        [Column(TypeName = "Flag")]
        public bool? FinishedGoodsFlag { get; set; }
        [StringLength(15)]
        public string Color { get; set; }
        public short SafetyStockLevel { get; set; }
        public short ReorderPoint { get; set; }
        [Column(TypeName = "money")]
        public decimal StandardCost { get; set; }
        [Column(TypeName = "money")]
        public decimal ListPrice { get; set; }
        [StringLength(5)]
        public string Size { get; set; }
        [StringLength(3)]
        public string SizeUnitMeasureCode { get; set; }
        [StringLength(3)]
        public string WeightUnitMeasureCode { get; set; }
        [Column(TypeName = "decimal(8, 2)")]
        public decimal? Weight { get; set; }
        public int DaysToManufacture { get; set; }
        [StringLength(2)]
        public string ProductLine { get; set; }
        [StringLength(2)]
        public string Class { get; set; }
        [StringLength(2)]
        public string Style { get; set; }
        [Column("ProductSubcategoryID")]
        public int? ProductSubcategoryId { get; set; }
        [Column("ProductModelID")]
        public int? ProductModelId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime SellStartDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? SellEndDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DiscontinuedDate { get; set; }
        [Column("rowguid")]
        public Guid Rowguid { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }

        [ForeignKey("ProductModelId")]
        [InverseProperty("Product")]
        public ProductModel ProductModel { get; set; }
        [ForeignKey("ProductSubcategoryId")]
        [InverseProperty("Product")]
        public ProductSubcategory ProductSubcategory { get; set; }
        [ForeignKey("SizeUnitMeasureCode")]
        [InverseProperty("ProductSizeUnitMeasureCodeNavigation")]
        public UnitMeasure SizeUnitMeasureCodeNavigation { get; set; }
        [ForeignKey("WeightUnitMeasureCode")]
        [InverseProperty("ProductWeightUnitMeasureCodeNavigation")]
        public UnitMeasure WeightUnitMeasureCodeNavigation { get; set; }
        [InverseProperty("Component")]
        public ICollection<BillOfMaterials> BillOfMaterialsComponent { get; set; }
        [InverseProperty("ProductAssembly")]
        public ICollection<BillOfMaterials> BillOfMaterialsProductAssembly { get; set; }
        [InverseProperty("Product")]
        public ICollection<ProductCostHistory> ProductCostHistory { get; set; }
        [InverseProperty("Product")]
        public ICollection<ProductInventory> ProductInventory { get; set; }
        [InverseProperty("Product")]
        public ICollection<ProductListPriceHistory> ProductListPriceHistory { get; set; }
        [InverseProperty("Product")]
        public ICollection<ProductProductPhoto> ProductProductPhoto { get; set; }
        [InverseProperty("Product")]
        public ICollection<ProductReview> ProductReview { get; set; }
        [InverseProperty("Product")]
        public ICollection<ProductVendor> ProductVendor { get; set; }
        [InverseProperty("Product")]
        public ICollection<PurchaseOrderDetail> PurchaseOrderDetail { get; set; }
        [InverseProperty("Product")]
        public ICollection<ShoppingCartItem> ShoppingCartItem { get; set; }
        [InverseProperty("Product")]
        public ICollection<SpecialOfferProduct> SpecialOfferProduct { get; set; }
        [InverseProperty("Product")]
        public ICollection<TransactionHistory> TransactionHistory { get; set; }
        [InverseProperty("Product")]
        public ICollection<WorkOrder> WorkOrder { get; set; }
    }
}
