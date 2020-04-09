// Copyright Information
// ==================================
// EntityFrameworkCore - EfCoreBasics - ErrorLog.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2020/04/08
// See License.txt for more information
// ==================================

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EfCoreBasics.Entities
{
    public partial class ErrorLog
    {
        [Key] [Column("ErrorLogID")] public int ErrorLogId { get; set; }

        [Column(TypeName = "datetime")] public DateTime ErrorTime { get; set; }

        [Required] [StringLength(128)] public string UserName { get; set; }

        public int ErrorNumber { get; set; }
        public int? ErrorSeverity { get; set; }
        public int? ErrorState { get; set; }

        [StringLength(126)] public string ErrorProcedure { get; set; }

        public int? ErrorLine { get; set; }

        [Required] [StringLength(4000)] public string ErrorMessage { get; set; }
    }
}