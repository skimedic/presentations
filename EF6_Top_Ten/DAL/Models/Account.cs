#region copyright
// // Copyright Information
// // ==============================
// // DAL - Account.cs
// // All samples copyright Philip Japikse 
// // http://www.skimedic.com 2016/08/10
// // See License.txt for more information
// // ==============================
#endregion
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace DAL.Models
{
    public class Account : EntityBase
    {
        public string AccountNumber { get; set; }
        public Double Balance { get; set; }

        public ICollection<AccountTransaction> XFers { get; set; }
    }
}

