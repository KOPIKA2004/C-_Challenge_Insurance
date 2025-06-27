using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Entity
{
    public class Payment
    {
        [Key] public int PaymentId { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal PaymentAmount { get; set; }
        public int? ClientId { get; set; }
        [ForeignKey("ClientId")]
        public virtual  Client Client { get; set; }
    }
}
