using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SG.Model.Sys;
namespace SG.Model.Sys
{
    public class Worker:BaseModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        /// <summary>
        /// 岗位
        /// </summary>
        public Job Job { get; set; }
        
        /// <summary>
        /// 部门名
        /// </summary>
        public string DeptName { get; set; }

        /// <summary>
        /// 头像
        /// </summary>
        public string Avatar { get; set; }
        /// <summary>
        /// 关联的用户名，如无则为工厂人员
        /// </summary>
        public  User User { get; set; }
        /// <summary>
        /// 关联的用户组名，如无，则为工厂人员
        /// </summary>
        public Role Role { get; set; }
        /// <summary>
        /// 工作者评分
        /// </summary>
        public float Point { get; set; }

        
        
    }
}
