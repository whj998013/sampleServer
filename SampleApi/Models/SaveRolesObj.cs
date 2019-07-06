using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SG.Model.Sys;

namespace SampleApi.Models
{
    public class SaveRolesObj
    {
        public Role Role { get; set; }
        public List<string> PermissionKey { get; set; } 
    }
}