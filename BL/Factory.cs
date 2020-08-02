using System;
using System.Collections.Generic;
using System.Text;

namespace BL
{
    static public class Factory
    {
        static IBL instance = null;
        public static IBL GetInstance()
        {
            if(instance==null)
            instance =new BL_Imp();
            return instance;
        }
    }
}
