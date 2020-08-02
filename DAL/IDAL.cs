using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Mail;

namespace DAL
{
     public interface IDAL
    {
        #region Host Fun;
        /// <summary>
        /// to Update Collection Clearance
        /// </summary>
        /// <param name="num"></param>
        void UpdateCollectionClearance(int num);



        /// <summary>
        /// sort acording to hostKey of Host and pring
        /// </summary>
        List<BE.Host> PrintHost();
        #endregion Host Fun;
        #region Order Fun;
        /// <summary>
        /// add order to date base 
        /// </summary>
        /// <param name="order"></param>
        void addOrder(BE.Order order);
        /// <summary>
        /// update order to date base 
        /// </summary>
        /// <param name="order"></param>
        void updateOrder(BE.Order order);

        ///<summary>
        ///sending Email
        /// </summary>
       

        #endregion  Order Fun;
        #region Hosting Unit fun;
        /// <summary>
        /// get all HostingUnit
        /// </summary>
        /// <returns></returns>
        IEnumerable<BE.HostingUnit> GetAllHostingUnit();
        IEnumerable<BE.Host> GetAllHost();
        /// <summary>
        /// apdate Hosting Unit to date base 
        /// </summary>
        /// <param name="hostingunit"></param>
        void apdateHostingUnit(BE.HostingUnit hostingunit);
        /// <summary>
        /// add Hosting Unit to date base 
        /// </summary>
        /// <param name="host"></param>
        void addHostingUnit(BE.HostingUnit hostingunit);
        /// <summary>
        /// delete Hosting Unit to date base 
        /// </summary>
        /// <param name="hostingunit"></param>
        void DeleteHostingUnit(BE.HostingUnit hostingunit);
        
        #endregion Hosting Unit fun;
        #region Guest Fun;
        /// <summary>
        /// sort acording to day of guest
        /// </summary>
        string Printdays();
        /// <summary>
        /// apdate GuestRequest to data base
        /// </summary>
        /// <param name="Gue"></param>
        void apdateGuestRequest(BE.GuestRequest Gue);
        /// <summary>
        /// gwt all guests
        /// </summary>
        /// <returns></returns>
        IEnumerable<BE.GuestRequest> GetAllGuest();
        //IEnumerable<BE.GuestRequest> GetAllGuest();
        /// <summary>
        /// get all order
        /// </summary>
        /// <returns></returns>
        IEnumerable<BE.Order> GetAllOrder();

        /// <summary>
        /// add GuestRequest to data base
        /// </summary>
        /// <param name="Gue"></param>
        void addGuestRequest(BE.GuestRequest Gue);
        ///// <summary>
        ///// return name of all guestRequest
        ///// </summary>
        ///// <returns></returns>
        //IEnumerable<string> GetGuest();

        /// <summary>
        /// sort acording to Private name of Guest and pring if children>0
        /// </summary>

       
        
        #endregion Guest Fun;
        #region Bank fun;
        /// <summary>
        /// get all Bank
        /// </summary>
        /// <returns></returns>
        IEnumerable<BE.BankAccount> GetAllBank();
		#endregion Bank fun;
		#region Clone Fun Get List
		List<BE.GuestRequest> GetGuestRequestList();
        List<BE.Order> GetOrderList();
        
        List<BE.BankAccount> GetBankList();
        List<BE.HostingUnit> GetHostingUnitList();
        List<BE.Host> GetHostList();
        #endregion Clone Fun Get List
        #region Function of password
        List<BE.Passworde> GetPasswordList();
        void updatePassword(BE.Passworde tmp, BE.Passworde tmp2);
        #endregion Function of password
       
    }
}
