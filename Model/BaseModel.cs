using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SG.Interface;

namespace SG.Model
{
    public abstract class BaseModel :  IBaseModel
    {
        public string Remark { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? EditDate { get; set; }
        public string CreateUser { get; set; }
        public string EditUser { get; set; }
        public bool IsDelete { get; set; }
        public void SetCreateUser(string user)
        {
            CreateUser = user;
            CreateDate = DateTime.Now;
        }
        public void SetEditUser(string user)
        {
            EditUser = user;
            EditDate = DateTime.Now;
            this.Remark = "编辑用户:" + user + "编辑时间:" + DateTime.Now.ToString() + ",";
        }
        public void Delete(string user)
        {
            IsDelete = true;           
            this.Remark = this.Remark + "删除用户:" + user + "删除时间:" + DateTime.Now.ToString() + ",";
        }

        public void UnDelete(string user)
        {
            IsDelete = false;
            this.Remark = this.Remark + "恢复删除用户:" + user + "恢复删除时间:" + DateTime.Now.ToString() + ",";
        }

    }
   
}
