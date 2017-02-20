using System;

namespace Performance.EFCore.Models
{
    public partial class SalesTaxRate
    {
        public int SalesTaxRateID { get; set; }
        public int StateProvinceID { get; set; }
        public byte TaxType { get; set; }
        public decimal TaxRate { get; set; }
        public string Name { get; set; }
        public Guid rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual StateProvince StateProvince { get; set; }
    }
}
