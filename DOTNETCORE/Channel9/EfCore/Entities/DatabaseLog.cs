// Copyright Information
// ==================================
// Channel9 - EfCore - DatabaseLog.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2020/04/10
// See License.txt for more information
// ==================================

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EfCore.Entities
{
    public partial class DatabaseLog
    {
        [Key] [Column("DatabaseLogID")] public int DatabaseLogId { get; set; }

        [Column(TypeName = "datetime")] public DateTime PostTime { get; set; }

        [Required] [StringLength(128)] public string DatabaseUser { get; set; }

        [Required] [StringLength(128)] public string Event { get; set; }

        [StringLength(128)] public string Schema { get; set; }

        [StringLength(128)] public string Object { get; set; }

        [Required] [Column("TSQL")] public string Tsql { get; set; }

        [Required] [Column(TypeName = "xml")] public string XmlEvent { get; set; }
    }
}