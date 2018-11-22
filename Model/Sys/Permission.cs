using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SG.Interface.Sys;
namespace SG.Model.Sys
{
    /// <summary>
    /// 权限点
    /// </summary>
    public class Permission : IPermission
    {
        public int Id { get; set; }
        /// <summary>
        /// 权限Key
        /// </summary>
        public string Key { get; set; }
        /// <summary>
        /// 上级权限点
        /// </summary>
        public int UpId { get; set; }
        /// <summary>
        /// 权限名 sample_new_add,样品_新样品_新增
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 中文名
        /// </summary>
        public string CnName { get; set; }
        
    }
      
}
