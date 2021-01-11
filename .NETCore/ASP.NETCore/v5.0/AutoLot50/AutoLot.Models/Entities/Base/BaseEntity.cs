using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoLot.Models.Entities.Base
{
    public abstract class BaseEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Timestamp] public byte[]? TimeStamp { get; set; }
    }
}
