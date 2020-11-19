using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoLot.Dal.test.Models
{
    public partial class CustomerOrderView
    {
        [StringLength(50)]
        public string FirstName { get; set; }
        [StringLength(50)]
        public string LastName { get; set; }
        [Required]
        [StringLength(50)]
        public string Color { get; set; }
        [Required]
        [StringLength(50)]
        public string PetName { get; set; }
        [Required]
        [StringLength(50)]
        public string Make { get; set; }
    }
}
