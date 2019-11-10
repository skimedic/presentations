using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Northwind.Dal21.Models
{
    public partial class ErrorLog
    {
        [Column("ErrorLogID")]
        public int ErrorLogId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ErrorTime { get; set; }
        public int ErrorNumber { get; set; }
        public int? ErrorSeverity { get; set; }
        public int? ErrorState { get; set; }
        [StringLength(126)]
        public string ErrorProcedure { get; set; }
        public int? ErrorLine { get; set; }
        [Required]
        [StringLength(4000)]
        public string ErrorMessage { get; set; }
    }
}
