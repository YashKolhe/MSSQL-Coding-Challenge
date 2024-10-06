using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceManagement.Model
{
    internal class Policy
    {
        private int policyID;
        public int PolicyID
        {
            get { return policyID; }
            set { policyID = value; }
        }

        private string policyName;
        public string PolicyName
        {
            get { return policyName; }
            set { policyName = value; }
        }
        private decimal policyAmount;
        public decimal PolicyAmount
        {
            get { return policyAmount; }
            set { policyAmount = value; }
        }
        public Policy() { }
        public Policy(int PolicyID, string PolicyName, decimal PolicyAmount)
        {
            this.policyID = PolicyID;
            this.policyName = PolicyName;
            this.policyAmount = PolicyAmount;
        }
        public override string ToString()
        {
            return $"Policy ID : {policyID}\t Policy Name : {policyName}\t Policy Amount : {policyAmount}";
        }
    }
}
