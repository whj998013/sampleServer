using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SampleDataOper;

namespace SampleApi.Controllers
{
    public class KeyController : ApiController
    {
        [HttpPost]
        public object GetKeyNo(dynamic key)
        {
            string kv = (string)key.key;          
            return new { No=KeyMange.GetKey(kv) };
        }

        [HttpPost]
        public object GetKey2(Key key)
        {
            string kv = (string)key.key;
            string k = KeyMange.GetKey(kv);

            return new { No = k };
        }

    }

    public class Key
    {
        public string key { get; set; }
    }

}
