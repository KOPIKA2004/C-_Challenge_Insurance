using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Authentication.ExtendedProtection;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Entity
{
    public  class Client
    {
        [Key] public int ClientId { get; set; }
        public string ClientName { get; set; }
        public string ContactInfo {  get; set; }
        public int? PolicyId { get; set; }
        [ForeignKey("PolicyId")]
        public virtual Policy Policy { get; set; }
    }
}
