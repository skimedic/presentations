using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace AutoLot.Dal.Models.Entities.Owned
{
    [Owned]
    public class Person
    {
        [StringLength(50)] public string FirstName { get; set; }
        [StringLength(50)] public string LastName { get; set; }
    }
}