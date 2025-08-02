﻿// Copyright Information
// ==================================
// AutoLot70 - AutoLot.Models - SeriLogEntry.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2023/07/31
// ==================================

namespace AutoLot.Models.Entities;

[Table("SeriLogs", Schema = "Logging")]
[EntityTypeConfiguration(typeof(SeriLogEntryConfiguration))]
public class SeriLogEntry
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string Message { get; set; }
    public string MessageTemplate { get; set; }

    [MaxLength(128)]
    public string Level { get; set; }

    [DataType(DataType.DateTime)]
    public DateTime TimeStamp { get; set; }

    public string Exception { get; set; }
    public string Properties { get; set; }
    public string LogEvent { get; set; }
    public string SourceContext { get; set; }
    public string RequestPath { get; set; }
    public string ActionName { get; set; }
    public string ApplicationName { get; set; }
    public string MachineName { get; set; }
    public string FilePath { get; set; }
    public string MemberName { get; set; }
    public int LineNumber { get; set; }

    [NotMapped]
    public XElement PropertiesXml => (Properties != null) ? XElement.Parse(Properties) : null;
}