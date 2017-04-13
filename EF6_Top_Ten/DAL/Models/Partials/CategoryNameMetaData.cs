#region copyright
// // Copyright Information
// // ==============================
// // DAL - CategoryNameMetaData.cs
// // All samples copyright Philip Japikse 
// // http://www.skimedic.com 2016/08/10
// // See License.txt for more information
// // ==============================
#endregion
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class CategoryNameMetaData
    {
        [Display(Name = "Category Name")]
        public string CategoryName;

    }
}
