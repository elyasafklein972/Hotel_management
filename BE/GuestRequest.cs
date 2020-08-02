using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
    public class GuestRequest
    {
        //proprties
        public string PrivateName { get; set; }
        public string FamilyName { get; set; }
        public string MailAddress { get; set; }
        public bool Status { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime ReleaseDate { get; set; }
        public Type Type { get; set; }
        public Area Area { get; set; }
        public SubArea SubArea { get; set; }
        public int Adults { get; set; }
        public int children { get; set; }
        public StatusPool Pool { get; set; }
        public StatusJacuzzi Jacuzzi { get; set; }
        public StatusGarden Garden { get; set; }
        public StatusChildrensAttractions ChildrensAttractions { get; set; }
     
        public override string ToString()//to string writeLine
        {
            return string.Format("Guest request key: {0}\n", GuestRequestkey) +
                string.Format("Private Name: {0}\n", PrivateName) +
                string.Format("Family Name: {0}\n", FamilyName) +
                string.Format("Mail Address: {0}\n", MailAddress) +
                string.Format("Status: {0}\n", Status) +
                string.Format("Registration Date: {0}\n", RegistrationDate) +
                string.Format("Entry Date: {0}\n", EntryDate) +
                string.Format("Release Date: {0}\n", ReleaseDate) +
                string.Format("Type: {0}\n", Type) +
                string.Format("Area: {0}\n", Area) +
                string.Format("SubArea: {0}\n", SubArea) +
                string.Format("Adults: {0}\n", Adults) +
                string.Format("children: {0}\n", children) +
                string.Format("Pool: {0}\n", Pool) +
                string.Format("Jacuzzi: {0}\n", Jacuzzi) +
                string.Format("Garden: {0}\n", Garden) +
                string.Format("Childrens Attractions: {0}\n", ChildrensAttractions);
        }
        public GuestRequest GetCopy()
        {
            return (GuestRequest)this.MemberwiseClone();
        }
        public int GuestRequestkey { get; set; }



        public GuestRequest()
        {
            GuestRequestkey=++Configuration.GuestRequestKey;
           // EntryDate = DateTime.Today;
           // ReleaseDate = DateTime.Today;
            RegistrationDate = DateTime.Now;


        }
        public GuestRequest(int Key)
        { GuestRequestkey = Key; }
        public GuestRequest(string PrivateNam, string FamilyNam, 
            string MailAddres, bool Statu, DateTime RegistrationDat,
            DateTime EntryDat, DateTime ReleaseDat, Type Typ, Area Are
            ,SubArea SubAreain, int Adult, int childre, 
            StatusPool Poo, StatusJacuzzi Jacuzz, StatusGarden Garde,
            StatusChildrensAttractions ChildrensAttraction, int GuestRequestke)
        {
           PrivateName = PrivateNam ;
            FamilyName = FamilyNam;
            MailAddress = MailAddres;
            Status = Statu;
            RegistrationDate = ReleaseDat;
            EntryDate = EntryDat;
            ReleaseDate = ReleaseDat;
            Type = Typ;
            Area = Are;
            SubArea = SubAreain;
            Adults = Adult;
            children = childre;
            Pool = Poo;
            Jacuzzi = Jacuzz;
            Garden = Garde;
            ChildrensAttractions = ChildrensAttraction;
            GuestRequestkey = GuestRequestke;


        }
    }
}
