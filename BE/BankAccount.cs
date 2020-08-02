using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
    public class BankAccount
    {
        public string BankName { get; set; }
        public int BranchNumber { get; set; }
        public string BranchAddress { get; set; }
        public string BranchCity { get; set; }
       // public int BankAccountNumber { get; set; }
       
        public override string ToString()
        {
            return string.Format("Bank Name: {0}\n", BankName) +
              string.Format(" Branch Number: {0}\n", BranchNumber) +
              string.Format("Branch Address: {0}\n", BranchAddress) +
             // string.Format("Bank Account Number: {0}\n", BankAccountNumber) +
              string.Format("Bank number: {0}\n", Banknumber) +
              string.Format("Branch City: {0}\n", BranchCity);
        }
        public int Banknumber;
        public BankAccount()
        {
            Banknumber = ++Configuration.BankNumber;

        }
        public BankAccount(string b,int bn,string ba,string bc,int bankn)
        {
            BankName =b;
            BranchNumber=bn;
            BranchAddress= ba;
            BranchCity= bc;
            Banknumber=bankn;
        }
    }
}
