// Copyright Information
// ==================================
// Channel9 - EfCore - AwbuildVersion.cs
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
    [Table("AWBuildVersion")]
    public partial class AwbuildVersion
    {
        [Key] [Column("SystemInformationID")] public byte SystemInformationId { get; set; }

        [Required]
        [Column("Database Version")]
        [StringLength(25)]
        public string DatabaseVersion { get; set; }

        [Column(TypeName = "datetime")] public DateTime VersionDate { get; set; }

        [Column(TypeName = "datetime")] public DateTime ModifiedDate { get; set; }
    }
}