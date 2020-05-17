using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AutoLot.Dal.Models.Entities.Base;

namespace AutoLot.Dal.Models.Entities
{
    [Table("Makes", Schema = "dbo")]
    public partial class Make : BaseEntity
    {
        [StringLength(50)]
        public string Name { get; set; }

        [InverseProperty(nameof(Car.MakeNavigation))]
        public IEnumerable<Car> Cars { get; set; } = new List<Car>();

    }
}