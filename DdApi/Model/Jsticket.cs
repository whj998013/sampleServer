using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG.DdApi
{

    public class Jsticket
    {
        ///<summary>
        /// 
        /// </summary>
        public int Errcode { get; set; }

        ///<summary>
        /// 
        /// </summary>
        public string Errmsg { get; set; }
        
        ///<summary>
        /// 
        /// </summary>
        public string Ticket { get; set; }

        ///<summary>
        /// 
        /// </summary>

        public int Expires_In { get; set; }

    }

}
