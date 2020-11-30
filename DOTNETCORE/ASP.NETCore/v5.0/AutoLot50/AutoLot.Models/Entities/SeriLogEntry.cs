using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace AutoLot.Models.Entities
{
    [Table("SeriLogs", Schema = "Logging")]
    public class SeriLogEntry
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string? Message { get; set; }

        public string? MessageTemplate { get; set; }

        [MaxLength(128)]
        public string? Level { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? TimeStamp { get; set; }

        public string? Exception { get; set; }

        public string? Properties { get; set; }

        public string? LogEvent { get; set; }
        public string? SourceContext { get; set; }
        public string? RequestPath { get; set; }
        public string? ActionName { get; set; }

        public string? ApplicationName { get; set; }
        public string? MachineName { get; set; }

        public string? FilePath { get; set; }

        public string? MemberName { get; set; }

        public int? LineNumber { get; set; }

        [NotMapped]
        public XElement? PropertiesXml => (Properties != null)? XElement.Parse(Properties):null;
    }
}
