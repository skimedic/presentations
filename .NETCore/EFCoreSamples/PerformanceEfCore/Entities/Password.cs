using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PerformanceEfCore.Entities;

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

    [ForeignKey(nameof(BusinessEntityId))]
    [InverseProperty(nameof(Person.Password))]
    public virtual Person BusinessEntity { get; set; }
}