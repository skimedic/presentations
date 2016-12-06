using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoLotDAL.Models
{
	[Table("Inventory")]
	public partial class Inventory:EntityBase
	{
		[Key]
		public int CarId { get; set; }

		[StringLength(50)]
		public string Make { get; set; }

		[StringLength(50)]
		public string Color { get; set; }

		[StringLength(50)]
		public string PetName { get; set; }

        public virtual ICollection<Order> Orders { get; set; } = new HashSet<Order>();
	}
}
