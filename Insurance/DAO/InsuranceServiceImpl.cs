using Insurance.Entity;
using Insurance.MyExceptions;
using Insurance.Util;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Insurance.DAO 
{
    public class InsuranceServiceImpl : IPolicyService
    {
        public AppDbContext con=new AppDbContext();
       //to create policy
       public bool CreatePolicy(Policy policy)
        {
            con.Policies.Add(policy);
            return con.SaveChanges()>0;
        }
        // to get policy
        public Policy GetPolicy(int policyid)
        {
            var policy = con.Policies.Find(policyid);
            if (policy == null)
            {
                throw new PolicyNotFoundException("No Policy Found ");
            }
            return policy;
        }
        //to get all policies
        public ICollection<Policy> GetAllPolicies()
        {
            return con.Policies.ToList();
        }
        //to update policy
        public bool UpdatePolicy(Policy policy)
        {
            var existing = con.Policies.Find(policy.PolicyId);
            if (existing != null)
            {
                existing.PolicyName = policy.PolicyName;
                existing.Description = policy.Description;
                return con.SaveChanges() > 0;
            }
            return false;
        }
        // to delete 
        public bool DeletePolicy(int policyid)
        {
            var existing = con.Policies.Find(policyid);
            if (existing == null)
            {
                throw new PolicyNotFoundException("Policy ID is not found");
            }
            con.Policies.Remove(existing);
            return con.SaveChanges() > 0;
        } 
        // using ado.net
        public int GetPolicyCountAdoNet()
        {
            int count = 0;
            using (SqlConnection con = DBConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("select  count(*) from policies",con);
                con.Open();
                count = (int)cmd.ExecuteScalar();
            }
            return count;
        }
    }
}
