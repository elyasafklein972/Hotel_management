using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Mail;
namespace BL
{
    public interface IBL
    {
        #region HostingUnitFun
        /// <summary>
        /// rturn Hosting unit whith order
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        BE.HostingUnit rHosting(BE.Order order);
        /// <summary>
        /// rturn Hosting unit whith num
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        BE.HostingUnit rHosting(int t);
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
        /// <summary>
        /// apdate Hosting Unit to date base 
        /// </summary>
        /// <param name="hostingunit"></param>
        void apdateHostingUnit(BE.HostingUnit hostingunit);
        /// <summary>
        /// retutn the List hosts
        /// </summary>
        /// <returns></returns>
        List<BE.Host> GetHostList();
        /// <summary>
        /// Group according to num of HostingUnit of Host
        /// </summary>
        /// <returns></returns>
        IEnumerable<BE.HostingUnit> HostingUnitArea();
        /// <summary>
        /// Group according to num of HostingUnit of Host
        /// </summary>
        /// <returns></returns>
        List<BE.Host> HostingUnitnums();


        /// <summary>
        /// Group according to key of HostingUnit 
        /// </summary>
        /// <returns></returns>
        List<BE.HostingUnit> HostingUnitkey();

        /// <summary>
        /// return all hosting unit with free day 
        /// </summary>
        /// <param name="t"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        IEnumerable<BE.HostingUnit> GetoptionHost(DateTime t, int num);
        /// <summary>
        /// get all HostingUnit
        /// </summary>
        /// <returns></returns>
        IEnumerable<BE.HostingUnit> GetAllHostingUnit();
        /// <summary>
        /// to Update Collection Clearance
        /// </summary>
        /// <param name="num"></param>
        void UpdateCollectionClearance(int num);








        #endregion HostingUnitFun
        #region Host
        /// <summary>
        /// return all host list
        /// </summary>
        /// <returns></returns>
        IEnumerable<BE.Host> GetAllHost();





        #endregion Host
        #region GuestRequest
        /// <summary>
        /// return the guest request and hostingUnit of the order
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        BE.GuestRequest rGuest(BE.Order order);

        BE.GuestRequest rGuest(int t);
        /// <summary>
        /// sort acording to Private name of Guest and pring if children>0
        /// </summary>

       

        /// <summary>
        /// sort acording to hostKey of Host and pring
        /// </summary>
        List<BE.Host> PrintHost();

        /// <summary>
        /// sort acording to day of guest
        /// </summary>
        string Printdays();
        /// <summary>
        /// add GuestRequest to data base
        /// </summary>
        /// <param name="Gue"></param>
        void addGuestRequest(BE.GuestRequest Gue);
        /// <summary>
        /// apdate GuestRequest to data base
        /// </summary>
        /// <param name="Gue"></param>
        void apdateGuestRequest(BE.GuestRequest Gue);
        // delegate bool checkIf(BE.GuestRequest x);
        /// <summary>
        /// retrun all orders of tmp Key
        /// </summary>
        /// <param name="tmp"></param>
        /// <returns></returns>
        IEnumerable<BE.Order> GetGuest(BE.GuestRequest tmp);
        /// <summary>
        /// Group according to area of guest
        /// </summary>
        /// <returns></returns>
        IEnumerable<BE.GuestRequest> GrouGuestArea();
        /// <summary>
		/// Group according to num of guest of guest
		/// </summary>
		/// <returns></returns>
		IEnumerable<BE.GuestRequest> GrouGuestnums();
        /// <summary>
        /// gwt all guests
        /// </summary>
        /// <returns></returns>
        IEnumerable<BE.GuestRequest> GetAllGuest();


        List<BE.GuestRequest> GetChild();




        #endregion GuestRequest
        #region Order
        /// <summary>
        /// return the Commission 
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        int rCommission(int a);

        /// <summary>
        /// add order to date base 
        /// </summary>
        /// <param name="order"></param>
        void addOrder(BE.Order order);
        /// <summary>
        /// apdate order to date base 
        /// </summary>
        /// <param name="order"></param>
        void updateOrder(BE.Order order);


        /// <summary>
        /// get all order
        /// </summary>
        /// <returns></returns>
        IEnumerable<BE.Order> GetAllOrder();
        /// <summary>
        /// get all Bank
        /// </summary>
        /// <returns></returns>
        IEnumerable<BE.BankAccount> GetAllBank();

        /// <summary>
        /// return the order according to num key
        /// </summary>
        /// <param name="days"></param>
        /// <returns></returns>
        IEnumerable<BE.Order> rorders(int days);




        /// <summary>
        /// reutrn sub to Date or sub tooday to order
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>

        int rDay(params DateTime[] d);

        ///<returns>
        /// <summary>
        /// send email
        /// </returns>
        void SendingEmail(BE.Order order);

        #endregion Order
        #region Password
        List<BE.Passworde> GetPasswordList();
        void updatePassword(BE.Passworde tmp, BE.Passworde tmp2);
        #endregion Password
        void CheckGuest();

    }
}
