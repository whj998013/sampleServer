using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleApi.Models
{
    public class SaveRolesObj
    {
        public long RoleId { get; set; }
        public List<string> PermissionKey { get; set; } 
    }
}