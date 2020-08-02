using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace BE
{
    public class HostingUnit
    {
        public Host Owner { get; set; }
        public Area Area { get; set; }
         public string HostingUnitName { get; set; }
        [XmlIgnore]
        public bool[,] Diary
        {
            get;

            set;
            
        
        }
        public HostingUnit GetCopy()
        {
            return (HostingUnit)this.MemberwiseClone();
        }
        public override string ToString()
        {
            return string.Format("Owner: {0}\n", Owner) +
              string.Format("Hosting Unit Name: {0}\n", HostingUnitName) +
            //  string.Format("Diary: {0}\n", Diary) +
              string.Format("Hostingunit key: {0}\n", Hostingunitkey);
        }
        //optional. tell the XmlSerializer to name the Array Element as'Board'
        // instead of 'BoaredDto'
        [XmlArray("Diary")]
        public bool[] BoardDto
        {
            get { return Diary.Flatten(); }
            set { Diary = value.Expand(12); } //12 is the number of roes in the matrix
        }
        public int Hostingunitkey { get; set; }
        public HostingUnit()
        {
           
            Hostingunitkey = ++Configuration.HostingUnitKey;
            
        Diary = new bool[12, 31];

            for (int i = 0; i < 12; i++)
                for (int j = 0; j < 31; j++)
                {
                    Diary[i, j] = false;
                }
        }
   

    /// <summary>
    /// indexer
    /// </summary>
    /// <param name="d"></param>
    /// <returns></returns>

    private bool this[DateTime d]
    {
        get => Diary[d.Day - 1, d.Month - 1];

    }
        public HostingUnit(Host a, Area b, string c, int e,bool[,] Diary2)
        {
            Owner = a;
            Area = b;
            HostingUnitName = c;
          
            Hostingunitkey = e;
            Diary = new bool[12, 31];

            for (int i = 0; i < 12; i++)
                for (int j = 0; j < 31; j++)
                {
                    Diary[i, j] = Diary2[i,j];
                }
        }
    }
}

