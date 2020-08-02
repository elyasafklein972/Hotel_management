using System;
using System.Text;
using System.Net.Mail;
using System.Collections.Generic;
using System.Linq;
using BE;
using DS;
using System.Threading;

namespace BL
{
	
	public class BL_Imp : IBL

	{
		
public void SendingEmail(BE.Order order)
		{
			//יצירת אובייקט מסוג בקשת אירוח
			GuestRequest guest = new GuestRequest();
			foreach (var item in IDAL.GetGuestRequestList())
			{
				if (item.GuestRequestkey == order.GuestrequestKey)
				{
					guest = item;
				}
			}
			//יצירת אובייקט מסוג מייל
			MailMessage mail = new MailMessage();
			//כתובת נמען
			mail.To.Add(guest.MailAddress);
			//מייל של השולח
			mail.From = new MailAddress("klein.elyasaf@gmail.com");
			//נושא הודעה
			mail.Subject = "הסטטוס עבר ל- נשלח מייל";
			//תוכן הודעה
			mail.Body = order.ToString();
			//הגדרה שתוכן ההודעה בפורמט HTML 
			mail.IsBodyHtml = true;

			// smt יצירת עצם מסוג 
			SmtpClient smtp = new SmtpClient();

			smtp.Host = "smtp.gmail.com";


			smtp.Credentials = new System.Net.NetworkCredential("elyasaf007@gmail.com",
			 "96522080");

			smtp.EnableSsl = true;
			try
			{

				smtp.Send(mail);
			}
			catch (Exception ex)
			{

				throw new SomeException(ex.Message);
			}

		}
		public Random r = new Random();
		DAL.IDAL IDAL;

		internal BL_Imp()
		{
			IDAL = DAL.Factory.GetInstance();
		}
		public List<BE.Passworde> GetPasswordList()
		{

			return IDAL.GetPasswordList();
		}
		public void updatePassword(BE.Passworde tmp, BE.Passworde tmp2)
		{
			IDAL.updatePassword(tmp, tmp2);
		}
		public IEnumerable<BE.Host> GetAllHost()
		{
			return IDAL.GetAllHost();
		}
		public List<BE.Host> GetHostList()
		{
			return IDAL.GetHostList();
		}

		public void addGuestRequest(BE.GuestRequest Gue)
		{
			
				{
					if (Gue.PrivateName == null || Gue.FamilyName == null || Gue.MailAddress == null
						|| Gue.EntryDate == null || Gue.ReleaseDate == null || (Gue.Adults + Gue.children) == 0)
					{
						throw new SomeException("חובה למלא את כל השדות!");
					}
				}
				if (Gue.ReleaseDate < DateTime.Today || Gue.EntryDate < DateTime.Today)
				{
					throw new SomeException("התאריכים כבר עברו ");
				}
				//if(Gue.ReleaseDate.Equals(Gue.EntryDate))
				//	throw new Exception("חובה שהנופש יכלול לפחות יום אחד");
				if ((Gue.ReleaseDate.Month < Gue.EntryDate.Month))
					throw new SomeException(" התאריך הסופי חייב להיות לפני ההתחלתי");
				if ((Gue.ReleaseDate.Month == Gue.EntryDate.Month))
					if ((Gue.ReleaseDate.Day < Gue.EntryDate.Day))
						throw new SomeException(" התאריך הסופי חייב להיות לפני ההתחלתי");
					else if ((Gue.ReleaseDate.Day == Gue.EntryDate.Day))
						throw new SomeException("חובה שהנופש יכלול לפחות יום אחד");

				try
				{
					MailAddress m = new MailAddress(Gue.MailAddress);
				}
				catch (Exception)
				{

					throw new SomeException("מייל לא תקין");
				}
				IDAL.addGuestRequest(Gue);
			}

		

