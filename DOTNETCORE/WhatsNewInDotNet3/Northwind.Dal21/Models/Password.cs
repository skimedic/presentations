using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Northwind.Dal21.Models
{
    [Table("Password", Schema = "Person")]
    public partial class Password
    {
        [Key]
        [Column("BusinessEntityID")]
        public int BusinessEntityId { get; set; }
        [Required]
        [StringLength(128)]
        public string PasswordHash { get; set; }
        [Required]
        [StringLength(10)]
        public string PasswordSalt { get; set; }
        [Column("rowguid")]
        public Guid Rowguid { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }

        [ForeignKey("BusinessEntityId")]
        [InverseProperty("Password")]
        public Person BusinessEntity { get; set; }
    }
}
