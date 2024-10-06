using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceManagement.Model
{
    internal class Payment
    {
        private int paymentID;
        public int PaymentID
        {
            get { return paymentID; }
            set { paymentID = value; }
        }
        private DateTime paymentDate;
        public DateTime PaymentDate
        {
            get { return paymentDate; }
            set { paymentDate = value; }
        }
        private Decimal paymentAmount;
        public Decimal PaymentAmount
        {
            get { return paymentAmount; }
            set { paymentAmount = value; }
        }
        private int clientID;
        public int ClientID
        {
            get { return clientID; }
            set { clientID = value; }
        }

        public Payment()
        {

        }

        public Payment(int PaymentID, DateTime PaymentDate, Decimal PaymentAmount, int ClientID)
        {
            this.paymentID = PaymentID;
            this.paymentDate = PaymentDate;
            this.paymentAmount = PaymentAmount;
            this.clientID = ClientID;

        }

        public override string ToString()
        {
            return $"Payment ID : {paymentID}\t Payment Date : {paymentDate}\t Payment Amount : {paymentAmount}\t Client ID : {clientID}";
        }

    }
}