		public void addOrder(BE.Order order)
	{


		BE.GuestRequest tmp = rGuest(order);
		if (tmp == null)
			throw new SomeException("לא קיים אורח כזה  ");
		BE.HostingUnit tmp2 = rHosting(order);
		if (tmp2 == null)
			throw new SomeException("אין יחידת אירוח כזאת ");

		if (order.Status == BE.StatusGuest.נשלח_מייל && tmp2.Owner.CollectionClearance)
		{

			order.OrderDate = DateTime.Now;


		}
		else if (tmp2.Owner.CollectionClearance == false && order.Status == BE.StatusGuest.נשלח_מייל)
		{
			throw new SomeException("איו אפשרות לשלוח מייל אם אין הרשאה לחיוב חשבון ");
		}
		else
		{ IDAL.addOrder(order); }


	}
		/// <summary>
		/// update the order
		/// </summary>
		/// <param name="order"></param>
		public void updateOrder(BE.Order order)
		{
			IDAL.updateOrder(order);
		}
		public int rCommission(int key)
		{
			BE.Order tmp = null;
			tmp = DS.DataSource.Orders.Single(x => x.Orderkey == key);//lambda
			if (tmp==null)
			{
				throw new SomeException("לא קיימת הזמנה כזאת");
			}
			foreach (var item in IDAL.GetAllOrder())
			{
				if (item.Orderkey == key)
					return item.Commission;
			}
			return 0;
		}



		
		/// <summary>
		/// return the guest request of the order
		/// </summary>
		/// <param name="order"></param>
		/// <returns></returns>
		public BE.GuestRequest rGuest(BE.Order order)
		{
			foreach (var item in IDAL.GetGuestRequestList())
			{
				if (item.GuestRequestkey == order.GuestrequestKey)
					return item;

			}

			return null;
		}
		/// <summary>
		/// return hosting unit of the order
		/// </summary>
		/// <param name="order"></param>
		/// <returns></returns>
		public BE.HostingUnit rHosting(BE.Order order)
		{
			BE.HostingUnit tmp = null;
			 tmp =DS.DataSource.HostingUnits.Single(x => x.Hostingunitkey == order.HostingunitKey);//lambda
			return tmp;


		}
		/// <summary>
		/// return the guest request of the order
		/// </summary>
		/// <param name="order"></param>
		/// <returns></returns>
		public BE.GuestRequest rGuest(int key)
		{
			foreach (var item in IDAL.GetGuestRequestList())
			{
				if (item.GuestRequestkey == key)
					return item;

			}

			return null;
		}
		/// <summary>
		/// return hosting unit of the order
		/// </summary>
		/// <param name="order"></param>
		/// <returns></returns>
		public BE.HostingUnit rHosting(int key)
		{
			foreach (var item in IDAL.GetHostingUnitList())
			{
				if (item.Hostingunitkey == key)
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
					//return true;
				}

				return true;
			}



		}
		/// <summary>
		/// return true if hosting unit option
		/// </summary>
		/// <param name="first"></param>
		/// <param name="end"></param>
		/// <param name="ho"></param>
		/// <returns></returns>
		public bool checkHost(DateTime first, DateTime end, BE.HostingUnit ho)
		{



			int dayf = first.Day;
			int dayl = end.Day;
			int a1 = first.Month;
			int a2 = end.Month;
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
				TimeSpan t = first.Subtract(end);

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
				TimeSpan t = first.Subtract(end);// the substract the days

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
					//return true;
				}

