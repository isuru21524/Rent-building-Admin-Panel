using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace assesment1.Models
{
    [Table("Owner_tbl")]
    public class Owner
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string OwnerNo { get; set; }
        public string Fname { get; set; }
        public string Lname{ get; set; }
        public String Address { get; set; }
        public string TelNo { get; set; }

        public List<Rent> rent { get; set; }
    }
}