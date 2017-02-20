using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Performance.EF6.Models
{
    [Table("Sales.PersonCreditCard")]
    public partial class PersonCreditCard
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BusinessEntityID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CreditCardID { get; set; }

        public DateTime ModifiedDate { get; set; }

        public virtual Person Person { get; set; }

        public virtual CreditCard CreditCard { get; set; }
    }
}
