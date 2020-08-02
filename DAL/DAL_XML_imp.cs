using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using BE;
using DS;

namespace DAL
{
	/// <summary>
	/// the class implements Idal and uses functions of the XMLHandler class to load and save data to XML files
	/// </summary>
	public class DAL_XML_imp : IDAL
	{
      
        //XMLHandler.GetXMLHandler();
        #region addObject
        /// <summary>
        /// add Hosting Unit to date base 
        /// </summary>
        /// <param name="host"></param>
        public void addHostingUnit(BE.HostingUnit hostingunit)
		{
            foreach (var item in DataSource.Hosts)
            {

                if(item.Hostkey==hostingunit.Owner.Hostkey)
                {
                    item.numHostingUnit++;
                }
            }

			DataSource.HostingUnits.Add(hostingunit);
			XMLHandler.GetXMLHandler().SaveToXML(DataSource.HostingUnits, XMLHandler.GetXMLHandler().HostingUnitPath);
			XMLHandler.GetXMLHandler().SaveToXML(DataSource.Hosts, XMLHandler.GetXMLHandler().HostPath);
		}
		/// <summary>
		/// add GuestRequest to data base
		/// </summary>
		/// <param name="Gue"></param>	
		public void addGuestRequest(BE.GuestRequest Gue)
		{

			DataSource.GuestRequests.Add(Gue);
			XMLHandler.GetXMLHandler().SaveToXML(DataSource.GuestRequests, XMLHandler.GetXMLHandler().GuestRequestPath);
		}
		/// <summary>
		/// add order to date base 
		/// </summary>
		/// <param name="order"></param>
		public void addOrder(BE.Order or)
		{
            BE.GuestRequest tmp = null;

            tmp = rGuest(or);

            BE.HostingUnit tmp2 = rHosting(or);
            int days = (tmp.ReleaseDate - tmp.EntryDate).Days;

            int price = (BE.Configuration.Commission * days);
            or.Commission = price;
            if (ApproveRequest(tmp, tmp2))
            {
                //סימון במטריצה
                Approve(tmp, tmp2);
                
                DataSource.Orders.Add(or);

            }
            else
            {
                throw new Exception("הימים תפוסים ולא ניתן לבצע את ההזמנה");
            }
           
			XMLHandler.GetXMLHandler().SaveToXML(DataSource.Orders, XMLHandler.GetXMLHandler().OrderPath);
			XMLHandler.GetXMLHandler().SaveToXML(DataSource.HostingUnits, XMLHandler.GetXMLHandler().HostingUnitPath);
		}
		#endregion addObject
		#region Config++
		/// <summary>
		/// Config
		/// </summary>
		public void AddGuestRequestkey()
		{
			XMLHandler.GetXMLHandler().AddToGuestRequestkey();
		}
		public void AddOredertkey()
		{
			XMLHandler.GetXMLHandler().AddToOrderkey();
		}
		public void AddHostingUnitkey()
		{
			XMLHandler.GetXMLHandler().AddToHostingUnitkey();
		}
		public void AddHostkey()
		{
			XMLHandler.GetXMLHandler().AddToHostkey();
		}
		#endregion Config++
		#region dalete fun


