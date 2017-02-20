using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Performance.EF6.Models
{
    [Table("Production.ProductPhoto")]
    public partial class ProductPhoto
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProductPhoto()
        {
            ProductProductPhotoes = new HashSet<ProductProductPhoto>();
        }

        public int ProductPhotoID { get; set; }

        public byte[] ThumbNailPhoto { get; set; }

        [StringLength(50)]
        public string ThumbnailPhotoFileName { get; set; }

        public byte[] LargePhoto { get; set; }

        [StringLength(50)]
        public string LargePhotoFileName { get; set; }

        public DateTime ModifiedDate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductProductPhoto> ProductProductPhotoes { get; set; }
    }
}
