using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Performance.EF6.Models
{
    [Table("Person.BusinessEntity")]
    public partial class BusinessEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BusinessEntity()
        {
            BusinessEntityAddresses = new HashSet<BusinessEntityAddress>();
            BusinessEntityContacts = new HashSet<BusinessEntityContact>();
        }

        public int BusinessEntityID { get; set; }

        public Guid rowguid { get; set; }

        public DateTime ModifiedDate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BusinessEntityAddress> BusinessEntityAddresses { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BusinessEntityContact> BusinessEntityContacts { get; set; }

        public virtual Person Person { get; set; }

        public virtual Store Store { get; set; }

        public virtual Vendor Vendor { get; set; }
    }
}
