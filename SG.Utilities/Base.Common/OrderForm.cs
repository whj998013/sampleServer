using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace SG.Utilities
{
    public class SNO
    {


        public static string GetFormCode(string code)
        {
            string formcode = code;
            formcode += DateTime.Now.Year.ToString();
            formcode += DateTime.Now.Month.ToString().Length == 1 ? "0" + DateTime.Now.Month.ToString() : DateTime.Now.Month.ToString();
            formcode += DateTime.Now.Day.ToString().Length == 1 ? "0" + DateTime.Now.Day.ToString() : DateTime.Now.Day.ToString();
            formcode += DateTime.Now.Hour.ToString().Length == 1 ? "0" + DateTime.Now.Hour.ToString() : DateTime.Now.Hour.ToString();
            formcode += DateTime.Now.Minute.ToString().Length == 1 ? "0" + DateTime.Now.Minute.ToString() : DateTime.Now.Minute.ToString();
            formcode += DateTime.Now.Second.ToString().Length == 1 ? "0" + DateTime.Now.Second.ToString() : DateTime.Now.Second.ToString();
            if (DateTime.Now.Millisecond.ToString().Length == 1)
            {
                formcode += "00" + DateTime.Now.Millisecond.ToString();
            }
            else if (DateTime.Now.Millisecond.ToString().Length == 2)
            {
                formcode += "0" + DateTime.Now.Millisecond.ToString();
            }
            else
            {
                formcode += DateTime.Now.Millisecond.ToString();
            }           

            return  formcode;
        }
    }
}
