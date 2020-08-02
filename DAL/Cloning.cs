using System;
using System.Collections.Generic;
using System.Text;
using BE;
namespace DAL
{
    public static class Cloning
    {

        public static BE.BankAccount Clone (this BE.BankAccount original)
        {
            BE.BankAccount target = new BankAccount(original.BankName,original.BranchNumber, original.BranchAddress,original.BranchCity,original.Banknumber);
            return target;

        }
        public static BE.GuestRequest Clone(this BE.GuestRequest original)
        {
            BE.GuestRequest target = new BE.GuestRequest(original.PrivateName, original.FamilyName, original.MailAddress, original.Status, original.RegistrationDate, original.EntryDate, original.ReleaseDate, original.Type, original.Area, original.SubArea, original.Adults, original.children, original.Pool, original.Jacuzzi, original.Garden, original.ChildrensAttractions, original.GuestRequestkey);
            return target;
        }
        public static BE.Order Clone(this BE.Order original)
        {
            BE.Order target = new BE.Order(original.Status, original.CreateDate, original.OrderDate, original.HostingunitKey, original.GuestrequestKey, original.Orderkey);


            return target;
        }
        public static BE.HostingUnit Clone(this BE.HostingUnit original)
        {
            BE.HostingUnit target = new BE.HostingUnit(original.Owner, original.Area, original.HostingUnitName, original.Hostingunitkey,original.Diary);
           

            return target;
        }
        public static BE.Passworde Clone(this BE.Passworde original)
        {
            BE.Passworde target = new BE.Passworde(original.User, original.Password);
            return target;
        }
        public static BE.Host Clone(this BE.Host original)
        {
            BE.Host target = new BE.Host();
            target.BankAccount = original.BankAccount;
            target.CollectionClearance = original.CollectionClearance;
            target.FamilyName = original.FamilyName;
            target.FhoneNumber = original.FhoneNumber;
            target.Hostkey = original.Hostkey;
            target.MailAddress = original.MailAddress;
            target.numHostingUnit = original.numHostingUnit;
            target.PrivateName = original.PrivateName;
           

            return target;
        }
    };
}