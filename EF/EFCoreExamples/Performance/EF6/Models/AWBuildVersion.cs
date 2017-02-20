using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Performance.EF6.Models
{
    [Table("AWBuildVersion")]
    public partial class AWBuildVersion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte SystemInformationID { get; set; }

        [Column("Database Version")]
        [Required]
        [StringLength(25)]
        public string Database_Version { get; set; }

        public DateTime VersionDate { get; set; }

        public DateTime ModifiedDate { get; set; }
    }
}
