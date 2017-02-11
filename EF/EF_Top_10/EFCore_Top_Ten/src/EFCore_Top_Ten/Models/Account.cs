#region copyright
// // Copyright Information
// // ==============================
// // EFCore_Top_Ten - Account.cs
// // All samples copyright Philip Japikse 
// // http://www.skimedic.com 2016/08/10
// // See License.txt for more information
// // ==============================
#endregion
using System;
using System.Collections.Generic;

namespace EFCore_Top_Ten.Models
{
    public class Account : EntityBase
    {
        public string AccountNumber { get; set; }
        public Double Balance { get; set; }

        public ICollection<AccountTransaction> XFers { get; set; }
    }
}

