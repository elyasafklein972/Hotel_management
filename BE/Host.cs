using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
    public class Host
    {
        //properties
        //HostKey static int
        public string PrivateName { get; set; }
        public string FamilyName { get; set; }
        public int FhoneNumber { get; set; }
        public string MailAddress { get; set; }
        public BankAccount BankAccount{ get; set;}
        public bool CollectionClearance { get; set; }
        public int numHostingUnit { get; set; }//num of hosting unit 
        public override string ToString()
        {
         
            return string.Format("Host key: {0}\n", Hostkey) +
                string.Format("Private Name: {0}\n", PrivateName) +
                string.Format("Family Name: {0}\n", FamilyName) +
                string.Format("Fhone Number: {0}\n", FhoneNumber) +
                string.Format("Mail Address: {0}\n", MailAddress) +
                string.Format("Bank Account: {0}\n", BankAccount.BankName) +
                string.Format("Collection Clearance: {0}\n", CollectionClearance) ;
        
    }
        public Host GetCopy()
        {
            return (Host)this.MemberwiseClone();
        }
        public int Hostkey { get; set; }
        public Host()
        {
            numHostingUnit = 1;
            Hostkey = ++Configuration.HostKey;
        }
    };
}
