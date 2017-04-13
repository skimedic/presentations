#region copyright
// // Copyright Information
// // ==============================
// // DAL - AccountTransaction.cs
// // All samples copyright Philip Japikse 
// // http://www.skimedic.com 2016/08/10
// // See License.txt for more information
// // ==============================
#endregion
using System;
using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public class AccountTransaction : EntityBase
    {
        //Of course, this is not a recommended way to program banking transactions!
        //Just done this way to illustrate EF transactions
        public int? AccountID { get; set; }
        public Account Account { get; set; }
        public Double Amount { get; set; }

        [Required]
        public DateTime TransactionDate { get; set; }
    }
}