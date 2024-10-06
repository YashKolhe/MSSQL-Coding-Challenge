using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceManagement.Model
{
    internal class Client
    {
        private int clientID;
        public int ClientID
        {
            get { return clientID; }
            set { clientID = value; }
        }
        private string clientName;
        public string ClientName
        {
            get { return clientName; }
            set { clientName = value; }
        }
        private string contactNumber;
        public string ContactNumber
        {
            get { return contactNumber; }
            set { contactNumber = value; }
        }
        private string policy;
        public string Policy
        {
            get { return policy; }
            set { policy = value; }
        }
        public Client() { }
        public Client(int ClientID, string ClientName, string ContactNumber, string Policy)
        {
            this.clientID = ClientID;
            this.clientName = ClientName;
            this.contactNumber = ContactNumber;
            this.policy = Policy;
        }
        public override string ToString()
        {
            return $"Client ID : {clientID}\t Client Name : {clientName}\t Contact Number : {contactNumber}\t Policy : {policy}";
        }

    }
}
