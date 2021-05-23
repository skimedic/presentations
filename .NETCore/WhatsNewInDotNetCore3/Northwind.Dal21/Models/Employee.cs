using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Northwind.Dal21.Models
{
    [Table("Employee", Schema = "HumanResources")]
    public partial class Employee
    {
        public Employee()
        {
            EmployeeDepartmentHistory = new HashSet<EmployeeDepartmentHistory>();
            EmployeePayHistory = new HashSet<EmployeePayHistory>();
            JobCandidate = new HashSet<JobCandidate>();
            PurchaseOrderHeader = new HashSet<PurchaseOrderHeader>();
        }

        [Key]
        [Column("BusinessEntityID")]
        public int BusinessEntityId { get; set; }
        [Required]
        [Column("NationalIDNumber")]
        [StringLength(15)]
        public string NationalIdnumber { get; set; }
        [Required]
        [Column("LoginID")]
        [StringLength(256)]
        public string LoginId { get; set; }
        public short? OrganizationLevel { get; set; }
        [Required]
        [StringLength(50)]
        public string JobTitle { get; set; }
        [Column(TypeName = "date")]
        public DateTime BirthDate { get; set; }
        [Required]
        [StringLength(1)]
        public string MaritalStatus { get; set; }
        [Required]
        [StringLength(1)]
        public string Gender { get; set; }
        [Column(TypeName = "date")]
        public DateTime HireDate { get; set; }
        [Required]
        [Column(TypeName = "Flag")]
        public bool? SalariedFlag { get; set; }
        public short VacationHours { get; set; }
        public short SickLeaveHours { get; set; }
        [Required]
        [Column(TypeName = "Flag")]
        public bool? CurrentFlag { get; set; }
        [Column("rowguid")]
        public Guid Rowguid { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }

        [ForeignKey("BusinessEntityId")]
        [InverseProperty("Employee")]
        public Person BusinessEntity { get; set; }
        [InverseProperty("BusinessEntity")]
        public SalesPerson SalesPerson { get; set; }
        [InverseProperty("BusinessEntity")]
        public ICollection<EmployeeDepartmentHistory> EmployeeDepartmentHistory { get; set; }
        [InverseProperty("BusinessEntity")]
        public ICollection<EmployeePayHistory> EmployeePayHistory { get; set; }
        [InverseProperty("BusinessEntity")]
        public ICollection<JobCandidate> JobCandidate { get; set; }
        [InverseProperty("Employee")]
        public ICollection<PurchaseOrderHeader> PurchaseOrderHeader { get; set; }
    }
}
