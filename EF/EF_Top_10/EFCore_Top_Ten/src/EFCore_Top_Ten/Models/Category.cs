#region copyright
// // Copyright Information
// // ==============================
// // EFCore_Top_Ten - Category.cs
// // All samples copyright Philip Japikse 
// // http://www.skimedic.com 2016/08/10
// // See License.txt for more information
// // ==============================
#endregion
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore_Top_Ten.Models
{
	//[MetadataType(typeof(CategoryNameMetaData))]
	//public partial class Category
	//{
	//}

	[Table("Category")]
	public partial class Category : EntityBase
	{
		[StringLength(100)]
		public string CategoryName { get; set; }

		public virtual ICollection<Product> Products { get; set; }

		//Changes to show migrations
		public int? CategoryId { get; set; }
		[ForeignKey("CategoryId")]
		public virtual Category ParentCategory { get; set; }

		public virtual ICollection<Category> ChildCategories { get; set; } 

	}
}
