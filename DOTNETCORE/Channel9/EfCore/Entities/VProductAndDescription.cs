// Copyright Information
// ==================================
// Channel9 - EfCore - VProductAndDescription.cs
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
    public partial class VProductAndDescription
    {
        [Column("ProductID")] public int ProductId { get; set; }

        [Required] [StringLength(50)] public string Name { get; set; }

        [Required] [StringLength(50)] public string ProductModel { get; set; }

        [Required]
        [Column("CultureID")]
        [StringLength(6)]
        public string CultureId { get; set; }

        [Required] [StringLength(400)] public string Description { get; set; }
    }
}