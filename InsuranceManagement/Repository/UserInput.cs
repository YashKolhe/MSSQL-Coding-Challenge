using InsuranceManagement.Exceptions;
using InsuranceManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceManagement.Repository
{
    internal class UserInput
    {
        public Policy PolicyInput()
        {
            Policy policy = new Policy();

            Console.WriteLine("Enter The Id of the Policy :");
            policy.PolicyID = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the Name of the Policy:");
            policy.PolicyName = Console.ReadLine();

            Console.WriteLine("Enter the Amount of Policy:");
            policy.PolicyAmount = decimal.Parse(Console.ReadLine());

            return policy;
        }

        public int PolicyIDInput()
        {
            int PolicyID;

            Console.WriteLine("Enter the ID of the Policy ");
            PolicyID = int.Parse(Console.ReadLine());
            return PolicyID;


        }
       











    }
}
