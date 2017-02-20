using System;
using System.Collections.Generic;

namespace Performance.EFCore.Models
{
    public partial class Employee
    {
        public Employee()
        {
            EmployeeDepartmentHistory = new HashSet<EmployeeDepartmentHistory>();
            EmployeePayHistory = new HashSet<EmployeePayHistory>();
            JobCandidate = new HashSet<JobCandidate>();
            PurchaseOrderHeader = new HashSet<PurchaseOrderHeader>();
        }

        public int BusinessEntityID { get; set; }
        public string NationalIDNumber { get; set; }
        public string LoginID { get; set; }
        public short? OrganizationLevel { get; set; }
        public string JobTitle { get; set; }
        public DateTime BirthDate { get; set; }
        public string MaritalStatus { get; set; }
        public string Gender { get; set; }
        public DateTime HireDate { get; set; }
        public bool SalariedFlag { get; set; }
        public short VacationHours { get; set; }
        public short SickLeaveHours { get; set; }
        public bool CurrentFlag { get; set; }
        public Guid rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual ICollection<EmployeeDepartmentHistory> EmployeeDepartmentHistory { get; set; }
        public virtual ICollection<EmployeePayHistory> EmployeePayHistory { get; set; }
        public virtual ICollection<JobCandidate> JobCandidate { get; set; }
        public virtual ICollection<PurchaseOrderHeader> PurchaseOrderHeader { get; set; }
        public virtual SalesPerson SalesPerson { get; set; }
        public virtual Person BusinessEntity { get; set; }
    }
}
