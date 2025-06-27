using Insurance.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.DAO
{
    public interface IPolicyService
    {
        bool CreatePolicy(Policy policy);
        Policy GetPolicy(int policyId);
        ICollection<Policy> GetAllPolicies();
        bool UpdatePolicy(Policy policy);
        bool DeletePolicy(int policyId);
    }
}
