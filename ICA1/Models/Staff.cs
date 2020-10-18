using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace assesment1.Models
{
    [Table("staff_tbl")]
    public class Staff

    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string StaffNO { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Position { get; set; }

        [Column(TypeName = "Date")]
        public DateTime DOB { get; set; }
        public double Salary { get; set; }

        [ForeignKey("branch")]
        public string BranchNoRef { get; set; }
        public virtual Branch branch { get; set; }


    }
}