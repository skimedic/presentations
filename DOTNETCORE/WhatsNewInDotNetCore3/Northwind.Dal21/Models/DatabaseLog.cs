using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Northwind.Dal21.Models
{
    public partial class DatabaseLog
    {
        [Column("DatabaseLogID")]
        public int DatabaseLogId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime PostTime { get; set; }
        [Required]
        [Column("TSQL")]
        public string Tsql { get; set; }
        [Required]
        [Column(TypeName = "xml")]
        public string XmlEvent { get; set; }
    }
}
