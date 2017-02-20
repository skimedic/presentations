using System;

namespace Performance.EFCore.Models
{
    public partial class ProductModelIllustration
    {
        public int ProductModelID { get; set; }
        public int IllustrationID { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual Illustration Illustration { get; set; }
        public virtual ProductModel ProductModel { get; set; }
    }
}
