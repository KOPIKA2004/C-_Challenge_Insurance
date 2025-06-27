using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.MyExceptions
{
    public class PolicyNotFoundException : Exception
    {
        public PolicyNotFoundException() : base("Policy Not Found") { }

        public PolicyNotFoundException(string message) : base(message) { }

        public PolicyNotFoundException(string message,Exception inner): base(message, inner) { }
            
        
    }
}
