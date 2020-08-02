using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
    public class Passworde
    {
        public string User { get; set; }
        public string Password { get; set; }

      public Passworde() {

         
        }

      public Passworde(string username,string code)
        {
            User = username;
            Password = code;
        }

    }
}
