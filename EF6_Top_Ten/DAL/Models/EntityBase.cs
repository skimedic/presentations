#region copyright
// // Copyright Information
// // ==============================
// // DAL - EntityBase.cs
// // All samples copyright Philip Japikse 
// // http://www.skimedic.com 2016/08/10
// // See License.txt for more information
// // ==============================
#endregion
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public abstract class EntityBase 
    {
        //Both of these are optional - picked up by conventions
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public bool? IsChanged { get; set; }

        [Timestamp]
        public byte[] Timestamp { get; set; }
    }
}