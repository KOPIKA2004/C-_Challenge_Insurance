using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Entity
{
    public  class Claim
    {
       
       [Key] public int ClaimtId {  get; set; }

        public string ClaimName { get; set; }
        public DateTime DateField { get; set; }
        public decimal ClaimAmount { get; set; }
        public string Status { get; set; }
     
        public int?  ClientId { get; set; }
        public int? PolicyId { get; set; }
        [ForeignKey("PolicyId")]
        public virtual Policy Policy { get; set; }
        [ForeignKey("ClientId")]
        public virtual Client Client { get; set; }
    }
}
