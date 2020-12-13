// Copyright Information
// ==================================
// EntityFrameworkCore - EfCoreBasics - VJobCandidateEducation.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2020/04/08
// See License.txt for more information
// ==================================

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EfCoreBasics.Entities
{
    public partial class VJobCandidateEducation
    {
        [Column("JobCandidateID")] public int JobCandidateId { get; set; }

        [Column("Edu.Level")] public string EduLevel { get; set; }

        [Column("Edu.StartDate", TypeName = "datetime")]
        public DateTime? EduStartDate { get; set; }

        [Column("Edu.EndDate", TypeName = "datetime")]
        public DateTime? EduEndDate { get; set; }

        [Column("Edu.Degree")]
        [StringLength(50)]
        public string EduDegree { get; set; }

        [Column("Edu.Major")]
        [StringLength(50)]
        public string EduMajor { get; set; }

        [Column("Edu.Minor")]
        [StringLength(50)]
        public string EduMinor { get; set; }

        [Column("Edu.GPA")] [StringLength(5)] public string EduGpa { get; set; }

        [Column("Edu.GPAScale")]
        [StringLength(5)]
        public string EduGpascale { get; set; }

        [Column("Edu.School")]
        [StringLength(100)]
        public string EduSchool { get; set; }

        [Column("Edu.Loc.CountryRegion")]
        [StringLength(100)]
        public string EduLocCountryRegion { get; set; }

        [Column("Edu.Loc.State")]
        [StringLength(100)]
        public string EduLocState { get; set; }

        [Column("Edu.Loc.City")]
        [StringLength(100)]
        public string EduLocCity { get; set; }
    }
}