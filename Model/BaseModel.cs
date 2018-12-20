using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SG.Interface;
namespace SG.Model
{
  
    public abstract class BaseModel :  IBaseModel
    {
        [JsonIgnore]
        public string OperRemark { get; set; }
        [JsonIgnore]
        public DateTime? CreateDate { get; set; }
        [JsonIgnore]
        public DateTime? EditDate { get; set; }
        [JsonIgnore]
        public string CreateUser { get; set; }
        [JsonIgnore]
        public string EditUser { get; set; }
        [JsonIgnore]
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
            this.OperRemark = "编辑用户:" + user + "编辑时间:" + DateTime.Now.ToString() + ",";
        }
        public void Delete(string user)
        {
            IsDelete = true;           
            this.OperRemark = this.OperRemark + "删除用户:" + user + "删除时间:" + DateTime.Now.ToString() + ",";
        }

        public void UnDelete(string user)
        {
            IsDelete = false;
            this.OperRemark = this.OperRemark + "恢复删除用户:" + user + "恢复删除时间:" + DateTime.Now.ToString() + ",";
        }

    }
   
}
