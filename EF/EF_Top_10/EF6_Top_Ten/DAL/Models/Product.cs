#region copyright
// // Copyright Information
// // ==============================
// // DAL - Product.cs
// // All samples copyright Philip Japikse 
// // http://www.skimedic.com 2016/08/10
// // See License.txt for more information
// // ==============================
#endregion
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public partial class Product: EntityBase
    {

        [Required,Display(Name="Model Number"),StringLength(50)]
        public string ModelNumber { get; set; }

        [Required,Display(Name="Model Name"),StringLength(150)]
        public string ModelName { get; set; }

        [Required,Display(Name="Unit Cost")]
        [DataType(DataType.Currency)]
        public decimal UnitCost { get; set; }

        [Required,Display(Name="Current Price")]
        [DataType(DataType.Currency)]
        public decimal CurrentPrice { get; set; }

        //Cascade Delete is enabled since not nullable
        public int CategoryId { get; set; }

        [DataType(DataType.Text)]
        public string Description { get; set; }

        [DefaultValue(0),Display(Name="Units in Stock")]
        public int UnitsInStock { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

        public int? ProductPhotoId { get; set; }
        public virtual ProductPhoto Image { get;set; }
    }
}
