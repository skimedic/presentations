#region copyright
// // Copyright Information
// // ==============================
// // EFCore_Top_Ten - ProductPhoto.cs
// // All samples copyright Philip Japikse 
// // http://www.skimedic.com 2016/08/10
// // See License.txt for more information
// // ==============================
#endregion
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore_Top_Ten.Models
{
	public class ProductPhoto: EntityBase
	{
		[Key,ForeignKey("ProductParent")]
		public new int Id { get; set; }
		public byte[] Image { get; set; }

		[Required,InverseProperty("Image")]
		public virtual Product ProductParent { get; set; }
	}
}