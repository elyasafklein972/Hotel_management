using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
   public enum Type { Zimmer,Hotel,Camping, Etc };
   public enum Area { All,North,South,Center,Jerusalem };
    public enum SubArea { תל_אביב,רחובות,באר_שבע,רמת_הגולן};
   // public enum StatusRequest { Active,DisActive};
    public enum StatusPool { לא_הכרחי,אפשרי,מעוניין };
    public enum StatusJacuzzi { לא_הכרחי, אפשרי, מעוניין };
    public enum StatusGarden { לא_הכרחי, אפשרי, מעוניין };
    public enum StatusChildrensAttractions { לא_הכרחי, אפשרי, מעוניין };
    
   public enum StatusGuest {טרם_טופל,פתוחה,נשלח_מייל,נסגר_מחוסר_הענות_של_הלקוח,נסגר_בהענות_של_הלקוח};

}
