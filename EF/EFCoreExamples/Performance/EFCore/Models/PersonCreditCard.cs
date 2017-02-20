using System;

namespace Performance.EFCore.Models
{
    public partial class PersonCreditCard
    {
        public int BusinessEntityID { get; set; }
        public int CreditCardID { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual Person BusinessEntity { get; set; }
        public virtual CreditCard CreditCard { get; set; }
    }
}