		// <summary>
		/// delete Hosting Unit to date base 
		/// </summary>
		/// <param name="hostingunit"></param>
		public void DeleteHostingUnit(BE.HostingUnit hostingunit)
		{
            BE.HostingUnit tmp = null;
            tmp = DS.DataSource.HostingUnits.Single(x => x.Hostingunitkey == hostingunit.Hostingunitkey);
            if (tmp == null)
            {
                throw new SomeException("יחידת הדיור אינה קיימת");
            }
            for (int i = 0; i < DS.DataSource.HostingUnits.Count; i++)
            {
                if (DS.DataSource.HostingUnits[i].Hostingunitkey == hostingunit.Hostingunitkey)
                {
                    DataSource.HostingUnits.Remove(hostingunit);
                }
            }
           
			XMLHandler.GetXMLHandler().SaveToXML(DataSource.HostingUnits, XMLHandler.GetXMLHandler().HostingUnitPath);
		}
		//// <summary>
		///// delete Hosting Unit to date base 
		///// </summary>
		///// <param name="hostingunit"></param>
		//public void DeleteGuestRequest(BE.GuestRequest Gue)
		//{
		//	DataSource.GuestRequests.Remove(Gue);
		//	XMLHandler.GetXMLHandler().SaveToXML(DataSource.GuestRequests, XMLHandler.GetXMLHandler().GuestRequestPath);
		//}
		#endregion delete fun

           
		/// <summary>
		/// apdate Hosting Unit to date base 
		/// </summary>
		/// <param name="hostingunit"></param>
		public void apdateHostingUnit(BE.HostingUnit hos)
		{
            for (int i = 0; i < DS.DataSource.HostingUnits.Count; i++)
            {
                if (DS.DataSource.HostingUnits[i].Hostingunitkey == hos.Hostingunitkey)
                {
                    DS.DataSource.HostingUnits[i] = hos;
                    
                        

                    XMLHandler.GetXMLHandler().SaveToXML(DataSource.HostingUnits, XMLHandler.GetXMLHandler().HostingUnitPath);
				}
			}


		}
		/// <summary>
		/// update order to date base 
		/// </summary>
		/// <param name="order"></param>
		public void updateOrder(BE.Order order)
		{
            BE.Order tmp = null;
            tmp = GetAllOrder().Single(x => x.Orderkey == order.Orderkey);//lambda
            if (tmp == null)
            {
                throw new SomeException("לא קיימת הזמנה כזאת");
            }
            //foreach (var item in DS.DataSource.Orders)
            //{
            //    if (item.Orderkey == order.Orderkey)
            //    {
            //        tmp = item;
            //    }
            //}

            if ((tmp.Status == BE.StatusGuest.נסגר_בהענות_של_הלקוח) || (tmp.Status == BE.StatusGuest.נסגר_מחוסר_הענות_של_הלקוח))
            {
                throw new SomeException(" אי אפשר לשנות הזמנה אחרי שהיא נסגרה");

            }


            //save status
            for (int i = 0; i < DataSource.Orders.Count; i++)
            {
                if (DataSource.Orders[i].Orderkey == order.Orderkey)
                {
                    DataSource.Orders[i] = order;
                   XMLHandler.GetXMLHandler().SaveToXML(DataSource.Orders, XMLHandler.GetXMLHandler().OrderPath);
                }
            }
            if ((tmp.Status == BE.StatusGuest.נסגר_בהענות_של_הלקוח) || (tmp.Status == BE.StatusGuest.נסגר_מחוסר_הענות_של_הלקוח))
            {

                BE.GuestRequest tmp2 = rGuest(order);
                int days = (tmp2.ReleaseDate - tmp2.EntryDate).Days;
                //חישוב עמלה
              
                order.Commission= (BE.Configuration.Commission * days);
                order.OrderDate = DateTime.Today;
            }

            XMLHandler.GetXMLHandler().SaveToXML(DataSource.Orders, XMLHandler.GetXMLHandler().OrderPath);
				
			}
		
		/// <summary>
		/// apdate GuestRequest to data base
		/// </summary>
		/// <param name="Gue"></param>
		public void apdateGuestRequest(BE.GuestRequest Gue)
		{
			for (int i = 0; i < DataSource.GuestRequests.Count; i++)
			{
				if (DataSource.GuestRequests[i].GuestRequestkey == Gue.GuestRequestkey)
				{
					DataSource.GuestRequests[i] = Gue;
                    XMLHandler.GetXMLHandler().SaveToXML(DataSource.GuestRequests, XMLHandler.GetXMLHandler().GuestRequestPath);
				}
			}
		}
		/// <summary>
		/// to Update Collection Clearance
		/// </summary>
		/// <param name="num"></param>
		public void UpdateCollectionClearance(int num)
		{
			foreach (var item in DS.DataSource.HostingUnits)
			{
				if (item.Owner.Hostkey == num)
				{
					item.Owner.CollectionClearance = item.Owner.CollectionClearance == true ? false : true;
                    XMLHandler.GetXMLHandler().SaveToXML(DataSource.Hosts, XMLHandler.GetXMLHandler().HostPath);
				}
			}



		}
		/// <summary>
		/// get all HostingUnit
		/// </summary>
		/// <returns></returns>
		public IEnumerable<BE.HostingUnit> GetAllHostingUnit()
		{
			return XMLHandler.GetXMLHandler().LoadHostingUnitFile();
		}
		/// <summary>
		/// gwt all guests
		/// </summary>
		/// <returns></returns>
		public IEnumerable<BE.GuestRequest> GetAllGuest()
		{
			return XMLHandler.GetXMLHandler().LoadGuestRequestFile();
		}
		/// <summary>
		/// get all order
		/// </summary>
		/// <returns></returns>
		public IEnumerable<BE.Order> GetAllOrder()
		{
			return XMLHandler.GetXMLHandler().LoadOrderFile();
		}
        // <summary>
        /// get all password
        /// </summary>
        /// <returns></returns>
        public IEnumerable<BE.Passworde> GetAllpassword()
        {
            return XMLHandler.GetXMLHandler().LoadPasswordeFile();
        }
        /// <summary>
        /// get all HostingUnit
        /// </summary>
        /// <returns></returns>
        public IEnumerable<BE.Host> GetAllHost()
        {

            
            return XMLHandler.GetXMLHandler().LoadHostFile();

        }
        /// <summary>
        /// get all Bank
        /// </summary>
        /// <returns></returns>
        public IEnumerable<BE.BankAccount> GetAllBank()
        {

            return XMLHandler.GetXMLHandler().GetBank();

        }