				return true;
			}



		}
		/// <summary>
		/// apdate GuestRequest to data base
		/// </summary>
		/// <param name="Gue"></param>
		public void apdateGuestRequest(BE.GuestRequest Gue)
		{

			IDAL.apdateGuestRequest(Gue);

		}
		/// <summary>
		/// add Hosting Unit to date base 
		/// </summary>
		/// <param name="host"></param>
		public void addHostingUnit(BE.HostingUnit hostingunit)
		{
			if(hostingunit.HostingUnitName==null)
			{
				throw new SomeException("חובה למלא שם");
			}
			hostingunit.Owner.numHostingUnit++;
			IDAL.addHostingUnit(hostingunit);

		}
		/// <summary>
		/// delete Hosting Unit to date base 
		/// </summary>
		/// <param name="hostingunit"></param>
		public void DeleteHostingUnit(BE.HostingUnit hostingunit)
		{
			BE.HostingUnit tmp = null;
			tmp = DS.DataSource.HostingUnits.Single(x => x.Hostingunitkey == hostingunit.Hostingunitkey);//lambda
			if (tmp == null)
			{
				throw new SomeException("לא קיימת יחידת דיור כזאת");
			}
			//bool tmp = false;
			foreach (var item in IDAL.GetOrderList())
			{
				if (item.HostingunitKey == hostingunit.Hostingunitkey 
					&& item.Status != BE.StatusGuest.נסגר_בהענות_של_הלקוח 
					&& item.Status != BE.StatusGuest.נסגר_מחוסר_הענות_של_הלקוח)
				{
					throw new SomeException(" לא ניתן למחוק יחידת אירוח כל עוד יש הצעה הקשורה אליה במצב פתוח");
				}
			}

			IDAL.DeleteHostingUnit(hostingunit);

		}
		/// <summary>
		/// apdate Hosting Unit to date base 
		/// </summary>
		/// <param name="hostingunit"></param>
		public void apdateHostingUnit(BE.HostingUnit hostingunit)
		{


			IDAL.apdateHostingUnit(hostingunit);

		}


		/// <summary>
		/// get all HostingUnit
		/// </summary>
		/// <returns></returns>
		public IEnumerable<BE.HostingUnit> GetAllHostingUnit()
		{



			return IDAL.GetAllHostingUnit();
		}
		/// <summary>
		/// gwt all guests
		/// </summary>
		/// <returns></returns>
		public IEnumerable<BE.GuestRequest> GetAllGuest()
		{




			return IDAL.GetAllGuest();
		}
		/// <summary>
		/// get all order
		/// </summary>
		/// <returns></returns>
		public IEnumerable<BE.Order> GetAllOrder()
		{




			return IDAL.GetAllOrder();
		}
		/// <summary>
		/// get all Bank
		/// </summary>
		/// <returns></returns>
		public IEnumerable<BE.BankAccount> GetAllBank()
		{




			return IDAL.GetAllBank();
		}
		/// <summary>
		/// get all options HostingUnit
		/// </summary>
		/// <param name="guestReq"></param>
		/// <returns></returns>
		public IEnumerable<BE.HostingUnit> GetoptionHost(DateTime t, int num)
		{
			List<BE.HostingUnit> options = new List<BE.HostingUnit>();
			DateTime R = t.AddDays(num);
			foreach (var item in IDAL.GetHostingUnitList())
			{
				if (checkHost(t, R, item) == true)
				{

					options.Add(item);

				}

			}
			return options;

		}
		/// <summary>
		/// reutrn sub to Date or sub tooday to order
		/// </summary>
		/// <param name="d"></param>
		/// <returns></returns>
		public int rDay(params DateTime[] d)
		{
			TimeSpan t;
			if (d.Length == 2)
			{
				t = d[0].Subtract(d[1]);
			}
			else
			if (d.Length == 1)
			{
				DateTime N = DateTime.Now;
				t = N.Subtract(d[0]);
			}
			else
			{ throw new SomeException("צריכים להכניס תאריך אחד או שניים "); }

			return t.Days;
		}

		public IEnumerable<BE.Order> rorders(int days)
		{
			List<BE.Order> or = new List<BE.Order>();
			foreach (var item in IDAL.GetOrderList())
			{
				if ((item.OrderDate - item.CreateDate).TotalDays >= days)
				{
					or.Add(item);
				}

			}
			return or;
		}
		/// <summary>
		/// delegate fun set GuestRequest and return bool
		/// </summary>
		/// <param name="x"></param>
		/// <returns></returns>
		public delegate bool checkIf(BE.GuestRequest x);
		/// <summary>
		/// retrun all orders of tmp Key
		/// </summary>
		/// <param name="tmp"></param>
		/// <returns></returns>
		public IEnumerable<BE.Order> GetGuest(BE.GuestRequest tmp)
		{
			List<BE.Order> or = new List<BE.Order>();
			foreach (var item in IDAL.GetOrderList())
			{
				if(item.GuestrequestKey==tmp.GuestRequestkey)
				{
					or.Add(item);
				}

			}
			return or;
		}
		/// <summary>
		/// Group according to area of guest
		/// </summary>
		/// <returns></returns>
		public IEnumerable<BE.GuestRequest> GrouGuestArea()
		{
			var arr= from item in IDAL.GetGuestRequestList()
					group item by item.Area into groupName
					select new
					{
						g=groupName
				};
			List<BE.GuestRequest> arr2=new List<BE.GuestRequest>();
			foreach (var item in arr)
			{
				foreach ( var item2 in item.g)
				{
					arr2.Add(item2);
				}	
			}
			return arr2;
		}
		/// <summary>
		/// Group according to num of guest of guest
		/// </summary>
		/// <returns></returns>
		public IEnumerable<BE.GuestRequest> GrouGuestnums()
		{
			var arr = from item in IDAL.GetGuestRequestList()
					  group item by item.children+item.Adults into groupName
					  select new
					  {
						  g = groupName
					  };
			List<BE.GuestRequest> arr2 = new List<BE.GuestRequest>();
			foreach (var item in arr)
			{
				foreach (var item2 in item.g)
				{
					arr2.Add(item2);
				}
			}
			return arr2;
		}
		/// <summary>
		/// Group according to num of HostingUnit of Host
		/// </summary>
		/// <returns></returns>
		public List<BE.Host> HostingUnitnums()
		{

			var arr = from item in IDAL.GetHostList()
					  group item by item.numHostingUnit into groupName
					  select new
					  {
						  g = groupName
					  };


			List<BE.Host> arr2 = new List<BE.Host>();
			foreach (var item in arr)
			{
				foreach (var item2 in item.g)
				{
					arr2.Add(item2);
				}
			}
			return arr2;
		}


		/// <summary>
		/// Group according to num of HostingUnit of Host
		/// </summary>
		/// <returns></returns>
		public List<BE.HostingUnit> HostingUnitkey()
		{

			var arr = from item in IDAL.GetAllHostingUnit()
					  group item by item.Hostingunitkey into groupName
					  select new
					  {
						  g = groupName
					  };


			List<BE.HostingUnit> arr2 = new List<BE.HostingUnit>();
			foreach (var item in arr)
			{
				foreach (var item2 in item.g)
				{
					arr2.Add(item2);
				}
			}
			return arr2;
		}





		/// <summary>
		/// Group according to num of HostingUnit of Host
		/// </summary>
		/// <returns></returns>
		public IEnumerable<BE.HostingUnit> HostingUnitArea()
		{

			var arr = from item in IDAL.GetHostingUnitList()
					  group item by item.Area into groupName
					  select new
					  {
						  g = groupName
					  };


			List<BE.HostingUnit> arr2 = new List<BE.HostingUnit>();
			foreach (var item in arr)
			{
				foreach (var item2 in item.g)
				{
					arr2.Add(item2);
				}
			}
			return arr2;
		}

		public List<BE.GuestRequest> GetChild()
		{
			List<BE.GuestRequest> tmp = new List<GuestRequest>();
			var arr = from item in DS.DataSource.GuestRequests
					  group item by item.children into groupChildren
					 
					  select new
					  {
						  g = groupChildren
					  };
			foreach (var item in arr)
			{
				foreach (var item2 in item.g)
				{
					tmp.Add(item2);
				}
			}
			
			return tmp;
		}


		///// <summary>
		///// return name of all guestRequest
		///// </summary>
		///// <returns></returns>
		//public IEnumerable<string> GetGuest()
		//{
		//	return IDAL.GetGuest();
		//}

		/// <summary>
		/// sort acording to Private name of Guest and pring if children>0
		/// </summary>

		
		/// <summary>
		/// sort acording to hostKey of Host and pring
		/// </summary>
		public List<Host> PrintHost()
		{
			return IDAL.PrintHost();
		}

		/// <summary>
		/// sort acording to day of guest
		/// </summary>
		public string Printdays()
		{
			return IDAL.Printdays();
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
					foreach (var item2 in IDAL.GetOrderList())
					{

						BE.HostingUnit tmp = rHosting(item2);
						if (tmp.Owner.Hostkey == num
						  && item2.Status != BE.StatusGuest.נסגר_בהענות_של_הלקוח
						  && item2.Status != BE.StatusGuest.נסגר_מחוסר_הענות_של_הלקוח)
						{
							throw new SomeException(" לא ניתן לבטל הרשאת חשבון כל עוד יש הצעה הקשורה אליה במצב פתוח");
						}
					}
				}
			}

			IDAL.UpdateCollectionClearance(num);
		}

		private void HelpToCheck()
		{
			List<Order> tmpList = IDAL.GetOrderList();
			while (true)
			{

				foreach (var item in tmpList)
				{
					if (item.Status == BE.StatusGuest.נשלח_מייל)
					{
						if (rDay(DateTime.Now,item.OrderDate)>=30)
						{
							item.Status = BE.StatusGuest.נסגר_מחוסר_הענות_של_הלקוח;
						}
					}
				}

			}
		}

		public void CheckGuest()
		{
			TimeSpan n = new TimeSpan(0,1,0);
			
			Thread thread = new Thread(HelpToCheck);
			thread.Start();
			Thread.Sleep(n);
		}

	};
}

