using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PerformanceEf6.Models;

[Table("Production.ProductCostHistory")]
public partial class ProductCostHistory
{
    [Key]
    [Column(Order = 0)]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int ProductID { get; set; }

    [Key]
    [Column(Order = 1)]
    public DateTime StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    [Column(TypeName = "money")]
    public decimal StandardCost { get; set; }

    public DateTime ModifiedDate { get; set; }

    public virtual Product Product { get; set; }
}