        public void updatePassword(Passworde tmp, Passworde tmp2)
        {
            BE.Passworde tmp3 = null;
            foreach (var item in DS.DataSource.pass)
            {
                if (item.User == tmp.User && item.Password == tmp.Password)
                {
                    tmp3 = item;
                    item.User = tmp2.User;
                    item.Password = tmp2.Password;
                }
            }
            if (tmp3 == null)
            {
                throw new SomeException("שם משתמש וסיסמה אינם נכונים");
            }
            XMLHandler.GetXMLHandler().SaveToXML(DataSource.pass, XMLHandler.GetXMLHandler().PasswordePath);
        }



      
        /// <summary>
        /// sort acording to hostKey of Host and pring
        /// </summary>
        public List<Host> PrintHost()
        {
            string tmp = string.Empty;
            List<Host> tmp2 = new List<Host>();
            IEnumerable<Host> arr = from item in XMLHandler.GetXMLHandler().LoadHostFile()
                                    orderby item.Hostkey
                                    select item;
            foreach (var item in arr)
            {
                tmp2.Add(item);
            }
            return tmp2;
        }
        /// <summary>
        /// sort acording to day of guest
        /// </summary>
        public string Printdays()
        {
            string tmp = string.Empty;
            var arr = from item in DS.DataSource.GuestRequests
                      let days = (item.ReleaseDate - item.EntryDate).Days
                      orderby days
                      select new
                      {
                          details = item.GuestRequestkey + " " + item.PrivateName + " " + item.FamilyName,
                          day = days
                      };
            foreach (var item in arr)
            {

                tmp += (item.details + "\n" + item.day + "\n");
            }
            return tmp;
        }
        
        
        
