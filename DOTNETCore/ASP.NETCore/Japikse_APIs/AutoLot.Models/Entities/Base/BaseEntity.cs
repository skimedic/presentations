// Copyright Information
// ==================================
// AutoLot8 - AutoLot.Models - BaseEntity.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2024/2/4
// ==================================

namespace AutoLot.Models.Entities.Base;

public abstract class BaseEntity
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Timestamp]
    public long TimeStamp { get; set; }
}