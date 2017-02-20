using System;
using System.Collections.Generic;

namespace Performance.EFCore.Models
{
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

        public int ProductID { get; set; }
        public string Name { get; set; }
        public string ProductNumber { get; set; }
        public bool MakeFlag { get; set; }
        public bool FinishedGoodsFlag { get; set; }
        public string Color { get; set; }
        public short SafetyStockLevel { get; set; }
        public short ReorderPoint { get; set; }
        public decimal StandardCost { get; set; }
        public decimal ListPrice { get; set; }
        public string Size { get; set; }
        public string SizeUnitMeasureCode { get; set; }
        public string WeightUnitMeasureCode { get; set; }
        public decimal? Weight { get; set; }
        public int DaysToManufacture { get; set; }
        public string ProductLine { get; set; }
        public string Class { get; set; }
        public string Style { get; set; }
        public int? ProductSubcategoryID { get; set; }
        public int? ProductModelID { get; set; }
        public DateTime SellStartDate { get; set; }
        public DateTime? SellEndDate { get; set; }
        public DateTime? DiscontinuedDate { get; set; }
        public Guid rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual ICollection<BillOfMaterials> BillOfMaterialsComponent { get; set; }
        public virtual ICollection<BillOfMaterials> BillOfMaterialsProductAssembly { get; set; }
        public virtual ICollection<ProductCostHistory> ProductCostHistory { get; set; }
        public virtual ICollection<ProductInventory> ProductInventory { get; set; }
        public virtual ICollection<ProductListPriceHistory> ProductListPriceHistory { get; set; }
        public virtual ICollection<ProductProductPhoto> ProductProductPhoto { get; set; }
        public virtual ICollection<ProductReview> ProductReview { get; set; }
        public virtual ICollection<ProductVendor> ProductVendor { get; set; }
        public virtual ICollection<PurchaseOrderDetail> PurchaseOrderDetail { get; set; }
        public virtual ICollection<ShoppingCartItem> ShoppingCartItem { get; set; }
        public virtual ICollection<SpecialOfferProduct> SpecialOfferProduct { get; set; }
        public virtual ICollection<TransactionHistory> TransactionHistory { get; set; }
        public virtual ICollection<WorkOrder> WorkOrder { get; set; }
        public virtual ProductModel ProductModel { get; set; }
        public virtual ProductSubcategory ProductSubcategory { get; set; }
        public virtual UnitMeasure SizeUnitMeasureCodeNavigation { get; set; }
        public virtual UnitMeasure WeightUnitMeasureCodeNavigation { get; set; }
    }
}
