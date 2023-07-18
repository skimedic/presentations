// Copyright Information
// ==================================
// EntityFrameworkCore - EfCoreBasics - AwDbContext.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2020/04/08
// See License.txt for more information
// ==================================

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using EfCoreBasics.Entities;

namespace EfCoreBasics.EfStructures;

public partial class AwDbContext : DbContext
{
    //public AwDbContext()
    //{
    //}

    public AwDbContext(DbContextOptions<AwDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Address { get; set; }
    public virtual DbSet<AddressType> AddressType { get; set; }
    public virtual DbSet<AwbuildVersion> AwbuildVersion { get; set; }
    public virtual DbSet<BillOfMaterials> BillOfMaterials { get; set; }
    public virtual DbSet<BusinessEntity> BusinessEntity { get; set; }
    public virtual DbSet<BusinessEntityAddress> BusinessEntityAddress { get; set; }
    public virtual DbSet<BusinessEntityContact> BusinessEntityContact { get; set; }
    public virtual DbSet<ContactType> ContactType { get; set; }
    public virtual DbSet<CountryRegion> CountryRegion { get; set; }
    public virtual DbSet<CountryRegionCurrency> CountryRegionCurrency { get; set; }
    public virtual DbSet<CreditCard> CreditCard { get; set; }
    public virtual DbSet<Culture> Culture { get; set; }
    public virtual DbSet<Currency> Currency { get; set; }
    public virtual DbSet<CurrencyRate> CurrencyRate { get; set; }
    public virtual DbSet<Customer> Customer { get; set; }
    public virtual DbSet<DatabaseLog> DatabaseLog { get; set; }
    public virtual DbSet<Department> Department { get; set; }
    public virtual DbSet<EmailAddress> EmailAddress { get; set; }
    public virtual DbSet<Employee> Employee { get; set; }
    public virtual DbSet<EmployeeDepartmentHistory> EmployeeDepartmentHistory { get; set; }
    public virtual DbSet<EmployeePayHistory> EmployeePayHistory { get; set; }
    public virtual DbSet<ErrorLog> ErrorLog { get; set; }
    public virtual DbSet<Illustration> Illustration { get; set; }
    public virtual DbSet<JobCandidate> JobCandidate { get; set; }
    public virtual DbSet<Location> Location { get; set; }
    public virtual DbSet<Password> Password { get; set; }
    public virtual DbSet<Person> Person { get; set; }
    public virtual DbSet<PersonCreditCard> PersonCreditCard { get; set; }
    public virtual DbSet<PersonPhone> PersonPhone { get; set; }
    public virtual DbSet<PhoneNumberType> PhoneNumberType { get; set; }
    public virtual DbSet<Product> Product { get; set; }
    public virtual DbSet<ProductCategory> ProductCategory { get; set; }
    public virtual DbSet<ProductCostHistory> ProductCostHistory { get; set; }
    public virtual DbSet<ProductDescription> ProductDescription { get; set; }
    public virtual DbSet<ProductInventory> ProductInventory { get; set; }
    public virtual DbSet<ProductListPriceHistory> ProductListPriceHistory { get; set; }
    public virtual DbSet<ProductModel> ProductModel { get; set; }
    public virtual DbSet<ProductModelIllustration> ProductModelIllustration { get; set; }
    public virtual DbSet<ProductModelProductDescriptionCulture> ProductModelProductDescriptionCulture { get; set; }
    public virtual DbSet<ProductPhoto> ProductPhoto { get; set; }
    public virtual DbSet<ProductProductPhoto> ProductProductPhoto { get; set; }
    public virtual DbSet<ProductReview> ProductReview { get; set; }
    public virtual DbSet<ProductSubcategory> ProductSubcategory { get; set; }
    public virtual DbSet<ProductVendor> ProductVendor { get; set; }
    public virtual DbSet<PurchaseOrderDetail> PurchaseOrderDetail { get; set; }
    public virtual DbSet<PurchaseOrderHeader> PurchaseOrderHeader { get; set; }
    public virtual DbSet<SalesOrderDetail> SalesOrderDetail { get; set; }
    public virtual DbSet<SalesOrderHeader> SalesOrderHeader { get; set; }
    public virtual DbSet<SalesOrderHeaderSalesReason> SalesOrderHeaderSalesReason { get; set; }
    public virtual DbSet<SalesPerson> SalesPerson { get; set; }
    public virtual DbSet<SalesPersonQuotaHistory> SalesPersonQuotaHistory { get; set; }
    public virtual DbSet<SalesReason> SalesReason { get; set; }
    public virtual DbSet<SalesTaxRate> SalesTaxRate { get; set; }
    public virtual DbSet<SalesTerritory> SalesTerritory { get; set; }
    public virtual DbSet<SalesTerritoryHistory> SalesTerritoryHistory { get; set; }
    public virtual DbSet<ScrapReason> ScrapReason { get; set; }
    public virtual DbSet<Shift> Shift { get; set; }
    public virtual DbSet<ShipMethod> ShipMethod { get; set; }
    public virtual DbSet<ShoppingCartItem> ShoppingCartItem { get; set; }
    public virtual DbSet<SpecialOffer> SpecialOffer { get; set; }
    public virtual DbSet<SpecialOfferProduct> SpecialOfferProduct { get; set; }
    public virtual DbSet<StateProvince> StateProvince { get; set; }
    public virtual DbSet<Store> Store { get; set; }
    public virtual DbSet<TransactionHistory> TransactionHistory { get; set; }
    public virtual DbSet<TransactionHistoryArchive> TransactionHistoryArchive { get; set; }
    public virtual DbSet<UnitMeasure> UnitMeasure { get; set; }
    public virtual DbSet<VAdditionalContactInfo> VAdditionalContactInfo { get; set; }
    public virtual DbSet<VEmployee> VEmployee { get; set; }
    public virtual DbSet<VEmployeeDepartment> VEmployeeDepartment { get; set; }
    public virtual DbSet<VEmployeeDepartmentHistory> VEmployeeDepartmentHistory { get; set; }
    public virtual DbSet<VIndividualCustomer> VIndividualCustomer { get; set; }
    public virtual DbSet<VJobCandidate> VJobCandidate { get; set; }
    public virtual DbSet<VJobCandidateEducation> VJobCandidateEducation { get; set; }
    public virtual DbSet<VJobCandidateEmployment> VJobCandidateEmployment { get; set; }
    public virtual DbSet<VPersonDemographics> VPersonDemographics { get; set; }
    public virtual DbSet<VProductAndDescription> VProductAndDescription { get; set; }
    public virtual DbSet<VProductModelCatalogDescription> VProductModelCatalogDescription { get; set; }
    public virtual DbSet<VProductModelInstructions> VProductModelInstructions { get; set; }
    public virtual DbSet<VSalesPerson> VSalesPerson { get; set; }
    public virtual DbSet<VSalesPersonSalesByFiscalYears> VSalesPersonSalesByFiscalYears { get; set; }
    public virtual DbSet<VStateProvinceCountryRegion> VStateProvinceCountryRegion { get; set; }
    public virtual DbSet<VStoreWithAddresses> VStoreWithAddresses { get; set; }
    public virtual DbSet<VStoreWithContacts> VStoreWithContacts { get; set; }
    public virtual DbSet<VStoreWithDemographics> VStoreWithDemographics { get; set; }
    public virtual DbSet<VVendorWithAddresses> VVendorWithAddresses { get; set; }
    public virtual DbSet<VVendorWithContacts> VVendorWithContacts { get; set; }
    public virtual DbSet<Vendor> Vendor { get; set; }
    public virtual DbSet<WorkOrder> WorkOrder { get; set; }
    public virtual DbSet<WorkOrderRouting> WorkOrderRouting { get; set; }

    // Unable to generate entity type for table 'Production.Document'. Please see the warning messages.
    // Unable to generate entity type for table 'Production.ProductDocument'. Please see the warning messages.

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http: //go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            optionsBuilder.UseSqlServer(
                @"server=.\dev2019;Database=Adventureworks2016;Trusted_Connection=True;Encrypt=false;");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasComment("Street address information for customers, employees, and vendors.");

            entity.HasIndex(e => e.Rowguid)
                .HasName("AK_Address_rowguid")
                .IsUnique();

            entity.HasIndex(e => e.StateProvinceId);

            entity.HasIndex(e => new {e.AddressLine1, e.AddressLine2, e.City, e.StateProvinceId, e.PostalCode})
                .IsUnique();

            entity.Property(e => e.AddressId).HasComment("Primary key for Address records.");

            entity.Property(e => e.AddressLine1).HasComment("First street address line.");

            entity.Property(e => e.AddressLine2).HasComment("Second street address line.");

            entity.Property(e => e.City).HasComment("Name of the city.");

            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");

            entity.Property(e => e.PostalCode).HasComment("Postal code for the street address.");

            entity.Property(e => e.Rowguid)
                .HasDefaultValueSql("(newid())")
                .HasComment(
                    "ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.");

            entity.Property(e => e.StateProvinceId).HasComment(
                "Unique identification number for the state or province. Foreign key to StateProvince table.");

