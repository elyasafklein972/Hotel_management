
using System.Collections.Generic;
using System.Text;

using System;

namespace BE
{
    public class Order//:Configuration
    {
       // public bool collectionclearance { get; set; }
        public StatusGuest Status { get; set; }
       public DateTime CreateDate { get; set; }
       public DateTime OrderDate { get; set; }
       public int Commission { get; set; }
        public Order GetCopy() {
            return (Order)this.MemberwiseClone();
        }
        public override string ToString()
        {
            return string.Format("Status:    {0}\n", Status) +
                string.Format("Create Date:    {0}\n", CreateDate) + 
                string.Format("Order Date:    {0}\n", OrderDate) + 
                string.Format("Hostingunit Key:    {0}\n", HostingunitKey) + 
                string.Format("Guest requestKey:    {0}\n", GuestrequestKey) + 
                string.Format("Order key:    {0}\n", Orderkey);
               
        }
        public int HostingunitKey { get; set; }
        public int GuestrequestKey { get; set; }
        public int Orderkey { get; set; }
        //ctor
       //public Order() { }
        public Order(GuestRequest tmp,HostingUnit tmp2)
        {
            Status = StatusGuest.פתוחה;
            GuestrequestKey = tmp.GuestRequestkey;
            HostingunitKey = tmp2.Hostingunitkey;
            Orderkey = ++Configuration.OrderKey;
           
        }
        public Order()
        {
            Commission = 0;
           Orderkey = ++Configuration.OrderKey;
          CreateDate = DateTime.Today;
        
    }
        public Order(StatusGuest a, DateTime b, DateTime c, int d, int e, int f)
        {
            Status = a;
            CreateDate = b;
            OrderDate = c;
            HostingunitKey = d;
            GuestrequestKey = e;
            Orderkey = f;
        }
    }
}
