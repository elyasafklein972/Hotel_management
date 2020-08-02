using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
namespace DS
{
    public class DataSource
    {
        public static List<BE.Passworde> pass = new List<BE.Passworde>()
        {
            new BE.Passworde("elyasaf007","6522080")
            {
            },
            new BE.Passworde("1","1")
            {
            },
            new BE.Passworde("a","a")
            {
            }
        };
        public static List<BE.BankAccount> Banks = new List<BE.BankAccount>()
                 {
           new BE.BankAccount()
           {
               BankName="discount",BranchAddress="aaa",BranchCity="Rehovot",BranchNumber=111111

           },
            new BE.BankAccount()
           {
               BankName="Leumi",BranchAddress="aaa",BranchCity="Rehovot",BranchNumber=555555

           },
             new BE.BankAccount()
           {
               BankName="Poalim",BranchAddress="aaa",BranchCity="Rehovot",BranchNumber=22222

           },
              new BE.BankAccount()
           {
               BankName="Igud",BranchAddress="aaa",BranchCity="Rehovot",BranchNumber=333333

           },
               new BE.BankAccount()
           {
               BankName="tfahot",BranchAddress="aaa",BranchCity="Rehovot",BranchNumber=444444

           },
                };
        public static List<BE.Host> Hosts = new List<BE.Host>()
        {
        new BE.Host()
                    {
                        PrivateName = "bbbbb",
                        FamilyName = "cccc",
                        FhoneNumber = 0542768989,
                        MailAddress = "omerhadad23@gmail.com",
                        BankAccount = Banks[1],


                        CollectionClearance = false
            },
                new BE.Host()
                    {
                        PrivateName = "cccc",
                        FamilyName = "dddd",
                        FhoneNumber = 0525676344,
                        MailAddress = "omerhadad23@gmail.com",
                        BankAccount = Banks[0],
                        CollectionClearance = true

                    },
                 new BE.Host()
                    {
                        PrivateName = "bbbbb",
                        FamilyName = "cccc",
                        FhoneNumber = 0542768989,
                        MailAddress = "omerhadad23@gmail.com",
                        BankAccount = Banks[1],


                        CollectionClearance = true
                    },
                 new BE.Host()
                    {
                        PrivateName = "aaaa",
                        FamilyName = "bbbb",
                        FhoneNumber = 089469444,
                        MailAddress = "omerhadad23@gmail.com",
                        BankAccount =Banks[3],
                        CollectionClearance = false
                    }

        };
      
        public static List<BE.GuestRequest> GuestRequests = new List<BE.GuestRequest>()
                    {

                new BE.GuestRequest()
                {

                    PrivateName = "ely",
                    FamilyName = "klein",
                    MailAddress = "omerhadad23@gmail.com",
                    Status = true,
                    RegistrationDate = new DateTime(2019, 01, 01),
                    EntryDate = new DateTime(2019, 01, 01),
                    ReleaseDate = new DateTime(2019, 01, 03),
                    Type = BE.Type.Hotel,
                    Area = BE.Area.Center,
                    SubArea = BE.SubArea.רחובות,
                    Adults = 10,
                    children = 100,
                    Pool = BE.StatusPool.מעוניין,
                    Jacuzzi = BE.StatusJacuzzi.אפשרי,
                    Garden = BE.StatusGarden.אפשרי,
                    ChildrensAttractions = BE.StatusChildrensAttractions.מעוניין
                },

                new BE.GuestRequest()
                {
                    PrivateName = "omer",
                    FamilyName = "hadad",
                    MailAddress = "omerhadad23@gmail.com",
                    Status = true,
                    RegistrationDate = new DateTime(2019, 01, 01),
                    EntryDate = new DateTime(2019, 01, 04),
                    ReleaseDate = new DateTime(2019, 01, 09),
                    Type = BE.Type.Hotel,
                    Area = BE.Area.Center,
                    SubArea = BE.SubArea.תל_אביב,
                    Adults = 2,
                    children = 4,
                    Pool = BE.StatusPool.לא_הכרחי,
                    Jacuzzi = BE.StatusJacuzzi.מעוניין,
                    Garden = BE.StatusGarden.אפשרי,
                    ChildrensAttractions = BE.StatusChildrensAttractions.מעוניין
                }


                };
        public static List<BE.HostingUnit> HostingUnits = new List<BE.HostingUnit>()
                     {

                 new BE.HostingUnit()
                {

                    Area=BE.Area.North,

                    Owner = Hosts[3],
                    HostingUnitName = "סלמתאק של יחידה"

                },
                new BE.HostingUnit()
                {
                     Area=BE.Area.Center,
                    Owner =Hosts[2],
                    HostingUnitName = "סחבאק של יחידה"

                },
                new BE.HostingUnit()
                {

                    Area=BE.Area.North,
                    Owner = Hosts[1],
                    HostingUnitName = "שבאב של יחידה"
                },
                 new BE.HostingUnit()
                {
                     Area=BE.Area.Center,
                    Owner = Hosts[0],
                    
                    HostingUnitName = "יחידה של השמחות "

                }



                      };

      





        public static List<BE.Order> Orders = new List<BE.Order>()
              {

            new BE.Order(GuestRequests[0],HostingUnits[0]){ Commission = (BE.Configuration.Commission * (GuestRequests[0].ReleaseDate-GuestRequests[0].EntryDate).Days), CreateDate=DateTime.Now,OrderDate=GuestRequests[0].RegistrationDate },
            new BE.Order(GuestRequests[1],HostingUnits[1]){ Commission = (BE.Configuration.Commission * (GuestRequests[1].ReleaseDate-GuestRequests[1].EntryDate).Days),CreateDate=DateTime.Now,OrderDate=GuestRequests[1].RegistrationDate },
            new BE.Order(GuestRequests[0],HostingUnits[2]){Commission = (BE.Configuration.Commission * (GuestRequests[0].ReleaseDate-GuestRequests[0].EntryDate).Days), CreateDate=DateTime.Now,OrderDate=GuestRequests[0].RegistrationDate},
            new BE.Order(GuestRequests[1],HostingUnits[0]){Commission = (BE.Configuration.Commission * (GuestRequests[1].ReleaseDate-GuestRequests[1].EntryDate).Days), CreateDate=DateTime.Now,OrderDate=GuestRequests[1].RegistrationDate}


              };

          


   
    
    };
}
   


