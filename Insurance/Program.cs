using Insurance.DAO;
using Insurance.Entity;
using Insurance.MyExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance
{
    public class Program
    {
        static void Main(string[] args)
        {
            InsuranceServiceImpl service = new InsuranceServiceImpl();
            while (true)
            {
                Console.WriteLine("~~~Insurance Policy~~~");
                Console.WriteLine("1. Create Policy");
                Console.WriteLine("2. View Policy by ID");
                Console.WriteLine("3. View All Policies");
                Console.WriteLine("4. Update Policy");
                Console.WriteLine("5. Delete Policy");
                Console.WriteLine("6. Get the count of total policies: ");
                Console.WriteLine("7. Exit");
                Console.WriteLine("Enter your choice: ");
                var input = Console.ReadLine();
                if (!int.TryParse(input, out var value))
                {
                    Console.WriteLine("Invalid input");
                    continue;
                }
                switch (input)
                {
                    case "1":
                        Console.WriteLine("Enter Policy Name: ");
                        string name = Console.ReadLine();
                        Console.WriteLine("Enter Description: ");
                        string desc = Console.ReadLine();
                        Policy policy = new Policy { PolicyName = name, Description = desc };
                        bool created = service.CreatePolicy(policy);
                        Console.WriteLine(created ? "Policy Created" : "Policy Not Created");
                        break;
                    case "2":
                        Console.WriteLine("Enter Policy ID: ");
                        if (int.TryParse(Console.ReadLine(), out int pid))
                        {
                            Policy p = service.GetPolicy(value);
                            if (p != null)
                                Console.WriteLine($"ID: {p.PolicyId}, Name: {p.PolicyName}, Description: {p.Description}");
                            else
                                Console.WriteLine("Policy Id not found");
                        }
                        break;
                    case "3":
                        ICollection<Policy> policies=service.GetAllPolicies();
                        if (policies.Count == 0)
                        {
                            Console.WriteLine("No Policy Found");
                        }
                        else
                        {
                            Console.WriteLine("All Policies");
                            foreach (Policy p in policies)
                            {
                                Console.WriteLine($"ID: {p.PolicyId}, Name: {p.PolicyName}, Description: {p.Description}");
                            }
                        }
                        break;
                    case "4":
                        try 
                        {
                            int id;
                            while (true)
                            {
                                Console.Write("Enter Policy ID to update: ");
                                string updateinput = Console.ReadLine();
                                if (int.TryParse(updateinput, out id))
                                    break;
                                Console.WriteLine("[Error] Invalid input. Please enter numeric ID.");
                            }
                                                        Policy existingPolicy = service.GetPolicy(id); // this might throw PolicyNotFoundException

                            Console.Write("Enter new Policy Name: ");
                            string policyname = Console.ReadLine();
                            Console.Write("Enter new Description: ");
                            string description = Console.ReadLine();

                            existingPolicy.PolicyName = policyname;
                            existingPolicy.Description = description;

                            bool updated = service.UpdatePolicy(existingPolicy);
                            Console.WriteLine(updated ? "Policy updated successfully." : "Update failed.");
                        }
                        catch (PolicyNotFoundException ex)
                        {
                            Console.WriteLine($"[Error] {ex.Message}");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"[Unexpected Error] {ex.Message}");
                        }
                        break;
                      
                    case "5":
                        Console.WriteLine("Enter Policy Id to delete: ");
                        if (int.TryParse(Console.ReadLine(), out int iddel))
                        {
                            try
                            {
                                bool delete = service.DeletePolicy(iddel);  
                                Console.WriteLine(delete ? "Policy deleted successfully." : "Failed to delete.");
                            }
                            catch (PolicyNotFoundException ex)
                            {
                                Console.WriteLine($"[Error] {ex.Message}");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"[Unexpected Error] {ex.Message}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("[Error] Invalid ID. Please enter a numeric value.");
                        }
                        break;
                    case "6":
                        int total = service.GetPolicyCountAdoNet();
                        Console.WriteLine($"total policies:{total} ");
                        break;
                    case "7":
                        Console.WriteLine("Thank you for using Insurance page");
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
}