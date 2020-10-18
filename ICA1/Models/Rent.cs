using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace assesment1.Models
{
    [Table("Rent_tbl")]
    public class Rent
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string PropertyNO { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Ptype { get; set; }
        public int Rooms { get; set; }

        [ForeignKey("owner")]
        public string RefOwnerNo { get; set; }
        public virtual Owner owner  { get; set; }
        

        [ForeignKey("staff")]
        public string RefStaffNo { get; set; }
        public virtual Staff staff { get; set; }

        [ForeignKey("branch")]
        public string RefBranchNo { get; set; }
        public virtual Branch branch { get; set; }

        public string rent1 { get; set; }

        int num = 5;




    }
}