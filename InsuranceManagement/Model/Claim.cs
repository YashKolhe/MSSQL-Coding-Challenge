using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceManagement.Model
{
    internal class Claim
    {
        private int claimID;
        public int ClaimID
        {
            get { return claimID; }
            set { claimID = value; }
        }
        private int claimNumber;
        public int ClaimNumber
        {
            get { return claimNumber; }
            set { claimNumber = value; }
        }
        private DateTime dateFiled;
        public DateTime DateFiled
        {
            get { return dateFiled; }
            set { dateFiled = value; }
        }
        private decimal claimAmount;
        public decimal ClaimAmount
        {
            get { return claimAmount; }
            set { claimAmount = value; }
        }
        private string status;
        public string Status
        {
            get { return status; }
            set { status = value; }
        }
        private string policy;
        public string Policy
        {
            get { return policy; }
            set { policy = value; }
        }
        private int clientID;
        public int ClientID
        {
            get { return clientID; }
            set { clientID = value; }
        }
        public Claim() { }
        public Claim(int ClaimID, int ClaimNumber, DateTime DateFiled, decimal ClaimAmount, string Status, string Policy, int ClientID)
        {
            this.claimID = ClaimID;
            this.claimNumber = ClaimNumber;
            this.dateFiled = DateFiled;
                this.claimAmount = ClaimAmount;
            this.status = Status;
            this.policy = Policy;
            this.clientID = ClientID;
        }
        public override string ToString()
        {
            return $"Claim ID : {claimID}\t Claim Number : {claimNumber}\t Date when Claim was Filed : {dateFiled}\t Claim Amount : {claimAmount}\t Status of Claim : {status}\t Policy Name : {policy}\t Client ID : {clientID}";
        }

    }
}
