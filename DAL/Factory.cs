using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace DAL
{
    static public class Factory
    {
        static IDAL instance = null;
        public static IDAL GetInstance()//to xml
        {
            if (instance == null)
                instance= new DAL_XML_imp();
            return instance;
        }
        public static IDAL GetList()//to List
        {
            if (instance == null)
                instance = new Dal_Imp();
            return instance;
        }
    }
}
