using System;
using System.Collections.Generic;

namespace PerformanceEf3.EFCore.Models
{
    public partial class PhoneNumberType
    {
        public PhoneNumberType()
        {
            PersonPhone = new HashSet<PersonPhone>();
        }

        public int PhoneNumberTypeID { get; set; }
        public string Name { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual ICollection<PersonPhone> PersonPhone { get; set; }
    }
}
