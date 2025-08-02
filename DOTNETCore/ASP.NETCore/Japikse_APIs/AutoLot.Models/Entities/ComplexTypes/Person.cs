// Copyright Information
// ==================================
// AutoLot8 - AutoLot.Models - Person.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2024/06/29
// ==================================

namespace AutoLot.Models.Entities.ComplexTypes;

[ComplexType]
public class Person
{
    [Required, StringLength(50)]
    public string FirstName { get; set; }

    [Required, StringLength(50)]
    public string LastName { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public string FullName { get; set; }
}
