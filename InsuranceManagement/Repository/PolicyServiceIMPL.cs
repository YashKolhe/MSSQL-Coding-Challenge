using InsuranceManagement.Exceptions;
using InsuranceManagement.Model;
using InsuranceManagement.Utility;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceManagement.Repository
{
    internal class PolicyServiceIMPL:IPolicyService
    {
        SqlConnection sqlConnection = null;
        SqlCommand cmd = null;
        public PolicyServiceIMPL() 
        {
            sqlConnection = new SqlConnection(DbConnUtil.GetConnString());
            cmd = new SqlCommand();
        }
        public bool createPolicy(Policy policy)
        {
            using (SqlConnection sqlConnection = new SqlConnection(DbConnUtil.GetConnString())) ;
            {
                cmd.CommandText = "Insert Into Policy values(@PolicyID,@Policy,@PolicyAmount)";
                cmd.Parameters.AddWithValue("@PolicyID", policy.PolicyID);
                cmd.Parameters.AddWithValue("@Policy", policy.PolicyName);
                cmd.Parameters.AddWithValue("@PolicyAmount", policy.PolicyAmount);
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                int createPolicyStatus = cmd.ExecuteNonQuery();
                sqlConnection.Close();
                if (createPolicyStatus > 0)
                {
                    Console.WriteLine("Creating the Policy...");
                }
                
                return createPolicyStatus > 0;
            }
        }
        public List<Policy> getPolicybyID(int policyID)
        {
            List<Policy> P_list = new List<Policy>();
            using (SqlConnection sqlConnection = new SqlConnection(DbConnUtil.GetConnString())) ;
            {
                cmd.CommandText = "Select * from Policy where PolicyID = @policyID";
                cmd.Parameters.AddWithValue("@policyID", policyID);
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Policy policyByID = new Policy();
                    policyByID.PolicyID = (int)reader["PolicyID"];
                    policyByID.PolicyName = (string)reader["Policy"];
                    policyByID.PolicyAmount = (decimal)reader["PolicyAmount"];

                    P_list.Add(policyByID);
                }

                sqlConnection.Close();
            }

            return P_list;
        }
        public List<Policy> getAllPolicies()
        {
            List<Policy> PolicyList = new List<Policy>();
            using (SqlConnection sqlConnection = new SqlConnection(DbConnUtil.GetConnString())) ;

            {
                cmd.CommandText = "select * from Policy";
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Policy p1 = new Policy();
                    p1.PolicyID = (int)reader["PolicyID"];
                    p1.PolicyName = (string)reader["Policy"];
                    p1.PolicyAmount = (decimal)reader["PolicyAmount"];

                    PolicyList.Add(p1);
                }
                sqlConnection.Close();
                //foreach (Policy item in PolicyList)
                //{
                //    Console.WriteLine(item);
                //}
                return PolicyList;
            }
        }
        public bool updatePolicy(Policy policy)
        {
            using (SqlConnection sqlConnection = new SqlConnection(DbConnUtil.GetConnString())) ;
            
                {
                    cmd.CommandText = "UPDATE Policy SET Policy = @Policy, PolicyAmount = @PolicyAmount WHERE PolicyID = @PolicyID";
                    cmd.Parameters.AddWithValue("@Policy", policy.PolicyName);
                    cmd.Parameters.AddWithValue("@PolicyAmount", policy.PolicyAmount);
                    cmd.Parameters.AddWithValue("@PolicyID", policy.PolicyID);

                    sqlConnection.Open();
                    int policyUpdated = cmd.ExecuteNonQuery();
                sqlConnection.Close();

                if (policyUpdated > 0)
                    {
                        Console.WriteLine("Policy updated successfully.");
                    }
                if (policyUpdated == 0)
                {
                    throw new PolicyNotFoundException($"Policy with ID not found.");
                }
                return policyUpdated > 0;

            }

        }

        public bool deletePolicy(int policyID)
        {
            using (SqlConnection sqlConnection = new SqlConnection(DbConnUtil.GetConnString())) ;
            {
                cmd.CommandText = "Delete from Policy where PolicyID = @policyID";
                cmd.Parameters.AddWithValue("@PolicyID", policyID);
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                int deletePolicyStatus = cmd.ExecuteNonQuery();
                sqlConnection.Close();

                if (deletePolicyStatus == 0)
                {
                    throw new PolicyNotFoundException($"Policy with ID {policyID} not found.");
                }
                return deletePolicyStatus > 0;
            }
        }
        //public bool claimPolicy(Policy policy)
        //{

        //}



    }
}