            entity.HasOne(d => d.StateProvince)
                .WithMany(p => p.Address)
                .HasForeignKey(d => d.StateProvinceId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<AddressType>(entity =>
        {
            entity.HasComment("Types of addresses stored in the Address table. ");

            entity.HasIndex(e => e.Name)
                .HasName("AK_AddressType_Name")
                .IsUnique();

            entity.HasIndex(e => e.Rowguid)
                .HasName("AK_AddressType_rowguid")
                .IsUnique();

            entity.Property(e => e.AddressTypeId).HasComment("Primary key for AddressType records.");

            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");

            entity.Property(e => e.Name)
                .HasComment("Address type description. For example, Billing, Home, or Shipping.");

            entity.Property(e => e.Rowguid)
                .HasDefaultValueSql("(newid())")
                .HasComment(
                    "ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.");
        });

        modelBuilder.Entity<AwbuildVersion>(entity =>
        {
            entity.HasKey(e => e.SystemInformationId)
                .HasName("PK_AWBuildVersion_SystemInformationID");

            entity.HasComment("Current version number of the AdventureWorks 2016 sample database. ");

            entity.Property(e => e.SystemInformationId)
                .HasComment("Primary key for AWBuildVersion records.")
                .ValueGeneratedOnAdd();

            entity.Property(e => e.DatabaseVersion)
                .HasComment("Version number of the database in 9.yy.mm.dd.00 format.");

            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");

            entity.Property(e => e.VersionDate).HasComment("Date and time the record was last updated.");
        });

        modelBuilder.Entity<BillOfMaterials>(entity =>
        {
            entity.HasKey(e => e.BillOfMaterialsId)
                .HasName("PK_BillOfMaterials_BillOfMaterialsID")
                .IsClustered(false);

            entity.HasComment(
                "Items required to make bicycles and bicycle subassemblies. It identifies the heirarchical relationship between a parent product and its components.");

            entity.HasIndex(e => e.UnitMeasureCode);

            entity.HasIndex(e => new {e.ProductAssemblyId, e.ComponentId, e.StartDate})
                .HasName("AK_BillOfMaterials_ProductAssemblyID_ComponentID_StartDate")
                .IsUnique()
                .IsClustered();

            entity.Property(e => e.BillOfMaterialsId).HasComment("Primary key for BillOfMaterials records.");

            entity.Property(e => e.Bomlevel)
                .HasComment("Indicates the depth the component is from its parent (AssemblyID).");

            entity.Property(e => e.ComponentId)
                .HasComment("Component identification number. Foreign key to Product.ProductID.");

            entity.Property(e => e.EndDate)
                .HasComment("Date the component stopped being used in the assembly item.");

            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");

            entity.Property(e => e.PerAssemblyQty)
                .HasDefaultValueSql("((1.00))")
                .HasComment("Quantity of the component needed to create the assembly.");

            entity.Property(e => e.ProductAssemblyId)
                .HasComment("Parent product identification number. Foreign key to Product.ProductID.");

            entity.Property(e => e.StartDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date the component started being used in the assembly item.");

            entity.Property(e => e.UnitMeasureCode)
                .IsFixedLength()
                .HasComment("Standard code identifying the unit of measure for the quantity.");

            entity.HasOne(d => d.Component)
                .WithMany(p => p.BillOfMaterialsComponent)
                .HasForeignKey(d => d.ComponentId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.UnitMeasureCodeNavigation)
                .WithMany(p => p.BillOfMaterials)
                .HasForeignKey(d => d.UnitMeasureCode)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<BusinessEntity>(entity =>
        {
            entity.HasComment(
                "Source of the ID that connects vendors, customers, and employees with address and contact information.");

            entity.HasIndex(e => e.Rowguid)
                .HasName("AK_BusinessEntity_rowguid")
                .IsUnique();

            entity.Property(e => e.BusinessEntityId)
                .HasComment("Primary key for all customers, vendors, and employees.");

            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");

            entity.Property(e => e.Rowguid)
                .HasDefaultValueSql("(newid())")
                .HasComment(
                    "ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.");
        });

        modelBuilder.Entity<BusinessEntityAddress>(entity =>
        {
            entity.HasKey(e => new {e.BusinessEntityId, e.AddressId, e.AddressTypeId})
                .HasName("PK_BusinessEntityAddress_BusinessEntityID_AddressID_AddressTypeID");

            entity.HasComment(
                "Cross-reference table mapping customers, vendors, and employees to their addresses.");

            entity.HasIndex(e => e.AddressId);

            entity.HasIndex(e => e.AddressTypeId);

            entity.HasIndex(e => e.Rowguid)
                .HasName("AK_BusinessEntityAddress_rowguid")
                .IsUnique();

            entity.Property(e => e.BusinessEntityId)
                .HasComment("Primary key. Foreign key to BusinessEntity.BusinessEntityID.");

            entity.Property(e => e.AddressId).HasComment("Primary key. Foreign key to Address.AddressID.");

            entity.Property(e => e.AddressTypeId)
                .HasComment("Primary key. Foreign key to AddressType.AddressTypeID.");

            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");

            entity.Property(e => e.Rowguid)
                .HasDefaultValueSql("(newid())")
                .HasComment(
                    "ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.");

            entity.HasOne(d => d.Address)
                .WithMany(p => p.BusinessEntityAddress)
                .HasForeignKey(d => d.AddressId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.AddressType)
                .WithMany(p => p.BusinessEntityAddress)
                .HasForeignKey(d => d.AddressTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.BusinessEntity)
                .WithMany(p => p.BusinessEntityAddress)
                .HasForeignKey(d => d.BusinessEntityId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<BusinessEntityContact>(entity =>
        {
            entity.HasKey(e => new {e.BusinessEntityId, e.PersonId, e.ContactTypeId})
                .HasName("PK_BusinessEntityContact_BusinessEntityID_PersonID_ContactTypeID");

            entity.HasComment("Cross-reference table mapping stores, vendors, and employees to people");

            entity.HasIndex(e => e.ContactTypeId);

            entity.HasIndex(e => e.PersonId);

            entity.HasIndex(e => e.Rowguid)
                .HasName("AK_BusinessEntityContact_rowguid")
                .IsUnique();

            entity.Property(e => e.BusinessEntityId)
                .HasComment("Primary key. Foreign key to BusinessEntity.BusinessEntityID.");

            entity.Property(e => e.PersonId).HasComment("Primary key. Foreign key to Person.BusinessEntityID.");

            entity.Property(e => e.ContactTypeId)
                .HasComment("Primary key.  Foreign key to ContactType.ContactTypeID.");

            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");

            entity.Property(e => e.Rowguid)
                .HasDefaultValueSql("(newid())")
                .HasComment(
                    "ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.");

            entity.HasOne(d => d.BusinessEntity)
                .WithMany(p => p.BusinessEntityContact)
                .HasForeignKey(d => d.BusinessEntityId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.ContactType)
                .WithMany(p => p.BusinessEntityContact)
                .HasForeignKey(d => d.ContactTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Person)
                .WithMany(p => p.BusinessEntityContact)
                .HasForeignKey(d => d.PersonId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<ContactType>(entity =>
        {
            entity.HasComment("Lookup table containing the types of business entity contacts.");

            entity.HasIndex(e => e.Name)
                .HasName("AK_ContactType_Name")
                .IsUnique();

            entity.Property(e => e.ContactTypeId).HasComment("Primary key for ContactType records.");

            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");

            entity.Property(e => e.Name).HasComment("Contact type description.");
        });

        modelBuilder.Entity<CountryRegion>(entity =>
        {
            entity.HasKey(e => e.CountryRegionCode)
                .HasName("PK_CountryRegion_CountryRegionCode");

            entity.HasComment("Lookup table containing the ISO standard codes for countries and regions.");

            entity.HasIndex(e => e.Name)
                .HasName("AK_CountryRegion_Name")
                .IsUnique();

            entity.Property(e => e.CountryRegionCode).HasComment("ISO standard code for countries and regions.");

            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");

            entity.Property(e => e.Name).HasComment("Country or region name.");
        });

        modelBuilder.Entity<CountryRegionCurrency>(entity =>
        {
            entity.HasKey(e => new {e.CountryRegionCode, e.CurrencyCode})
                .HasName("PK_CountryRegionCurrency_CountryRegionCode_CurrencyCode");

            entity.HasComment("Cross-reference table mapping ISO currency codes to a country or region.");

            entity.HasIndex(e => e.CurrencyCode);

            entity.Property(e => e.CountryRegionCode)
                .HasComment("ISO code for countries and regions. Foreign key to CountryRegion.CountryRegionCode.");

            entity.Property(e => e.CurrencyCode)
                .IsFixedLength()
                .HasComment("ISO standard currency code. Foreign key to Currency.CurrencyCode.");

            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");

            entity.HasOne(d => d.CountryRegionCodeNavigation)
                .WithMany(p => p.CountryRegionCurrency)
                .HasForeignKey(d => d.CountryRegionCode)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.CurrencyCodeNavigation)
                .WithMany(p => p.CountryRegionCurrency)
                .HasForeignKey(d => d.CurrencyCode)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<CreditCard>(entity =>
        {
            entity.HasComment("Customer credit card information.");

            entity.HasIndex(e => e.CardNumber)
                .HasName("AK_CreditCard_CardNumber")
                .IsUnique();

            entity.Property(e => e.CreditCardId).HasComment("Primary key for CreditCard records.");

            entity.Property(e => e.CardNumber).HasComment("Credit card number.");

            entity.Property(e => e.CardType).HasComment("Credit card name.");

            entity.Property(e => e.ExpMonth).HasComment("Credit card expiration month.");

            entity.Property(e => e.ExpYear).HasComment("Credit card expiration year.");

            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");
        });

        modelBuilder.Entity<Culture>(entity =>
        {
            entity.HasComment("Lookup table containing the languages in which some AdventureWorks data is stored.");

            entity.HasIndex(e => e.Name)
                .HasName("AK_Culture_Name")
                .IsUnique();

            entity.Property(e => e.CultureId)
                .IsFixedLength()
                .HasComment("Primary key for Culture records.");

            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");

            entity.Property(e => e.Name).HasComment("Culture description.");
        });

        modelBuilder.Entity<Currency>(entity =>
        {
            entity.HasKey(e => e.CurrencyCode)
                .HasName("PK_Currency_CurrencyCode");

            entity.HasComment("Lookup table containing standard ISO currencies.");

            entity.HasIndex(e => e.Name)
                .HasName("AK_Currency_Name")
                .IsUnique();

            entity.Property(e => e.CurrencyCode)
                .IsFixedLength()
                .HasComment("The ISO code for the Currency.");

            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");

            entity.Property(e => e.Name).HasComment("Currency name.");
        });

        modelBuilder.Entity<CurrencyRate>(entity =>
        {
            entity.HasComment("Currency exchange rates.");

            entity.HasIndex(e => new {e.CurrencyRateDate, e.FromCurrencyCode, e.ToCurrencyCode})
                .HasName("AK_CurrencyRate_CurrencyRateDate_FromCurrencyCode_ToCurrencyCode")
                .IsUnique();

            entity.Property(e => e.CurrencyRateId).HasComment("Primary key for CurrencyRate records.");

            entity.Property(e => e.AverageRate).HasComment("Average exchange rate for the day.");

            entity.Property(e => e.CurrencyRateDate).HasComment("Date and time the exchange rate was obtained.");

            entity.Property(e => e.EndOfDayRate).HasComment("Final exchange rate for the day.");

            entity.Property(e => e.FromCurrencyCode)
                .IsFixedLength()
                .HasComment("Exchange rate was converted from this currency code.");

            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");

            entity.Property(e => e.ToCurrencyCode)
                .IsFixedLength()
                .HasComment("Exchange rate was converted to this currency code.");

            entity.HasOne(d => d.FromCurrencyCodeNavigation)
                .WithMany(p => p.CurrencyRateFromCurrencyCodeNavigation)
                .HasForeignKey(d => d.FromCurrencyCode)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.ToCurrencyCodeNavigation)
                .WithMany(p => p.CurrencyRateToCurrencyCodeNavigation)
                .HasForeignKey(d => d.ToCurrencyCode)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasComment("Current customer information. Also see the Person and Store tables.");

            entity.HasIndex(e => e.AccountNumber)
                .HasName("AK_Customer_AccountNumber")
                .IsUnique();

            entity.HasIndex(e => e.Rowguid)
                .HasName("AK_Customer_rowguid")
                .IsUnique();

            entity.HasIndex(e => e.TerritoryId);

            entity.Property(e => e.CustomerId).HasComment("Primary key.");

            entity.Property(e => e.AccountNumber)
                .IsUnicode(false)
                .HasComment("Unique number identifying the customer assigned by the accounting system.")
                .HasComputedColumnSql("(isnull('AW'+[dbo].[ufnLeadingZeros]([CustomerID]),''))");

            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");

            entity.Property(e => e.PersonId).HasComment("Foreign key to Person.BusinessEntityID");

            entity.Property(e => e.Rowguid)
                .HasDefaultValueSql("(newid())")
                .HasComment(
                    "ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.");

            entity.Property(e => e.StoreId).HasComment("Foreign key to Store.BusinessEntityID");

            entity.Property(e => e.TerritoryId)
                .HasComment(
                    "ID of the territory in which the customer is located. Foreign key to SalesTerritory.SalesTerritoryID.");
        });

        modelBuilder.Entity<DatabaseLog>(entity =>
        {
            entity.HasKey(e => e.DatabaseLogId)
                .HasName("PK_DatabaseLog_DatabaseLogID")
                .IsClustered(false);

            entity.HasComment(
                "Audit table tracking all DDL changes made to the AdventureWorks database. Data is captured by the database trigger ddlDatabaseTriggerLog.");

            entity.Property(e => e.DatabaseLogId).HasComment("Primary key for DatabaseLog records.");

            entity.Property(e => e.DatabaseUser).HasComment("The user who implemented the DDL change.");

            entity.Property(e => e.Event).HasComment("The type of DDL statement that was executed.");

            entity.Property(e => e.Object).HasComment("The object that was changed by the DDL statment.");

            entity.Property(e => e.PostTime).HasComment("The date and time the DDL change occurred.");

            entity.Property(e => e.Schema).HasComment("The schema to which the changed object belongs.");

            entity.Property(e => e.Tsql).HasComment("The exact Transact-SQL statement that was executed.");

            entity.Property(e => e.XmlEvent).HasComment("The raw XML data generated by database trigger.");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasComment("Lookup table containing the departments within the Adventure Works Cycles company.");

            entity.HasIndex(e => e.Name)
                .HasName("AK_Department_Name")
                .IsUnique();

            entity.Property(e => e.DepartmentId).HasComment("Primary key for Department records.");

            entity.Property(e => e.GroupName).HasComment("Name of the group to which the department belongs.");

            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");

            entity.Property(e => e.Name).HasComment("Name of the department.");
        });

        modelBuilder.Entity<EmailAddress>(entity =>
        {
            entity.HasKey(e => new {e.BusinessEntityId, e.EmailAddressId})
                .HasName("PK_EmailAddress_BusinessEntityID_EmailAddressID");

            entity.HasComment("Where to send a person email.");

            entity.HasIndex(e => e.EmailAddress1);

            entity.Property(e => e.BusinessEntityId).HasComment(
                "Primary key. Person associated with this email address.  Foreign key to Person.BusinessEntityID");

            entity.Property(e => e.EmailAddressId)
                .HasComment("Primary key. ID of this email address.")
                .ValueGeneratedOnAdd();

            entity.Property(e => e.EmailAddress1).HasComment("E-mail address for the person.");

            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");

            entity.Property(e => e.Rowguid)
                .HasDefaultValueSql("(newid())")
                .HasComment(
                    "ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.");

            entity.HasOne(d => d.BusinessEntity)
                .WithMany(p => p.EmailAddress)
                .HasForeignKey(d => d.BusinessEntityId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.BusinessEntityId)
                .HasName("PK_Employee_BusinessEntityID");

            entity.HasComment("Employee information such as salary, department, and title.");

            entity.HasIndex(e => e.LoginId)
                .HasName("AK_Employee_LoginID")
                .IsUnique();

            entity.HasIndex(e => e.NationalIdnumber)
                .HasName("AK_Employee_NationalIDNumber")
                .IsUnique();

            entity.HasIndex(e => e.Rowguid)
                .HasName("AK_Employee_rowguid")
                .IsUnique();

            entity.Property(e => e.BusinessEntityId)
                .HasComment("Primary key for Employee records.  Foreign key to BusinessEntity.BusinessEntityID.")
                .ValueGeneratedNever();

            entity.Property(e => e.BirthDate).HasComment("Date of birth.");

            entity.Property(e => e.CurrentFlag)
                .HasDefaultValueSql("((1))")
                .HasComment("0 = Inactive, 1 = Active");

            entity.Property(e => e.Gender)
                .IsFixedLength()
                .HasComment("M = Male, F = Female");

            entity.Property(e => e.HireDate).HasComment("Employee hired on this date.");

            entity.Property(e => e.JobTitle).HasComment("Work title such as Buyer or Sales Representative.");

            entity.Property(e => e.LoginId).HasComment("Network login.");

            entity.Property(e => e.MaritalStatus)
                .IsFixedLength()
                .HasComment("M = Married, S = Single");

            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");

            entity.Property(e => e.NationalIdnumber)
                .HasComment("Unique national identification number such as a social security number.");

            entity.Property(e => e.OrganizationLevel)
                .HasComment("The depth of the employee in the corporate hierarchy.")
                .HasComputedColumnSql("([OrganizationNode].[GetLevel]())");

            entity.Property(e => e.Rowguid)
                .HasDefaultValueSql("(newid())")
                .HasComment(
                    "ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.");

            entity.Property(e => e.SalariedFlag)
                .HasDefaultValueSql("((1))")
                .HasComment(
                    "Job classification. 0 = Hourly, not exempt from collective bargaining. 1 = Salaried, exempt from collective bargaining.");

            entity.Property(e => e.SickLeaveHours).HasComment("Number of available sick leave hours.");

            entity.Property(e => e.VacationHours).HasComment("Number of available vacation hours.");

            entity.HasOne(d => d.BusinessEntity)
                .WithOne(p => p.Employee)
                .HasForeignKey<Employee>(d => d.BusinessEntityId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<EmployeeDepartmentHistory>(entity =>
        {
            entity.HasKey(e => new {e.BusinessEntityId, e.StartDate, e.DepartmentId, e.ShiftId})
                .HasName("PK_EmployeeDepartmentHistory_BusinessEntityID_StartDate_DepartmentID");

            entity.HasComment("Employee department transfers.");

            entity.HasIndex(e => e.DepartmentId);

            entity.HasIndex(e => e.ShiftId);

            entity.Property(e => e.BusinessEntityId)
                .HasComment("Employee identification number. Foreign key to Employee.BusinessEntityID.");

            entity.Property(e => e.StartDate).HasComment("Date the employee started work in the department.");

            entity.Property(e => e.DepartmentId)
                .HasComment(
                    "Department in which the employee worked including currently. Foreign key to Department.DepartmentID.");

            entity.Property(e => e.ShiftId)
                .HasComment("Identifies which 8-hour shift the employee works. Foreign key to Shift.Shift.ID.");

            entity.Property(e => e.EndDate)
                .HasComment("Date the employee left the department. NULL = Current department.");

            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");

            entity.HasOne(d => d.BusinessEntity)
                .WithMany(p => p.EmployeeDepartmentHistory)
                .HasForeignKey(d => d.BusinessEntityId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Department)
                .WithMany(p => p.EmployeeDepartmentHistory)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Shift)
                .WithMany(p => p.EmployeeDepartmentHistory)
                .HasForeignKey(d => d.ShiftId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<EmployeePayHistory>(entity =>
        {
            entity.HasKey(e => new {e.BusinessEntityId, e.RateChangeDate})
                .HasName("PK_EmployeePayHistory_BusinessEntityID_RateChangeDate");

            entity.HasComment("Employee pay history.");

            entity.Property(e => e.BusinessEntityId)
                .HasComment("Employee identification number. Foreign key to Employee.BusinessEntityID.");

            entity.Property(e => e.RateChangeDate).HasComment("Date the change in pay is effective");

            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");

            entity.Property(e => e.PayFrequency)
                .HasComment("1 = Salary received monthly, 2 = Salary received biweekly");

            entity.Property(e => e.Rate).HasComment("Salary hourly rate.");

            entity.HasOne(d => d.BusinessEntity)
                .WithMany(p => p.EmployeePayHistory)
                .HasForeignKey(d => d.BusinessEntityId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<ErrorLog>(entity =>
        {
            entity.HasComment(
                "Audit table tracking errors in the the AdventureWorks database that are caught by the CATCH block of a TRY...CATCH construct. Data is inserted by stored procedure dbo.uspLogError when it is executed from inside the CATCH block of a TRY...CATCH construct.");

            entity.Property(e => e.ErrorLogId).HasComment("Primary key for ErrorLog records.");

            entity.Property(e => e.ErrorLine).HasComment("The line number at which the error occurred.");

            entity.Property(e => e.ErrorMessage).HasComment("The message text of the error that occurred.");

            entity.Property(e => e.ErrorNumber).HasComment("The error number of the error that occurred.");

            entity.Property(e => e.ErrorProcedure)
                .HasComment("The name of the stored procedure or trigger where the error occurred.");

            entity.Property(e => e.ErrorSeverity).HasComment("The severity of the error that occurred.");

            entity.Property(e => e.ErrorState).HasComment("The state number of the error that occurred.");

            entity.Property(e => e.ErrorTime)
                .HasDefaultValueSql("(getdate())")
                .HasComment("The date and time at which the error occurred.");

            entity.Property(e => e.UserName)
                .HasComment("The user who executed the batch in which the error occurred.");
        });

        modelBuilder.Entity<Illustration>(entity =>
        {
            entity.HasComment("Bicycle assembly diagrams.");

            entity.Property(e => e.IllustrationId).HasComment("Primary key for Illustration records.");

            entity.Property(e => e.Diagram)
                .HasComment("Illustrations used in manufacturing instructions. Stored as XML.");

            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");
        });

        modelBuilder.Entity<JobCandidate>(entity =>
        {
            entity.HasComment("Résumés submitted to Human Resources by job applicants.");

            entity.HasIndex(e => e.BusinessEntityId);

            entity.Property(e => e.JobCandidateId).HasComment("Primary key for JobCandidate records.");

            entity.Property(e => e.BusinessEntityId).HasComment(
                "Employee identification number if applicant was hired. Foreign key to Employee.BusinessEntityID.");

            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");

            entity.Property(e => e.Resume).HasComment("Résumé in XML format.");
        });

        modelBuilder.Entity<Location>(entity =>
        {
            entity.HasComment("Product inventory and manufacturing locations.");

            entity.HasIndex(e => e.Name)
                .HasName("AK_Location_Name")
                .IsUnique();

            entity.Property(e => e.LocationId).HasComment("Primary key for Location records.");

            entity.Property(e => e.Availability)
                .HasDefaultValueSql("((0.00))")
                .HasComment("Work capacity (in hours) of the manufacturing location.");

            entity.Property(e => e.CostRate)
                .HasDefaultValueSql("((0.00))")
                .HasComment("Standard hourly cost of the manufacturing location.");

            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");

            entity.Property(e => e.Name).HasComment("Location description.");
        });

        modelBuilder.Entity<Password>(entity =>
        {
            entity.HasKey(e => e.BusinessEntityId)
                .HasName("PK_Password_BusinessEntityID");

            entity.HasComment("One way hashed authentication information");

            entity.Property(e => e.BusinessEntityId).ValueGeneratedNever();

            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");

            entity.Property(e => e.PasswordHash)
                .IsUnicode(false)
                .HasComment("Password for the e-mail account.");

            entity.Property(e => e.PasswordSalt)
                .IsUnicode(false)
                .HasComment("Random value concatenated with the password string before the password is hashed.");

            entity.Property(e => e.Rowguid)
                .HasDefaultValueSql("(newid())")
                .HasComment(
                    "ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.");

            entity.HasOne(d => d.BusinessEntity)
                .WithOne(p => p.Password)
                .HasForeignKey<Password>(d => d.BusinessEntityId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.BusinessEntityId)
                .HasName("PK_Person_BusinessEntityID");

            entity.HasComment(
                "Human beings involved with AdventureWorks: employees, customer contacts, and vendor contacts.");

            entity.HasIndex(e => e.AdditionalContactInfo)
                .HasName("PXML_Person_AddContact");

            entity.HasIndex(e => e.Demographics)
                .HasName("XMLVALUE_Person_Demographics");

            entity.HasIndex(e => e.Rowguid)
                .HasName("AK_Person_rowguid")
                .IsUnique();

            entity.HasIndex(e => new {e.LastName, e.FirstName, e.MiddleName});

            entity.Property(e => e.BusinessEntityId)
                .HasComment("Primary key for Person records.")
                .ValueGeneratedNever();

            entity.Property(e => e.AdditionalContactInfo)
                .HasComment("Additional contact information about the person stored in xml format. ");

            entity.Property(e => e.Demographics)
                .HasComment(
                    "Personal information such as hobbies, and income collected from online shoppers. Used for sales analysis.");

            entity.Property(e => e.EmailPromotion).HasComment(
                "0 = Contact does not wish to receive e-mail promotions, 1 = Contact does wish to receive e-mail promotions from AdventureWorks, 2 = Contact does wish to receive e-mail promotions from AdventureWorks and selected partners. ");

            entity.Property(e => e.FirstName).HasComment("First name of the person.");

            entity.Property(e => e.LastName).HasComment("Last name of the person.");

            entity.Property(e => e.MiddleName).HasComment("Middle name or middle initial of the person.");

            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");

            entity.Property(e => e.NameStyle)
                .HasComment(
                    "0 = The data in FirstName and LastName are stored in western style (first name, last name) order.  1 = Eastern style (last name, first name) order.");

            entity.Property(e => e.PersonType)
                .IsFixedLength()
                .HasComment(
                    "Primary type of person: SC = Store Contact, IN = Individual (retail) customer, SP = Sales person, EM = Employee (non-sales), VC = Vendor contact, GC = General contact");

            entity.Property(e => e.Rowguid)
                .HasDefaultValueSql("(newid())")
                .HasComment(
                    "ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.");

            entity.Property(e => e.Suffix).HasComment("Surname suffix. For example, Sr. or Jr.");

            entity.Property(e => e.Title).HasComment("A courtesy title. For example, Mr. or Ms.");

            entity.HasOne(d => d.BusinessEntity)
                .WithOne(p => p.Person)
                .HasForeignKey<Person>(d => d.BusinessEntityId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<PersonCreditCard>(entity =>
        {
            entity.HasKey(e => new {e.BusinessEntityId, e.CreditCardId})
                .HasName("PK_PersonCreditCard_BusinessEntityID_CreditCardID");

            entity.HasComment(
                "Cross-reference table mapping people to their credit card information in the CreditCard table. ");

            entity.Property(e => e.BusinessEntityId)
                .HasComment("Business entity identification number. Foreign key to Person.BusinessEntityID.");

            entity.Property(e => e.CreditCardId)
                .HasComment("Credit card identification number. Foreign key to CreditCard.CreditCardID.");

            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");

            entity.HasOne(d => d.BusinessEntity)
                .WithMany(p => p.PersonCreditCard)
                .HasForeignKey(d => d.BusinessEntityId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.CreditCard)
                .WithMany(p => p.PersonCreditCard)
                .HasForeignKey(d => d.CreditCardId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<PersonPhone>(entity =>
        {
            entity.HasKey(e => new {e.BusinessEntityId, e.PhoneNumber, e.PhoneNumberTypeId})
                .HasName("PK_PersonPhone_BusinessEntityID_PhoneNumber_PhoneNumberTypeID");

            entity.HasComment("Telephone number and type of a person.");

            entity.HasIndex(e => e.PhoneNumber);

            entity.Property(e => e.BusinessEntityId)
                .HasComment("Business entity identification number. Foreign key to Person.BusinessEntityID.");

            entity.Property(e => e.PhoneNumber).HasComment("Telephone number identification number.");

            entity.Property(e => e.PhoneNumberTypeId)
                .HasComment("Kind of phone number. Foreign key to PhoneNumberType.PhoneNumberTypeID.");

            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");

            entity.HasOne(d => d.BusinessEntity)
                .WithMany(p => p.PersonPhone)
                .HasForeignKey(d => d.BusinessEntityId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.PhoneNumberType)
                .WithMany(p => p.PersonPhone)
                .HasForeignKey(d => d.PhoneNumberTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<PhoneNumberType>(entity =>
        {
            entity.HasComment("Type of phone number of a person.");

            entity.Property(e => e.PhoneNumberTypeId).HasComment("Primary key for telephone number type records.");

            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");

            entity.Property(e => e.Name).HasComment("Name of the telephone number type");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasComment("Products sold or used in the manfacturing of sold products.");

            entity.HasIndex(e => e.Name)
                .HasName("AK_Product_Name")
                .IsUnique();

            entity.HasIndex(e => e.ProductNumber)
                .HasName("AK_Product_ProductNumber")
                .IsUnique();

            entity.HasIndex(e => e.Rowguid)
                .HasName("AK_Product_rowguid")
                .IsUnique();

            entity.Property(e => e.ProductId).HasComment("Primary key for Product records.");

            entity.Property(e => e.Class)
                .IsFixedLength()
                .HasComment("H = High, M = Medium, L = Low");

            entity.Property(e => e.Color).HasComment("Product color.");

            entity.Property(e => e.DaysToManufacture)
                .HasComment("Number of days required to manufacture the product.");

            entity.Property(e => e.DiscontinuedDate).HasComment("Date the product was discontinued.");

            entity.Property(e => e.FinishedGoodsFlag)
                .HasDefaultValueSql("((1))")
                .HasComment("0 = Product is not a salable item. 1 = Product is salable.");

            entity.Property(e => e.ListPrice).HasComment("Selling price.");

            entity.Property(e => e.MakeFlag)
                .HasDefaultValueSql("((1))")
                .HasComment("0 = Product is purchased, 1 = Product is manufactured in-house.");

            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");

            entity.Property(e => e.Name).HasComment("Name of the product.");

            entity.Property(e => e.ProductLine)
                .IsFixedLength()
                .HasComment("R = Road, M = Mountain, T = Touring, S = Standard");

            entity.Property(e => e.ProductModelId)
                .HasComment(
                    "Product is a member of this product model. Foreign key to ProductModel.ProductModelID.");

            entity.Property(e => e.ProductNumber).HasComment("Unique product identification number.");

            entity.Property(e => e.ProductSubcategoryId).HasComment(
                "Product is a member of this product subcategory. Foreign key to ProductSubCategory.ProductSubCategoryID. ");

            entity.Property(e => e.ReorderPoint)
                .HasComment("Inventory level that triggers a purchase order or work order. ");

            entity.Property(e => e.Rowguid)
                .HasDefaultValueSql("(newid())")
                .HasComment(
                    "ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.");

            entity.Property(e => e.SafetyStockLevel).HasComment("Minimum inventory quantity. ");

            entity.Property(e => e.SellEndDate).HasComment("Date the product was no longer available for sale.");

            entity.Property(e => e.SellStartDate).HasComment("Date the product was available for sale.");

            entity.Property(e => e.Size).HasComment("Product size.");

            entity.Property(e => e.SizeUnitMeasureCode)
                .IsFixedLength()
                .HasComment("Unit of measure for Size column.");

            entity.Property(e => e.StandardCost).HasComment("Standard cost of the product.");

            entity.Property(e => e.Style)
                .IsFixedLength()
                .HasComment("W = Womens, M = Mens, U = Universal");

            entity.Property(e => e.Weight).HasComment("Product weight.");

            entity.Property(e => e.WeightUnitMeasureCode)
                .IsFixedLength()
                .HasComment("Unit of measure for Weight column.");

            entity.HasOne(d => d.SizeUnitMeasureCodeNavigation)
                .WithMany(p => p.ProductSizeUnitMeasureCodeNavigation)
                .HasForeignKey(d => d.SizeUnitMeasureCode)
                .HasConstraintName("FK_Product_UnitMeasure");

            entity.HasOne(d => d.WeightUnitMeasureCodeNavigation)
                .WithMany(p => p.ProductWeightUnitMeasureCodeNavigation)
                .HasForeignKey(d => d.WeightUnitMeasureCode)
                .OnDelete(DeleteBehavior.SetNull);
        });

        modelBuilder.Entity<ProductCategory>(entity =>
        {
            entity.HasComment("High-level product categorization.");

            entity.HasIndex(e => e.Name)
                .HasName("AK_ProductCategory_Name")
                .IsUnique();

            entity.HasIndex(e => e.Rowguid)
                .HasName("AK_ProductCategory_rowguid")
                .IsUnique();

            entity.Property(e => e.ProductCategoryId).HasComment("Primary key for ProductCategory records.");

            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");

            entity.Property(e => e.Name).HasComment("Category description.");

            entity.Property(e => e.Rowguid)
                .HasDefaultValueSql("(newid())")
                .HasComment(
                    "ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.");
        });

        modelBuilder.Entity<ProductCostHistory>(entity =>
        {
            entity.HasKey(e => new {e.ProductId, e.StartDate})
                .HasName("PK_ProductCostHistory_ProductID_StartDate");

            entity.HasComment("Changes in the cost of a product over time.");

            entity.Property(e => e.ProductId)
                .HasComment("Product identification number. Foreign key to Product.ProductID");

            entity.Property(e => e.StartDate).HasComment("Product cost start date.");

            entity.Property(e => e.EndDate).HasComment("Product cost end date.");

            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");

            entity.Property(e => e.StandardCost).HasComment("Standard cost of the product.");

            entity.HasOne(d => d.Product)
                .WithMany(p => p.ProductCostHistory)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<ProductDescription>(entity =>
        {
            entity.HasComment("Product descriptions in several languages.");

            entity.HasIndex(e => e.Rowguid)
                .HasName("AK_ProductDescription_rowguid")
                .IsUnique();

            entity.Property(e => e.ProductDescriptionId).HasComment("Primary key for ProductDescription records.");

            entity.Property(e => e.Description).HasComment("Description of the product.");

            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");

            entity.Property(e => e.Rowguid)
                .HasDefaultValueSql("(newid())")
                .HasComment(
                    "ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.");
        });

        modelBuilder.Entity<ProductInventory>(entity =>
        {
            entity.HasKey(e => new {e.ProductId, e.LocationId})
                .HasName("PK_ProductInventory_ProductID_LocationID");

            entity.HasComment("Product inventory information.");

            entity.Property(e => e.ProductId)
                .HasComment("Product identification number. Foreign key to Product.ProductID.");

            entity.Property(e => e.LocationId)
                .HasComment("Inventory location identification number. Foreign key to Location.LocationID. ");

            entity.Property(e => e.Bin).HasComment("Storage container on a shelf in an inventory location.");

            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");

            entity.Property(e => e.Quantity).HasComment("Quantity of products in the inventory location.");

            entity.Property(e => e.Rowguid)
                .HasDefaultValueSql("(newid())")
                .HasComment(
                    "ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.");

            entity.Property(e => e.Shelf).HasComment("Storage compartment within an inventory location.");

            entity.HasOne(d => d.Location)
                .WithMany(p => p.ProductInventory)
                .HasForeignKey(d => d.LocationId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Product)
                .WithMany(p => p.ProductInventory)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<ProductListPriceHistory>(entity =>
        {
            entity.HasKey(e => new {e.ProductId, e.StartDate})
                .HasName("PK_ProductListPriceHistory_ProductID_StartDate");

            entity.HasComment("Changes in the list price of a product over time.");

            entity.Property(e => e.ProductId)
                .HasComment("Product identification number. Foreign key to Product.ProductID");

            entity.Property(e => e.StartDate).HasComment("List price start date.");

            entity.Property(e => e.EndDate).HasComment("List price end date");

            entity.Property(e => e.ListPrice).HasComment("Product list price.");

            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");

            entity.HasOne(d => d.Product)
                .WithMany(p => p.ProductListPriceHistory)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<ProductModel>(entity =>
        {
            entity.HasComment("Product model classification.");

            entity.HasIndex(e => e.CatalogDescription)
                .HasName("PXML_ProductModel_CatalogDescription");

            entity.HasIndex(e => e.Instructions)
                .HasName("PXML_ProductModel_Instructions");

            entity.HasIndex(e => e.Name)
                .HasName("AK_ProductModel_Name")
                .IsUnique();

            entity.HasIndex(e => e.Rowguid)
                .HasName("AK_ProductModel_rowguid")
                .IsUnique();

            entity.Property(e => e.ProductModelId).HasComment("Primary key for ProductModel records.");

            entity.Property(e => e.CatalogDescription)
                .HasComment("Detailed product catalog information in xml format.");

            entity.Property(e => e.Instructions).HasComment("Manufacturing instructions in xml format.");

            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");

            entity.Property(e => e.Name).HasComment("Product model description.");

            entity.Property(e => e.Rowguid)
                .HasDefaultValueSql("(newid())")
                .HasComment(
                    "ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.");
        });

        modelBuilder.Entity<ProductModelIllustration>(entity =>
        {
            entity.HasKey(e => new {e.ProductModelId, e.IllustrationId})
                .HasName("PK_ProductModelIllustration_ProductModelID_IllustrationID");

            entity.HasComment("Cross-reference table mapping product models and illustrations.");

            entity.Property(e => e.ProductModelId)
                .HasComment("Primary key. Foreign key to ProductModel.ProductModelID.");

            entity.Property(e => e.IllustrationId)
                .HasComment("Primary key. Foreign key to Illustration.IllustrationID.");

            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");

            entity.HasOne(d => d.Illustration)
                .WithMany(p => p.ProductModelIllustration)
                .HasForeignKey(d => d.IllustrationId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.ProductModel)
                .WithMany(p => p.ProductModelIllustration)
                .HasForeignKey(d => d.ProductModelId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<ProductModelProductDescriptionCulture>(entity =>
        {
            entity.HasKey(e => new {e.ProductModelId, e.ProductDescriptionId, e.CultureId})
                .HasName("PK_ProductModelProductDescriptionCulture_ProductModelID_ProductDescriptionID_CultureID");

            entity.HasComment(
                "Cross-reference table mapping product descriptions and the language the description is written in.");

            entity.Property(e => e.ProductModelId)
                .HasComment("Primary key. Foreign key to ProductModel.ProductModelID.");

            entity.Property(e => e.ProductDescriptionId)
                .HasComment("Primary key. Foreign key to ProductDescription.ProductDescriptionID.");

            entity.Property(e => e.CultureId)
                .IsFixedLength()
                .HasComment("Culture identification number. Foreign key to Culture.CultureID.");

            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");

            entity.HasOne(d => d.Culture)
                .WithMany(p => p.ProductModelProductDescriptionCulture)
                .HasForeignKey(d => d.CultureId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.ProductDescription)
                .WithMany(p => p.ProductModelProductDescriptionCulture)
                .HasForeignKey(d => d.ProductDescriptionId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.ProductModel)
                .WithMany(p => p.ProductModelProductDescriptionCulture)
                .HasForeignKey(d => d.ProductModelId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<ProductPhoto>(entity =>
        {
            entity.HasComment("Product images.");

            entity.Property(e => e.ProductPhotoId).HasComment("Primary key for ProductPhoto records.");

            entity.Property(e => e.LargePhoto).HasComment("Large image of the product.");

            entity.Property(e => e.LargePhotoFileName).HasComment("Large image file name.");

            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");

            entity.Property(e => e.ThumbNailPhoto).HasComment("Small image of the product.");

            entity.Property(e => e.ThumbnailPhotoFileName).HasComment("Small image file name.");
        });

        modelBuilder.Entity<ProductProductPhoto>(entity =>
        {
            entity.HasKey(e => new {e.ProductId, e.ProductPhotoId})
                .HasName("PK_ProductProductPhoto_ProductID_ProductPhotoID")
                .IsClustered(false);

            entity.HasComment("Cross-reference table mapping products and product photos.");

            entity.Property(e => e.ProductId)
                .HasComment("Product identification number. Foreign key to Product.ProductID.");

            entity.Property(e => e.ProductPhotoId)
                .HasComment("Product photo identification number. Foreign key to ProductPhoto.ProductPhotoID.");

            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");

            entity.Property(e => e.Primary)
                .HasComment("0 = Photo is not the principal image. 1 = Photo is the principal image.");

            entity.HasOne(d => d.Product)
                .WithMany(p => p.ProductProductPhoto)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.ProductPhoto)
                .WithMany(p => p.ProductProductPhoto)
                .HasForeignKey(d => d.ProductPhotoId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<ProductReview>(entity =>
        {
            entity.HasComment("Customer reviews of products they have purchased.");

            entity.HasIndex(e => new {e.Comments, e.ProductId, e.ReviewerName})
                .HasName("IX_ProductReview_ProductID_Name");

            entity.Property(e => e.ProductReviewId).HasComment("Primary key for ProductReview records.");

            entity.Property(e => e.Comments).HasComment("Reviewer's comments");

            entity.Property(e => e.EmailAddress).HasComment("Reviewer's e-mail address.");

            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");

            entity.Property(e => e.ProductId)
                .HasComment("Product identification number. Foreign key to Product.ProductID.");

            entity.Property(e => e.Rating)
                .HasComment("Product rating given by the reviewer. Scale is 1 to 5 with 5 as the highest rating.");

            entity.Property(e => e.ReviewDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date review was submitted.");

            entity.Property(e => e.ReviewerName).HasComment("Name of the reviewer.");

            entity.HasOne(d => d.Product)
                .WithMany(p => p.ProductReview)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<ProductSubcategory>(entity =>
        {
            entity.HasComment("Product subcategories. See ProductCategory table.");

            entity.HasIndex(e => e.Name)
                .HasName("AK_ProductSubcategory_Name")
                .IsUnique();

            entity.HasIndex(e => e.Rowguid)
                .HasName("AK_ProductSubcategory_rowguid")
                .IsUnique();

            entity.Property(e => e.ProductSubcategoryId).HasComment("Primary key for ProductSubcategory records.");

            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");

            entity.Property(e => e.Name).HasComment("Subcategory description.");

            entity.Property(e => e.ProductCategoryId).HasComment(
                "Product category identification number. Foreign key to ProductCategory.ProductCategoryID.");

            entity.Property(e => e.Rowguid)
                .HasDefaultValueSql("(newid())")
                .HasComment(
                    "ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.");

            entity.HasOne(d => d.ProductCategory)
                .WithMany(p => p.ProductSubcategory)
                .HasForeignKey(d => d.ProductCategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<ProductVendor>(entity =>
        {
            entity.HasKey(e => new {e.ProductId, e.BusinessEntityId})
                .HasName("PK_ProductVendor_ProductID_BusinessEntityID");

            entity.HasComment("Cross-reference table mapping vendors with the products they supply.");

            entity.HasIndex(e => e.BusinessEntityId);

            entity.HasIndex(e => e.UnitMeasureCode);

            entity.Property(e => e.ProductId).HasComment("Primary key. Foreign key to Product.ProductID.");

            entity.Property(e => e.BusinessEntityId)
                .HasComment("Primary key. Foreign key to Vendor.BusinessEntityID.");

            entity.Property(e => e.AverageLeadTime).HasComment(
                "The average span of time (in days) between placing an order with the vendor and receiving the purchased product.");

            entity.Property(e => e.LastReceiptCost).HasComment("The selling price when last purchased.");

            entity.Property(e => e.LastReceiptDate).HasComment("Date the product was last received by the vendor.");

            entity.Property(e => e.MaxOrderQty).HasComment("The minimum quantity that should be ordered.");

            entity.Property(e => e.MinOrderQty).HasComment("The maximum quantity that should be ordered.");

            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");

            entity.Property(e => e.OnOrderQty).HasComment("The quantity currently on order.");

            entity.Property(e => e.StandardPrice).HasComment("The vendor's usual selling price.");

            entity.Property(e => e.UnitMeasureCode)
                .IsFixedLength()
                .HasComment("The product's unit of measure.");

            entity.HasOne(d => d.BusinessEntity)
                .WithMany(p => p.ProductVendor)
                .HasForeignKey(d => d.BusinessEntityId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Product)
                .WithMany(p => p.ProductVendor)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.UnitMeasureCodeNavigation)
                .WithMany(p => p.ProductVendor)
                .HasForeignKey(d => d.UnitMeasureCode)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<PurchaseOrderDetail>(entity =>
        {
            entity.HasKey(e => new {e.PurchaseOrderId, e.PurchaseOrderDetailId})
                .HasName("PK_PurchaseOrderDetail_PurchaseOrderID_PurchaseOrderDetailID");

            entity.HasComment(
                "Individual products associated with a specific purchase order. See PurchaseOrderHeader.");

            entity.HasIndex(e => e.ProductId);

            entity.Property(e => e.PurchaseOrderId)
                .HasComment("Primary key. Foreign key to PurchaseOrderHeader.PurchaseOrderID.");

            entity.Property(e => e.PurchaseOrderDetailId)
                .HasComment("Primary key. One line number per purchased product.")
                .ValueGeneratedOnAdd();

            entity.Property(e => e.DueDate).HasComment("Date the product is expected to be received.");

            entity.Property(e => e.LineTotal)
                .HasComment("Per product subtotal. Computed as OrderQty * UnitPrice.")
                .HasComputedColumnSql("(isnull([OrderQty]*[UnitPrice],(0.00)))");

            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");

            entity.Property(e => e.OrderQty).HasComment("Quantity ordered.");

            entity.Property(e => e.ProductId)
                .HasComment("Product identification number. Foreign key to Product.ProductID.");

            entity.Property(e => e.ReceivedQty).HasComment("Quantity actually received from the vendor.");

            entity.Property(e => e.RejectedQty).HasComment("Quantity rejected during inspection.");

            entity.Property(e => e.StockedQty)
                .HasComment("Quantity accepted into inventory. Computed as ReceivedQty - RejectedQty.")
                .HasComputedColumnSql("(isnull([ReceivedQty]-[RejectedQty],(0.00)))");

            entity.Property(e => e.UnitPrice).HasComment("Vendor's selling price of a single product.");

            entity.HasOne(d => d.Product)
                .WithMany(p => p.PurchaseOrderDetail)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.PurchaseOrder)
                .WithMany(p => p.PurchaseOrderDetail)
                .HasForeignKey(d => d.PurchaseOrderId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<PurchaseOrderHeader>(entity =>
        {
            entity.HasKey(e => e.PurchaseOrderId)
                .HasName("PK_PurchaseOrderHeader_PurchaseOrderID");

            entity.HasComment("General purchase order information. See PurchaseOrderDetail.");

            entity.HasIndex(e => e.EmployeeId);

            entity.HasIndex(e => e.VendorId);

            entity.Property(e => e.PurchaseOrderId).HasComment("Primary key.");

            entity.Property(e => e.EmployeeId)
                .HasComment("Employee who created the purchase order. Foreign key to Employee.BusinessEntityID.");

            entity.Property(e => e.Freight)
                .HasDefaultValueSql("((0.00))")
                .HasComment("Shipping cost.");

            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");

            entity.Property(e => e.OrderDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Purchase order creation date.");

            entity.Property(e => e.RevisionNumber)
                .HasComment("Incremental number to track changes to the purchase order over time.");

            entity.Property(e => e.ShipDate).HasComment("Estimated shipment date from the vendor.");

            entity.Property(e => e.ShipMethodId)
                .HasComment("Shipping method. Foreign key to ShipMethod.ShipMethodID.");

            entity.Property(e => e.Status)
                .HasDefaultValueSql("((1))")
                .HasComment("Order current status. 1 = Pending; 2 = Approved; 3 = Rejected; 4 = Complete");

            entity.Property(e => e.SubTotal)
                .HasDefaultValueSql("((0.00))")
                .HasComment(
                    "Purchase order subtotal. Computed as SUM(PurchaseOrderDetail.LineTotal)for the appropriate PurchaseOrderID.");

            entity.Property(e => e.TaxAmt)
                .HasDefaultValueSql("((0.00))")
                .HasComment("Tax amount.");

            entity.Property(e => e.TotalDue)
                .HasComment("Total due to vendor. Computed as Subtotal + TaxAmt + Freight.")
                .HasComputedColumnSql("(isnull(([SubTotal]+[TaxAmt])+[Freight],(0)))");

            entity.Property(e => e.VendorId)
                .HasComment(
                    "Vendor with whom the purchase order is placed. Foreign key to Vendor.BusinessEntityID.");

            entity.HasOne(d => d.Employee)
                .WithMany(p => p.PurchaseOrderHeader)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.ShipMethod)
                .WithMany(p => p.PurchaseOrderHeader)
                .HasForeignKey(d => d.ShipMethodId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Vendor)
                .WithMany(p => p.PurchaseOrderHeader)
                .HasForeignKey(d => d.VendorId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<SalesOrderDetail>(entity =>
        {
            entity.HasKey(e => new {e.SalesOrderId, e.SalesOrderDetailId})
                .HasName("PK_SalesOrderDetail_SalesOrderID_SalesOrderDetailID");

            entity.HasComment("Individual products associated with a specific sales order. See SalesOrderHeader.");

            entity.HasIndex(e => e.ProductId);

            entity.HasIndex(e => e.Rowguid)
                .HasName("AK_SalesOrderDetail_rowguid")
                .IsUnique();

            entity.Property(e => e.SalesOrderId)
                .HasComment("Primary key. Foreign key to SalesOrderHeader.SalesOrderID.");

            entity.Property(e => e.SalesOrderDetailId)
                .HasComment("Primary key. One incremental unique number per product sold.")
                .ValueGeneratedOnAdd();

            entity.Property(e => e.CarrierTrackingNumber)
                .HasComment("Shipment tracking number supplied by the shipper.");

            entity.Property(e => e.LineTotal)
                .HasComment("Per product subtotal. Computed as UnitPrice * (1 - UnitPriceDiscount) * OrderQty.")
                .HasComputedColumnSql("(isnull(([UnitPrice]*((1.0)-[UnitPriceDiscount]))*[OrderQty],(0.0)))");

            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");

            entity.Property(e => e.OrderQty).HasComment("Quantity ordered per product.");

            entity.Property(e => e.ProductId)
                .HasComment("Product sold to customer. Foreign key to Product.ProductID.");

            entity.Property(e => e.Rowguid)
                .HasDefaultValueSql("(newid())")
                .HasComment(
                    "ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.");

            entity.Property(e => e.SpecialOfferId)
                .HasComment("Promotional code. Foreign key to SpecialOffer.SpecialOfferID.");

            entity.Property(e => e.UnitPrice).HasComment("Selling price of a single product.");

            entity.Property(e => e.UnitPriceDiscount).HasComment("Discount amount.");

            entity.HasOne(d => d.SpecialOfferProduct)
                .WithMany(p => p.SalesOrderDetail)
                .HasForeignKey(d => new {d.SpecialOfferId, d.ProductId})
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SalesOrderDetail_SpecialOfferProduct_SpecialOfferIDProductID");
        });

        modelBuilder.Entity<SalesOrderHeader>(entity =>
        {
            entity.HasKey(e => e.SalesOrderId)
                .HasName("PK_SalesOrderHeader_SalesOrderID");

            entity.HasComment("General sales order information.");

            entity.HasIndex(e => e.CustomerId);

            entity.HasIndex(e => e.Rowguid)
                .HasName("AK_SalesOrderHeader_rowguid")
                .IsUnique();

            entity.HasIndex(e => e.SalesOrderNumber)
                .HasName("AK_SalesOrderHeader_SalesOrderNumber")
                .IsUnique();

            entity.HasIndex(e => e.SalesPersonId);

            entity.Property(e => e.SalesOrderId).HasComment("Primary key.");

            entity.Property(e => e.AccountNumber).HasComment("Financial accounting number reference.");

            entity.Property(e => e.BillToAddressId)
                .HasComment("Customer billing address. Foreign key to Address.AddressID.");

            entity.Property(e => e.Comment).HasComment("Sales representative comments.");

            entity.Property(e => e.CreditCardApprovalCode)
                .IsUnicode(false)
                .HasComment("Approval code provided by the credit card company.");

            entity.Property(e => e.CreditCardId)
                .HasComment("Credit card identification number. Foreign key to CreditCard.CreditCardID.");

            entity.Property(e => e.CurrencyRateId)
                .HasComment("Currency exchange rate used. Foreign key to CurrencyRate.CurrencyRateID.");

            entity.Property(e => e.CustomerId)
                .HasComment("Customer identification number. Foreign key to Customer.BusinessEntityID.");

            entity.Property(e => e.DueDate).HasComment("Date the order is due to the customer.");

            entity.Property(e => e.Freight)
                .HasDefaultValueSql("((0.00))")
                .HasComment("Shipping cost.");

            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");

            entity.Property(e => e.OnlineOrderFlag)
                .HasDefaultValueSql("((1))")
                .HasComment("0 = Order placed by sales person. 1 = Order placed online by customer.");

            entity.Property(e => e.OrderDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Dates the sales order was created.");

            entity.Property(e => e.PurchaseOrderNumber).HasComment("Customer purchase order number reference. ");

            entity.Property(e => e.RevisionNumber)
                .HasComment("Incremental number to track changes to the sales order over time.");

            entity.Property(e => e.Rowguid)
                .HasDefaultValueSql("(newid())")
                .HasComment(
                    "ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.");

            entity.Property(e => e.SalesOrderNumber)
                .HasComment("Unique sales order identification number.")
                .HasComputedColumnSql("(isnull(N'SO'+CONVERT([nvarchar](23),[SalesOrderID]),N'*** ERROR ***'))");

            entity.Property(e => e.SalesPersonId)
                .HasComment(
                    "Sales person who created the sales order. Foreign key to SalesPerson.BusinessEntityID.");

            entity.Property(e => e.ShipDate).HasComment("Date the order was shipped to the customer.");

            entity.Property(e => e.ShipMethodId)
                .HasComment("Shipping method. Foreign key to ShipMethod.ShipMethodID.");

            entity.Property(e => e.ShipToAddressId)
                .HasComment("Customer shipping address. Foreign key to Address.AddressID.");

            entity.Property(e => e.Status)
                .HasDefaultValueSql("((1))")
                .HasComment(
                    "Order current status. 1 = In process; 2 = Approved; 3 = Backordered; 4 = Rejected; 5 = Shipped; 6 = Cancelled");

            entity.Property(e => e.SubTotal)
                .HasDefaultValueSql("((0.00))")
                .HasComment(
                    "Sales subtotal. Computed as SUM(SalesOrderDetail.LineTotal)for the appropriate SalesOrderID.");

            entity.Property(e => e.TaxAmt)
                .HasDefaultValueSql("((0.00))")
                .HasComment("Tax amount.");

            entity.Property(e => e.TerritoryId)
                .HasComment(
                    "Territory in which the sale was made. Foreign key to SalesTerritory.SalesTerritoryID.");

            entity.Property(e => e.TotalDue)
                .HasComment("Total due from customer. Computed as Subtotal + TaxAmt + Freight.")
                .HasComputedColumnSql("(isnull(([SubTotal]+[TaxAmt])+[Freight],(0)))");

            entity.HasOne(d => d.BillToAddress)
                .WithMany(p => p.SalesOrderHeaderBillToAddress)
                .HasForeignKey(d => d.BillToAddressId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Customer)
                .WithMany(p => p.SalesOrderHeader)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.ShipMethod)
                .WithMany(p => p.SalesOrderHeader)
                .HasForeignKey(d => d.ShipMethodId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.ShipToAddress)
                .WithMany(p => p.SalesOrderHeaderShipToAddress)
                .HasForeignKey(d => d.ShipToAddressId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<SalesOrderHeaderSalesReason>(entity =>
        {
            entity.HasKey(e => new {e.SalesOrderId, e.SalesReasonId})
                .HasName("PK_SalesOrderHeaderSalesReason_SalesOrderID_SalesReasonID");

            entity.HasComment("Cross-reference table mapping sales orders to sales reason codes.");

            entity.Property(e => e.SalesOrderId)
                .HasComment("Primary key. Foreign key to SalesOrderHeader.SalesOrderID.");

            entity.Property(e => e.SalesReasonId)
                .HasComment("Primary key. Foreign key to SalesReason.SalesReasonID.");

            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");

            entity.HasOne(d => d.SalesReason)
                .WithMany(p => p.SalesOrderHeaderSalesReason)
                .HasForeignKey(d => d.SalesReasonId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<SalesPerson>(entity =>
        {
            entity.HasKey(e => e.BusinessEntityId)
                .HasName("PK_SalesPerson_BusinessEntityID");

            entity.HasComment("Sales representative current information.");

            entity.HasIndex(e => e.Rowguid)
                .HasName("AK_SalesPerson_rowguid")
                .IsUnique();

            entity.Property(e => e.BusinessEntityId)
                .HasComment("Primary key for SalesPerson records. Foreign key to Employee.BusinessEntityID")
                .ValueGeneratedNever();

            entity.Property(e => e.Bonus)
                .HasDefaultValueSql("((0.00))")
                .HasComment("Bonus due if quota is met.");

            entity.Property(e => e.CommissionPct)
                .HasDefaultValueSql("((0.00))")
                .HasComment("Commision percent received per sale.");

            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");

            entity.Property(e => e.Rowguid)
                .HasDefaultValueSql("(newid())")
                .HasComment(
                    "ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.");

            entity.Property(e => e.SalesLastYear)
                .HasDefaultValueSql("((0.00))")
                .HasComment("Sales total of previous year.");

            entity.Property(e => e.SalesQuota).HasComment("Projected yearly sales.");

            entity.Property(e => e.SalesYtd)
                .HasDefaultValueSql("((0.00))")
                .HasComment("Sales total year to date.");

            entity.Property(e => e.TerritoryId)
                .HasComment("Territory currently assigned to. Foreign key to SalesTerritory.SalesTerritoryID.");

            entity.HasOne(d => d.BusinessEntity)
                .WithOne(p => p.SalesPerson)
                .HasForeignKey<SalesPerson>(d => d.BusinessEntityId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<SalesPersonQuotaHistory>(entity =>
        {
            entity.HasKey(e => new {e.BusinessEntityId, e.QuotaDate})
                .HasName("PK_SalesPersonQuotaHistory_BusinessEntityID_QuotaDate");

            entity.HasComment("Sales performance tracking.");

            entity.HasIndex(e => e.Rowguid)
                .HasName("AK_SalesPersonQuotaHistory_rowguid")
                .IsUnique();

            entity.Property(e => e.BusinessEntityId)
                .HasComment("Sales person identification number. Foreign key to SalesPerson.BusinessEntityID.");

            entity.Property(e => e.QuotaDate).HasComment("Sales quota date.");

            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");

            entity.Property(e => e.Rowguid)
                .HasDefaultValueSql("(newid())")
                .HasComment(
                    "ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.");

            entity.Property(e => e.SalesQuota).HasComment("Sales quota amount.");

            entity.HasOne(d => d.BusinessEntity)
                .WithMany(p => p.SalesPersonQuotaHistory)
                .HasForeignKey(d => d.BusinessEntityId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<SalesReason>(entity =>
        {
            entity.HasComment("Lookup table of customer purchase reasons.");

            entity.Property(e => e.SalesReasonId).HasComment("Primary key for SalesReason records.");

            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");

            entity.Property(e => e.Name).HasComment("Sales reason description.");

            entity.Property(e => e.ReasonType).HasComment("Category the sales reason belongs to.");
        });

        modelBuilder.Entity<SalesTaxRate>(entity =>
        {
            entity.HasComment("Tax rate lookup table.");

            entity.HasIndex(e => e.Rowguid)
                .HasName("AK_SalesTaxRate_rowguid")
                .IsUnique();

            entity.HasIndex(e => new {e.StateProvinceId, e.TaxType})
                .HasName("AK_SalesTaxRate_StateProvinceID_TaxType")
                .IsUnique();

            entity.Property(e => e.SalesTaxRateId).HasComment("Primary key for SalesTaxRate records.");

            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");

            entity.Property(e => e.Name).HasComment("Tax rate description.");

            entity.Property(e => e.Rowguid)
                .HasDefaultValueSql("(newid())")
                .HasComment(
                    "ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.");

            entity.Property(e => e.StateProvinceId)
                .HasComment("State, province, or country/region the sales tax applies to.");

            entity.Property(e => e.TaxRate)
                .HasDefaultValueSql("((0.00))")
                .HasComment("Tax rate amount.");

            entity.Property(e => e.TaxType)
                .HasComment(
                    "1 = Tax applied to retail transactions, 2 = Tax applied to wholesale transactions, 3 = Tax applied to all sales (retail and wholesale) transactions.");

            entity.HasOne(d => d.StateProvince)
                .WithMany(p => p.SalesTaxRate)
                .HasForeignKey(d => d.StateProvinceId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<SalesTerritory>(entity =>
        {
            entity.HasKey(e => e.TerritoryId)
                .HasName("PK_SalesTerritory_TerritoryID");

            entity.HasComment("Sales territory lookup table.");

            entity.HasIndex(e => e.Name)
                .HasName("AK_SalesTerritory_Name")
                .IsUnique();

            entity.HasIndex(e => e.Rowguid)
                .HasName("AK_SalesTerritory_rowguid")
                .IsUnique();

            entity.Property(e => e.TerritoryId).HasComment("Primary key for SalesTerritory records.");

            entity.Property(e => e.CostLastYear)
                .HasDefaultValueSql("((0.00))")
                .HasComment("Business costs in the territory the previous year.");

            entity.Property(e => e.CostYtd)
                .HasDefaultValueSql("((0.00))")
                .HasComment("Business costs in the territory year to date.");

            entity.Property(e => e.CountryRegionCode)
                .HasComment(
                    "ISO standard country or region code. Foreign key to CountryRegion.CountryRegionCode. ");

            entity.Property(e => e.Group).HasComment("Geographic area to which the sales territory belong.");

            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");

            entity.Property(e => e.Name).HasComment("Sales territory description");

            entity.Property(e => e.Rowguid)
                .HasDefaultValueSql("(newid())")
                .HasComment(
                    "ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.");

            entity.Property(e => e.SalesLastYear)
                .HasDefaultValueSql("((0.00))")
                .HasComment("Sales in the territory the previous year.");

            entity.Property(e => e.SalesYtd)
                .HasDefaultValueSql("((0.00))")
                .HasComment("Sales in the territory year to date.");

            entity.HasOne(d => d.CountryRegionCodeNavigation)
                .WithMany(p => p.SalesTerritory)
                .HasForeignKey(d => d.CountryRegionCode)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<SalesTerritoryHistory>(entity =>
        {
            entity.HasKey(e => new {e.BusinessEntityId, e.StartDate, e.TerritoryId})
                .HasName("PK_SalesTerritoryHistory_BusinessEntityID_StartDate_TerritoryID");

            entity.HasComment("Sales representative transfers to other sales territories.");

            entity.HasIndex(e => e.Rowguid)
                .HasName("AK_SalesTerritoryHistory_rowguid")
                .IsUnique();

            entity.Property(e => e.BusinessEntityId)
                .HasComment("Primary key. The sales rep.  Foreign key to SalesPerson.BusinessEntityID.");

            entity.Property(e => e.StartDate)
                .HasComment("Primary key. Date the sales representive started work in the territory.");

            entity.Property(e => e.TerritoryId)
                .HasComment(
                    "Primary key. Territory identification number. Foreign key to SalesTerritory.SalesTerritoryID.");

            entity.Property(e => e.EndDate).HasComment("Date the sales representative left work in the territory.");

            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");

            entity.Property(e => e.Rowguid)
                .HasDefaultValueSql("(newid())")
                .HasComment(
                    "ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.");

            entity.HasOne(d => d.BusinessEntity)
                .WithMany(p => p.SalesTerritoryHistory)
                .HasForeignKey(d => d.BusinessEntityId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Territory)
                .WithMany(p => p.SalesTerritoryHistory)
                .HasForeignKey(d => d.TerritoryId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<ScrapReason>(entity =>
        {
            entity.HasComment("Manufacturing failure reasons lookup table.");

            entity.HasIndex(e => e.Name)
                .HasName("AK_ScrapReason_Name")
                .IsUnique();

            entity.Property(e => e.ScrapReasonId).HasComment("Primary key for ScrapReason records.");

            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");

            entity.Property(e => e.Name).HasComment("Failure description.");
        });

        modelBuilder.Entity<Shift>(entity =>
        {
            entity.HasComment("Work shift lookup table.");

            entity.HasIndex(e => e.Name)
                .HasName("AK_Shift_Name")
                .IsUnique();

            entity.HasIndex(e => new {e.StartTime, e.EndTime})
                .HasName("AK_Shift_StartTime_EndTime")
                .IsUnique();

            entity.Property(e => e.ShiftId)
                .HasComment("Primary key for Shift records.")
                .ValueGeneratedOnAdd();

            entity.Property(e => e.EndTime).HasComment("Shift end time.");

            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");

            entity.Property(e => e.Name).HasComment("Shift description.");

            entity.Property(e => e.StartTime).HasComment("Shift start time.");
        });

        modelBuilder.Entity<ShipMethod>(entity =>
        {
            entity.HasComment("Shipping company lookup table.");

            entity.HasIndex(e => e.Name)
                .HasName("AK_ShipMethod_Name")
                .IsUnique();

            entity.HasIndex(e => e.Rowguid)
                .HasName("AK_ShipMethod_rowguid")
                .IsUnique();

            entity.Property(e => e.ShipMethodId).HasComment("Primary key for ShipMethod records.");

            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");

            entity.Property(e => e.Name).HasComment("Shipping company name.");

            entity.Property(e => e.Rowguid)
                .HasDefaultValueSql("(newid())")
                .HasComment(
                    "ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.");

            entity.Property(e => e.ShipBase)
                .HasDefaultValueSql("((0.00))")
                .HasComment("Minimum shipping charge.");

            entity.Property(e => e.ShipRate)
                .HasDefaultValueSql("((0.00))")
                .HasComment("Shipping charge per pound.");
        });

        modelBuilder.Entity<ShoppingCartItem>(entity =>
        {
            entity.HasComment("Contains online customer orders until the order is submitted or cancelled.");

            entity.HasIndex(e => new {e.ShoppingCartId, e.ProductId});

            entity.Property(e => e.ShoppingCartItemId).HasComment("Primary key for ShoppingCartItem records.");

            entity.Property(e => e.DateCreated)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date the time the record was created.");

            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");

            entity.Property(e => e.ProductId).HasComment("Product ordered. Foreign key to Product.ProductID.");

            entity.Property(e => e.Quantity)
                .HasDefaultValueSql("((1))")
                .HasComment("Product quantity ordered.");

            entity.Property(e => e.ShoppingCartId).HasComment("Shopping cart identification number.");

            entity.HasOne(d => d.Product)
                .WithMany(p => p.ShoppingCartItem)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<SpecialOffer>(entity =>
        {
            entity.HasComment("Sale discounts lookup table.");

            entity.HasIndex(e => e.Rowguid)
                .HasName("AK_SpecialOffer_rowguid")
                .IsUnique();

            entity.Property(e => e.SpecialOfferId).HasComment("Primary key for SpecialOffer records.");

            entity.Property(e => e.Category)
                .HasComment("Group the discount applies to such as Reseller or Customer.");

            entity.Property(e => e.Description).HasComment("Discount description.");

            entity.Property(e => e.DiscountPct)
                .HasDefaultValueSql("((0.00))")
                .HasComment("Discount precentage.");

            entity.Property(e => e.EndDate).HasComment("Discount end date.");

            entity.Property(e => e.MaxQty).HasComment("Maximum discount percent allowed.");

            entity.Property(e => e.MinQty).HasComment("Minimum discount percent allowed.");

            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");

            entity.Property(e => e.Rowguid)
                .HasDefaultValueSql("(newid())")
                .HasComment(
                    "ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.");

            entity.Property(e => e.StartDate).HasComment("Discount start date.");

            entity.Property(e => e.Type).HasComment("Discount type category.");
        });

        modelBuilder.Entity<SpecialOfferProduct>(entity =>
        {
            entity.HasKey(e => new {e.SpecialOfferId, e.ProductId})
                .HasName("PK_SpecialOfferProduct_SpecialOfferID_ProductID");

            entity.HasComment("Cross-reference table mapping products to special offer discounts.");

            entity.HasIndex(e => e.ProductId);

            entity.HasIndex(e => e.Rowguid)
                .HasName("AK_SpecialOfferProduct_rowguid")
                .IsUnique();

            entity.Property(e => e.SpecialOfferId).HasComment("Primary key for SpecialOfferProduct records.");

            entity.Property(e => e.ProductId)
                .HasComment("Product identification number. Foreign key to Product.ProductID.");

            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");

            entity.Property(e => e.Rowguid)
                .HasDefaultValueSql("(newid())")
                .HasComment(
                    "ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.");

            entity.HasOne(d => d.Product)
                .WithMany(p => p.SpecialOfferProduct)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.SpecialOffer)
                .WithMany(p => p.SpecialOfferProduct)
                .HasForeignKey(d => d.SpecialOfferId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<StateProvince>(entity =>
        {
            entity.HasComment("State and province lookup table.");

            entity.HasIndex(e => e.Name)
                .HasName("AK_StateProvince_Name")
                .IsUnique();

            entity.HasIndex(e => e.Rowguid)
                .HasName("AK_StateProvince_rowguid")
                .IsUnique();

            entity.HasIndex(e => new {e.StateProvinceCode, e.CountryRegionCode})
                .HasName("AK_StateProvince_StateProvinceCode_CountryRegionCode")
                .IsUnique();

            entity.Property(e => e.StateProvinceId).HasComment("Primary key for StateProvince records.");

            entity.Property(e => e.CountryRegionCode)
                .HasComment(
                    "ISO standard country or region code. Foreign key to CountryRegion.CountryRegionCode. ");

            entity.Property(e => e.IsOnlyStateProvinceFlag)
                .HasDefaultValueSql("((1))")
                .HasComment(
                    "0 = StateProvinceCode exists. 1 = StateProvinceCode unavailable, using CountryRegionCode.");

            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");

            entity.Property(e => e.Name).HasComment("State or province description.");

            entity.Property(e => e.Rowguid)
                .HasDefaultValueSql("(newid())")
                .HasComment(
                    "ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.");

            entity.Property(e => e.StateProvinceCode)
                .IsFixedLength()
                .HasComment("ISO standard state or province code.");

            entity.Property(e => e.TerritoryId)
                .HasComment(
                    "ID of the territory in which the state or province is located. Foreign key to SalesTerritory.SalesTerritoryID.");

            entity.HasOne(d => d.CountryRegionCodeNavigation)
                .WithMany(p => p.StateProvince)
                .HasForeignKey(d => d.CountryRegionCode)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Territory)
                .WithMany(p => p.StateProvince)
                .HasForeignKey(d => d.TerritoryId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Store>(entity =>
        {
            entity.HasKey(e => e.BusinessEntityId)
                .HasName("PK_Store_BusinessEntityID");

            entity.HasComment("Customers (resellers) of Adventure Works products.");

            entity.HasIndex(e => e.Demographics)
                .HasName("PXML_Store_Demographics");

            entity.HasIndex(e => e.Rowguid)
                .HasName("AK_Store_rowguid")
                .IsUnique();

            entity.HasIndex(e => e.SalesPersonId);

            entity.Property(e => e.BusinessEntityId)
                .HasComment("Primary key. Foreign key to Customer.BusinessEntityID.")
                .ValueGeneratedNever();

            entity.Property(e => e.Demographics)
                .HasComment(
                    "Demographic informationg about the store such as the number of employees, annual sales and store type.");

            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");

            entity.Property(e => e.Name).HasComment("Name of the store.");

            entity.Property(e => e.Rowguid)
                .HasDefaultValueSql("(newid())")
                .HasComment(
                    "ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.");

            entity.Property(e => e.SalesPersonId)
                .HasComment(
                    "ID of the sales person assigned to the customer. Foreign key to SalesPerson.BusinessEntityID.");

            entity.HasOne(d => d.BusinessEntity)
                .WithOne(p => p.Store)
                .HasForeignKey<Store>(d => d.BusinessEntityId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<TransactionHistory>(entity =>
        {
            entity.HasKey(e => e.TransactionId)
                .HasName("PK_TransactionHistory_TransactionID");

            entity.HasComment(
                "Record of each purchase order, sales order, or work order transaction year to date.");

            entity.HasIndex(e => e.ProductId);

            entity.HasIndex(e => new {e.ReferenceOrderId, e.ReferenceOrderLineId});

            entity.Property(e => e.TransactionId).HasComment("Primary key for TransactionHistory records.");

            entity.Property(e => e.ActualCost).HasComment("Product cost.");

            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");

            entity.Property(e => e.ProductId)
                .HasComment("Product identification number. Foreign key to Product.ProductID.");

            entity.Property(e => e.Quantity).HasComment("Product quantity.");

            entity.Property(e => e.ReferenceOrderId)
                .HasComment("Purchase order, sales order, or work order identification number.");

            entity.Property(e => e.ReferenceOrderLineId)
                .HasComment("Line number associated with the purchase order, sales order, or work order.");

            entity.Property(e => e.TransactionDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time of the transaction.");

            entity.Property(e => e.TransactionType)
                .IsFixedLength()
                .HasComment("W = WorkOrder, S = SalesOrder, P = PurchaseOrder");

            entity.HasOne(d => d.Product)
                .WithMany(p => p.TransactionHistory)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<TransactionHistoryArchive>(entity =>
        {
            entity.HasKey(e => e.TransactionId)
                .HasName("PK_TransactionHistoryArchive_TransactionID");

            entity.HasComment("Transactions for previous years.");

            entity.HasIndex(e => e.ProductId);

            entity.HasIndex(e => new {e.ReferenceOrderId, e.ReferenceOrderLineId});

            entity.Property(e => e.TransactionId)
                .HasComment("Primary key for TransactionHistoryArchive records.")
                .ValueGeneratedNever();

            entity.Property(e => e.ActualCost).HasComment("Product cost.");

            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");

            entity.Property(e => e.ProductId)
                .HasComment("Product identification number. Foreign key to Product.ProductID.");

            entity.Property(e => e.Quantity).HasComment("Product quantity.");

            entity.Property(e => e.ReferenceOrderId)
                .HasComment("Purchase order, sales order, or work order identification number.");

            entity.Property(e => e.ReferenceOrderLineId)
                .HasComment("Line number associated with the purchase order, sales order, or work order.");

            entity.Property(e => e.TransactionDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time of the transaction.");

            entity.Property(e => e.TransactionType)
                .IsFixedLength()
                .HasComment("W = Work Order, S = Sales Order, P = Purchase Order");
        });

        modelBuilder.Entity<UnitMeasure>(entity =>
        {
            entity.HasKey(e => e.UnitMeasureCode)
                .HasName("PK_UnitMeasure_UnitMeasureCode");

            entity.HasComment("Unit of measure lookup table.");

            entity.HasIndex(e => e.Name)
                .HasName("AK_UnitMeasure_Name")
                .IsUnique();

            entity.Property(e => e.UnitMeasureCode)
                .IsFixedLength()
                .HasComment("Primary key.");

            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");

            entity.Property(e => e.Name).HasComment("Unit of measure description.");
        });

        modelBuilder.Entity<VAdditionalContactInfo>(entity =>
        {
            entity.HasNoKey();

            entity.ToView("vAdditionalContactInfo", "Person");

            entity.HasComment(
                "Displays the contact name and content from each element in the xml column AdditionalContactInfo for that person.");
        });

        modelBuilder.Entity<VEmployee>(entity =>
        {
            entity.HasNoKey();

            entity.ToView("vEmployee", "HumanResources");

            entity.HasComment("Employee names and addresses.");
        });

        modelBuilder.Entity<VEmployeeDepartment>(entity =>
        {
            entity.HasNoKey();

            entity.ToView("vEmployeeDepartment", "HumanResources");

            entity.HasComment("Returns employee name, title, and current department.");
        });

        modelBuilder.Entity<VEmployeeDepartmentHistory>(entity =>
        {
            entity.HasNoKey();

            entity.ToView("vEmployeeDepartmentHistory", "HumanResources");

            entity.HasComment("Returns employee name and current and previous departments.");
        });

        modelBuilder.Entity<VIndividualCustomer>(entity =>
        {
            entity.HasNoKey();

            entity.ToView("vIndividualCustomer", "Sales");

            entity.HasComment(
                "Individual customers (names and addresses) that purchase Adventure Works Cycles products online.");
        });

        modelBuilder.Entity<VJobCandidate>(entity =>
        {
            entity.HasNoKey();

            entity.ToView("vJobCandidate", "HumanResources");

            entity.HasComment("Job candidate names and resumes.");

            entity.Property(e => e.JobCandidateId).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<VJobCandidateEducation>(entity =>
        {
            entity.HasNoKey();

            entity.ToView("vJobCandidateEducation", "HumanResources");

            entity.HasComment(
                "Displays the content from each education related element in the xml column Resume in the HumanResources.JobCandidate table. The content has been localized into French, Simplified Chinese and Thai. Some data may not display correctly unless supplemental language support is installed.");

            entity.Property(e => e.JobCandidateId).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<VJobCandidateEmployment>(entity =>
        {
            entity.HasNoKey();

            entity.ToView("vJobCandidateEmployment", "HumanResources");

            entity.HasComment(
                "Displays the content from each employement history related element in the xml column Resume in the HumanResources.JobCandidate table. The content has been localized into French, Simplified Chinese and Thai. Some data may not display correctly unless supplemental language support is installed.");

            entity.Property(e => e.JobCandidateId).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<VPersonDemographics>(entity =>
        {
            entity.HasNoKey();

            entity.ToView("vPersonDemographics", "Sales");

            entity.HasComment(
                "Displays the content from each element in the xml column Demographics for each customer in the Person.Person table.");
        });

        modelBuilder.Entity<VProductAndDescription>(entity =>
        {
            entity.HasNoKey();

            entity.ToView("vProductAndDescription", "Production");

            entity.HasComment(
                "Product names and descriptions. Product descriptions are provided in multiple languages.");

            entity.Property(e => e.CultureId).IsFixedLength();
        });

        modelBuilder.Entity<VProductModelCatalogDescription>(entity =>
        {
            entity.HasNoKey();

            entity.ToView("vProductModelCatalogDescription", "Production");

            entity.HasComment(
                "Displays the content from each element in the xml column CatalogDescription for each product in the Production.ProductModel table that has catalog data.");

            entity.Property(e => e.ProductModelId).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<VProductModelInstructions>(entity =>
        {
            entity.HasNoKey();

            entity.ToView("vProductModelInstructions", "Production");

            entity.HasComment(
                "Displays the content from each element in the xml column Instructions for each product in the Production.ProductModel table that has manufacturing instructions.");

            entity.Property(e => e.ProductModelId).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<VSalesPerson>(entity =>
        {
            entity.HasNoKey();

            entity.ToView("vSalesPerson", "Sales");

            entity.HasComment("Sales representiatives (names and addresses) and their sales-related information.");
        });

        modelBuilder.Entity<VSalesPersonSalesByFiscalYears>(entity =>
        {
            entity.HasNoKey();

            entity.ToView("vSalesPersonSalesByFiscalYears", "Sales");

            entity.HasComment("Uses PIVOT to return aggregated sales information for each sales representative.");
        });

        modelBuilder.Entity<VStateProvinceCountryRegion>(entity =>
        {
            entity.HasNoKey();

            entity.ToView("vStateProvinceCountryRegion", "Person");

            entity.HasComment("Joins StateProvince table with CountryRegion table.");

            entity.Property(e => e.StateProvinceCode).IsFixedLength();
        });

        modelBuilder.Entity<VStoreWithAddresses>(entity =>
        {
            entity.HasNoKey();

            entity.ToView("vStoreWithAddresses", "Sales");

            entity.HasComment(
                "Stores (including store addresses) that sell Adventure Works Cycles products to consumers.");
        });

        modelBuilder.Entity<VStoreWithContacts>(entity =>
        {
            entity.HasNoKey();

            entity.ToView("vStoreWithContacts", "Sales");

            entity.HasComment(
                "Stores (including store contacts) that sell Adventure Works Cycles products to consumers.");
        });

        modelBuilder.Entity<VStoreWithDemographics>(entity =>
        {
            entity.HasNoKey();

            entity.ToView("vStoreWithDemographics", "Sales");

            entity.HasComment(
                "Stores (including demographics) that sell Adventure Works Cycles products to consumers.");
        });

        modelBuilder.Entity<VVendorWithAddresses>(entity =>
        {
            entity.HasNoKey();

            entity.ToView("vVendorWithAddresses", "Purchasing");

            entity.HasComment("Vendor (company) names and addresses .");
        });

        modelBuilder.Entity<VVendorWithContacts>(entity =>
        {
            entity.HasNoKey();

            entity.ToView("vVendorWithContacts", "Purchasing");

            entity.HasComment("Vendor (company) names  and the names of vendor employees to contact.");
        });

        modelBuilder.Entity<Vendor>(entity =>
        {
            entity.HasKey(e => e.BusinessEntityId)
                .HasName("PK_Vendor_BusinessEntityID");

            entity.HasComment("Companies from whom Adventure Works Cycles purchases parts or other goods.");

            entity.HasIndex(e => e.AccountNumber)
                .HasName("AK_Vendor_AccountNumber")
                .IsUnique();

            entity.Property(e => e.BusinessEntityId)
                .HasComment("Primary key for Vendor records.  Foreign key to BusinessEntity.BusinessEntityID")
                .ValueGeneratedNever();

            entity.Property(e => e.AccountNumber).HasComment("Vendor account (identification) number.");

            entity.Property(e => e.ActiveFlag)
                .HasDefaultValueSql("((1))")
                .HasComment("0 = Vendor no longer used. 1 = Vendor is actively used.");

            entity.Property(e => e.CreditRating)
                .HasComment("1 = Superior, 2 = Excellent, 3 = Above average, 4 = Average, 5 = Below average");

            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");

            entity.Property(e => e.Name).HasComment("Company name.");

            entity.Property(e => e.PreferredVendorStatus)
                .HasDefaultValueSql("((1))")
                .HasComment(
                    "0 = Do not use if another vendor is available. 1 = Preferred over other vendors supplying the same product.");

            entity.Property(e => e.PurchasingWebServiceUrl).HasComment("Vendor URL.");

            entity.HasOne(d => d.BusinessEntity)
                .WithOne(p => p.Vendor)
                .HasForeignKey<Vendor>(d => d.BusinessEntityId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<WorkOrder>(entity =>
        {
            entity.HasComment("Manufacturing work orders.");

            entity.HasIndex(e => e.ProductId);

            entity.HasIndex(e => e.ScrapReasonId);

            entity.Property(e => e.WorkOrderId).HasComment("Primary key for WorkOrder records.");

            entity.Property(e => e.DueDate).HasComment("Work order due date.");

            entity.Property(e => e.EndDate).HasComment("Work order end date.");

            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");

            entity.Property(e => e.OrderQty).HasComment("Product quantity to build.");

            entity.Property(e => e.ProductId)
                .HasComment("Product identification number. Foreign key to Product.ProductID.");

            entity.Property(e => e.ScrapReasonId).HasComment("Reason for inspection failure.");

            entity.Property(e => e.ScrappedQty).HasComment("Quantity that failed inspection.");

            entity.Property(e => e.StartDate).HasComment("Work order start date.");

            entity.Property(e => e.StockedQty)
                .HasComment("Quantity built and put in inventory.")
                .HasComputedColumnSql("(isnull([OrderQty]-[ScrappedQty],(0)))");

            entity.HasOne(d => d.Product)
                .WithMany(p => p.WorkOrder)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<WorkOrderRouting>(entity =>
        {
            entity.HasKey(e => new {e.WorkOrderId, e.ProductId, e.OperationSequence})
                .HasName("PK_WorkOrderRouting_WorkOrderID_ProductID_OperationSequence");

            entity.HasComment("Work order details.");

            entity.HasIndex(e => e.ProductId);

            entity.Property(e => e.WorkOrderId).HasComment("Primary key. Foreign key to WorkOrder.WorkOrderID.");

            entity.Property(e => e.ProductId).HasComment("Primary key. Foreign key to Product.ProductID.");

            entity.Property(e => e.OperationSequence)
                .HasComment("Primary key. Indicates the manufacturing process sequence.");

            entity.Property(e => e.ActualCost).HasComment("Actual manufacturing cost.");

            entity.Property(e => e.ActualEndDate).HasComment("Actual end date.");

            entity.Property(e => e.ActualResourceHrs).HasComment("Number of manufacturing hours used.");

            entity.Property(e => e.ActualStartDate).HasComment("Actual start date.");

            entity.Property(e => e.LocationId)
                .HasComment(
                    "Manufacturing location where the part is processed. Foreign key to Location.LocationID.");

            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");

            entity.Property(e => e.PlannedCost).HasComment("Estimated manufacturing cost.");

            entity.Property(e => e.ScheduledEndDate).HasComment("Planned manufacturing end date.");

            entity.Property(e => e.ScheduledStartDate).HasComment("Planned manufacturing start date.");

            entity.HasOne(d => d.Location)
                .WithMany(p => p.WorkOrderRouting)
                .HasForeignKey(d => d.LocationId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.WorkOrder)
                .WithMany(p => p.WorkOrderRouting)
                .HasForeignKey(d => d.WorkOrderId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}