using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SampleApi.Controllers.Stock
{



    public class WarehouseController : ApiController
    {
        // GET: api/Warehouse
        // [Route("Warehouse")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2", "value3" };
        }

        // GET: api/Warehouse/5
        public string Get(string id)
        {
            return "value" + id;
        }

        // POST: api/Warehouse
        public IHttpActionResult Post([FromBody] object value)
        {
            return Ok(value);
        }

        // PUT: api/Warehouse/5
        public IHttpActionResult Put(int id, [FromBody]JObject value)
        {
           string? old=(string?)value.GetValue("addr");
           
            
            
            

            return Ok(old);
        }

        // DELETE: api/Warehouse/5
        public void Delete(int id)
        {
        }
               
    }
}
