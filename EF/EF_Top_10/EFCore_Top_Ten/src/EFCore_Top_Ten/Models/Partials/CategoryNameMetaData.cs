#region copyright
// // Copyright Information
// // ==============================
// // EFCore_Top_Ten - CategoryNameMetaData.cs
// // All samples copyright Philip Japikse 
// // http://www.skimedic.com 2016/08/10
// // See License.txt for more information
// // ==============================
#endregion
using System.ComponentModel.DataAnnotations;

namespace EFCore_Top_Ten.Models
{
    public class CategoryNameMetaData
    {
        [Display(Name = "Category Name")]
        public string CategoryName;

    }
}
