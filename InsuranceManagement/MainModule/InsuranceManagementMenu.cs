using InsuranceManagement.Exceptions;
using InsuranceManagement.Model;
using InsuranceManagement.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceManagement.MainModule
{
    internal class InsuranceManagementMenu
    {
        readonly IPolicyService _PolicyService;
        readonly UserInput _userInput;
        readonly PolicyNotFoundException _policyNotFoundException;
        public InsuranceManagementMenu()
        {
            _PolicyService = new PolicyServiceIMPL();
            _userInput = new UserInput();
            _policyNotFoundException = new PolicyNotFoundException("Policy Not Found!!");
        }

        public void run()
        {
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("Welcome to the Insurance Management System");
                Console.WriteLine("Please select an option:");
                Console.WriteLine("1. Create a Policy");
                Console.WriteLine("2. Get the Policy by its ID");
                Console.WriteLine("3. Get all the Policies available");
                Console.WriteLine("4. Update a Policy");
                Console.WriteLine("5. Delete a Policy");
                //Console.WriteLine("6. Claim a Policy");

                Console.WriteLine("0. Exit");
                Console.Write("Enter your choice: ");

                int input = int.Parse(Console.ReadLine());
                {
                    switch (input)
                    {
                        case 1:
                            Policy policy = _userInput.PolicyInput();
                           
                            
                                bool result1 = _PolicyService.createPolicy(policy);
                            if (result1)
                            {
                                Console.WriteLine("Policy created successfully.");
                            }
                            else
                            {
                                Console.WriteLine("Policy Not created");
                            }
                            break; 


                        case 2:
                            int PolicyID = _userInput.PolicyIDInput();
                            try
                            {
                                List<Policy> p2 = _PolicyService.getPolicybyID(PolicyID);
                                foreach (Policy p in p2)
                                {
                                    Console.WriteLine(p.ToString());
                                }
                            }
                            catch (PolicyNotFoundException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }

                            break;

                        case 3:
                            
                                List<Policy> allPolicies = _PolicyService.getAllPolicies();
                                foreach (Policy p in allPolicies)
                                {
                                    Console.WriteLine(p.ToString());
                                }
                            
                            
                            break;
                        case 4:
                            Policy policy3 = _userInput.PolicyInput();
                            try
                            {
                                bool result2 = _PolicyService.updatePolicy(policy3);
                                if (result2)
                                {
                                    Console.WriteLine("Policy updated successfully.");
                                }
                            }
                            catch (PolicyNotFoundException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            break;
                        case 5:
                            int policyID = _userInput.PolicyIDInput();
                            try
                            {
                                bool result3 = _PolicyService.deletePolicy(policyID);

                                if (result3)
                                {
                                    Console.WriteLine("Policy deleted successfully.");
                                }
                            }catch (PolicyNotFoundException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }


                            
                            break;

                            //case 6:
                            //Policy policy4 = _userInput.PolicyInput();
                            //bool result4 = _PolicyService.claimPolicy(policy4);
                            //if (result4)
                            //{
                            //    Console.WriteLine("Policy Claimed successfully.");
                            //}
                            //else
                            //{
                            //    Console.WriteLine("failed to Claim the Policy.");
                            //}
                            //break;
                    }

                }
            }
        }
    }
}