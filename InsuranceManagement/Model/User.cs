using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceManagement.Model
{
    internal class User
    {
        private int userID;
        public int UserID
        {
            get { return userID; }
            set { userID = value; }
        }

        private string userName;
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        private string password;
        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        private string role;
        public string Role
        {
            get { return role; }
            set { role = value; }
        }

        public User() { }
        public User(int UserID, string UserName, string Password, string Role)
        {
            this.userID = UserID;
            this.userName = UserName;
            this.password = Password;
            this.role = Role;
        }
        public override string ToString()
        {
            return $"User ID : {userID}\t User Name : {userName}\t Password : {password}\t Role : {role}";
        }
    }
}
