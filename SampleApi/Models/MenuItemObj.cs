using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleApi.Models
{
    public class MenuObj
    {
        public string Name { get; set; }
        public string Cname { get; set; }
        public string Icon { get; set; }
        public string Key { get; set; }

        public List<ItmeObj> Items { get; set; } = new List<ItmeObj>();
    }

    public class ItmeObj
    {
        public string Name { get; set; }

        public string Cname { get; set; }
        public string Url { get; set; }
        public string Key { get; set; }
    }
}