using InsuranceManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceManagement.Repository
{
    internal interface IPolicyService
    {
        public bool createPolicy(Policy policy);
        public List<Policy> getPolicybyID(int policyID);
        public List<Policy> getAllPolicies();
        public bool updatePolicy(Policy policy);
        public bool deletePolicy(int policyID);
        //public bool claimPolicy(Policy policy);

    }
}
