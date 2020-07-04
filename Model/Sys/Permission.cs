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
        public string UpKey { get; set; }
        /// <summary>
        /// 权限名 sample_new_add,样品_新样品_新增
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 中文名
        /// </summary>
        public string CnName { get; set; }

        /// <summary>
        /// 图标
        /// </summary>
        public string Icon { get; set; }

        /// <summary>
        /// 跳转地址
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// 权限点类型
        /// </summary>
        public PermissionType Type { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int Px { get; set; }
    }

    public enum PermissionType
    {
        Menu=0,
        Item=1,
        From=2,
        Point=3
    }


}
