 using System;

namespace SG.Interface
{
    public interface IBaseModel
    {
        
        DateTime? CreateDate { get; set; }
        string CreateUser { get; set; }
        DateTime? EditDate { get; set; }
        string EditUser { get; set; }
        bool IsDelete { get; set; }
        string Remark { get; set; }
        void Delete(string user);
        void SetCreateUser(string user);
        void SetEditUser(string user);
        void UnDelete(string user);
    }
}