        public BE.HostingUnit rHosting(BE.Order order)
        {
            foreach (var item in DS.DataSource.HostingUnits)
            {
                if (item.Hostingunitkey == order.HostingunitKey)
                    return item;
            }

            return null;
        }
        /// <summary>
		/// mark days in matrix
		/// </summary>
		/// <param name="guestReq"></param>
		/// <param name="ho"></param>
		public void Approve(BE.GuestRequest guestReq, BE.HostingUnit ho)
        {



            int dayf = guestReq.EntryDate.Day;
            int dayl = guestReq.ReleaseDate.Day;
            int a1 = guestReq.EntryDate.Month;
            int a2 = guestReq.ReleaseDate.Month;
            a1--;
            a2--;

            //if the mounth same


            if (a1 == a2)
            {


                //ho.IsApproved = true;
                TimeSpan t = guestReq.ReleaseDate.Subtract(guestReq.EntryDate);

                //sum += t.Days;
                for (int i = (dayf - 1); i < (dayl - 1); i++)
                {
                    ho.Diary[a1, i] = true;
                    //sum++;
                }


            }
            else
            {

                int temp1 = a1;
                int temp2 = a2;
                int d1 = dayf - 1;
                int d2 = dayl - 1;
                //run from the first day to end
                while ((temp1 != temp2 || d1 != d2))
                {

                    if (d1 == 30)
                    {
                        if (temp1 < 11)
                            temp1++;
                        else temp1 = 0;
                        d1 = -1;
                    }
                    d1++;
                }
                TimeSpan t = guestReq.ReleaseDate.Subtract(guestReq.EntryDate);// the substract the days

                //sum += t.Days;//save
                //guestReq.IsApproved = true;//the request approved
                temp1 = a1;
                temp2 = a2;
                d1 = dayf - 1;
                d2 = dayl - 1;
                while (temp1 != temp2 || d1 != d2)
                {
                    ho.Diary[temp1, d1] = true;

                    if (d1 == 30)
                    {

                        if (temp1 < 11)
                            temp1++;
                        else temp1 = 0;
                        d1 = -1;
                    }
                    d1++;
                    //return true;
                }


            }



        }
        
        
        /// <summary>
		/// return the guest request of the order
		/// </summary>
		/// <param name="order"></param>
		/// <returns></returns>
		public BE.GuestRequest rGuest(BE.Order order)
        {
            return DS.DataSource.GuestRequests.Single(x => x.GuestRequestkey == order.GuestrequestKey);

        }
        
       
       
       
        /// <summary>
		/// check days from matrix
		/// </summary>
		/// <param name="guestReq"></param>
		/// <param name="ho"></param>
		/// <returns></returns>
		public bool ApproveRequest(BE.GuestRequest guestReq, BE.HostingUnit ho)
        {



            int dayf = guestReq.EntryDate.Day;
            int dayl = guestReq.ReleaseDate.Day;
            int a1 = guestReq.EntryDate.Month;
            int a2 = guestReq.ReleaseDate.Month;
            a1--;
            a2--;

            //if the mounth same


            if (a1 == a2)
            {

                for (int j = (dayf - 1); j < (dayl - 1); j++)
                {
                    if (ho.Diary[a1, j])
                    {
                        //	ho.IsApproved = false;
                        return false;
                    }
                }
                //ho.IsApproved = true;
                TimeSpan t = guestReq.ReleaseDate.Subtract(guestReq.EntryDate);

                //sum += t.Days;
                for (int i = (dayf - 1); i < (dayl - 1); i++)
                {
                    //	ho.Diary[a1, i] = true;
                    //sum++;
                }

                return true;
            }
            else
            {

                int temp1 = a1;
                int temp2 = a2;
                int d1 = dayf - 1;
                int d2 = dayl - 1;
                //run from the first day to end
                while ((temp1 != temp2 || d1 != d2))
                {
                    if (ho.Diary[temp1, d1])
                    {
                        //guestReq.IsApproved = false;//the request not approved
                        return false;
                    }
                    if (d1 == 30)
                    {
                        if (temp1 < 11)
                            temp1++;
                        else temp1 = 0;
                        d1 = -1;
                    }
                    d1++;
                }
                TimeSpan t = guestReq.ReleaseDate.Subtract(guestReq.EntryDate);// the substract the days

                //sum += t.Days;//save
                //guestReq.IsApproved = true;//the request approved
                temp1 = a1;
                temp2 = a2;
                d1 = dayf - 1;
                d2 = dayl - 1;
                while (temp1 != temp2 || d1 != d2)
                {
                    //	ho.Diary[temp1, d1] = true;

                    if (d1 == 30)
                    {

                        if (temp1 < 11)
                            temp1++;
                        else temp1 = 0;
                        d1 = -1;
                    }
                    d1++;

                }

                return true;
            }



        }
        //clones
        public List<BE.GuestRequest> GetGuestRequestList()
        {
            if (DataSource.GuestRequests == null)
                throw new SomeException("הרשימה ריקה ");
            return XMLHandler.GetXMLHandler().LoadGuestRequestFile().Select(Gu => (GuestRequest)Gu.Clone()).ToList();
          
        }
        public List<BE.HostingUnit> GetHostingUnitList()
        {
            if (DataSource.HostingUnits == null)
                throw new SomeException("הרשימה ריקה ");
            return XMLHandler.GetXMLHandler().LoadHostingUnitFile().Select(Gu => (HostingUnit)Gu.Clone()).ToList();
        }
        public List<BE.Host> GetHostList()
        {
            if (DataSource.Hosts == null)
                throw new SomeException("הרשימה ריקה ");
            return XMLHandler.GetXMLHandler().LoadHostFile().Select(Gu => (Host)Gu.Clone()).ToList();
        }
        public List<BE.Order> GetOrderList()
        {
            if (DataSource.Orders == null)
                throw new SomeException("הרשימה ריקה ");
            return XMLHandler.GetXMLHandler().LoadOrderFile().Select(Gu => (Order)Gu.Clone()).ToList();
        }
        public List<BE.BankAccount> GetBankList()
        {
            if (DataSource.Banks == null)
                throw new SomeException("הרשימה ריקה ");
            return DataSource.Banks.Select(Gu => (BankAccount)Gu.Clone()).ToList();
        }
       
        public List<BE.Passworde> GetPasswordList()
        {

            if (DataSource.pass == null)
                throw new Exception("אין קודים שמורים במערכת  ");
            return XMLHandler.GetXMLHandler().LoadPasswordeFile().Select(Gu => (Passworde)Gu.Clone()).ToList();
        }
        



    }

}

