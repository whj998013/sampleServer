using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SG.Model.Proof;
using SG.Model.Sys;
using SunginData;
using System.Data.Entity;

namespace ProofBLL
{
    public class ProofOrderOper:IDisposable
    {
        private User _user;
        public SunginDataContext Sdc { get; set; } = new SunginDataContext();
        public ProofOrderOper(User user)
        {
            _user = user;
            
        }

        /// <summary>
        /// 完成打样，并提交审批
        /// </summary>
        /// <returns></returns>
        public ProofOrder FinshProof(string proofOrderid)
        {
            ProofOrder po = Sdc.ProofOrders.SingleOrDefault(p => p.ProofOrderId == proofOrderid);
            if (po.ProofStatus != ProofStatus.打样中) throw new Exception("当前订单未在打样状态，无法提交交样审批");
            if (po == null) return null;
            po.ProofTasks.ForEach(p =>
            {
                p.FinshDate = DateTime.Now;
                p.Stats = SG.Model.Stats.终止;
                p.OperRemark = "订单完成，主动终止任务";
            });
            po.ProofStatus = ProofStatus.交样;
            return po;

        }
        /// <summary>
        /// 分页读取打样订单信息表
        /// </summary>
        /// <param name="Count"></param>
        /// <param name="whereLambda"></param>
        /// <param name="orderbyLamba"></param>
        /// <param name="PageId"></param>
        /// <param name="PageSize"></param>
        /// <returns></returns>
        public List<ProofOrder> GetProofListDesc(out int Count, Func<ProofOrder, bool> whereLambda, Func<ProofOrder, object> orderbyLamba, int PageId, int PageSize)
        {
            Count = Sdc.ProofOrders.Where(whereLambda).Count();
            List<ProofOrder> list = Sdc.ProofOrders.Where(whereLambda).OrderByDescending(orderbyLamba).ThenByDescending(p => p.Id).ToList();
            RemoveDeleteFile(list);
            return list;
        }
        /// <summary>
        /// 取得当前用户完成打样信息
        /// </summary>
        /// <returns></returns>
        public List<ProofOrder> GetUserFineshProofOrderList()
        {

            List<ProofOrder> poList = new List<ProofOrder>();
            poList = Sdc.ProofOrders.Include(t => t.ProofStyle).Include(t => t.ProofStyle.ProofFiles).Include(t => t.ProofStyle.ProofType).Where(p => p.ProofApplyUserDdId == _user.DdId && p.ProofStatus == ProofStatus.完成 && !p.IsDelete).OrderByDescending(p => p.CreateDate).ToList();
            RemoveDeleteFile(poList);
            return poList;
        }

        public void RemoveDeleteFile(List<ProofOrder> po)
        {
            po.ForEach(p =>
            {
                p.ProofStyle.ProofFiles = p.ProofStyle.ProofFiles.Where(t => !t.IsDelete).ToList();
            });
        }
        /// <summary>
        /// 取得当前用户未完成打样信息
        /// </summary>
        /// <returns></returns>

        public List<ProofOrder> GetUserProofOrderList()
        {

            List<ProofOrder> poList = new List<ProofOrder>();
            poList = Sdc.ProofOrders.Include(t=>t.YarnApplys).Include(t => t.ProofStyle).Include(t=>t.ProofDept).Include(t => t.ProofStyle.ProofFiles).Include(t => t.ProofStyle.ProofType).Where(p => p.ProofApplyUserDdId == _user.DdId && p.ProofStatus != ProofStatus.完成 && !p.IsDelete).OrderByDescending(p => p.CreateDate).ToList();
            RemoveDeleteFile(poList);
            return poList;
        }


        public ProofOrder GetProof(string proofOrderId)
        {

            ProofOrder po = Sdc.ProofOrders.Include(t => t.ProofTasks).Include(t => t.ProofStyle).Include(t => t.ProofStyle.ProofType).Where(p => p.ProofOrderId == proofOrderId).SingleOrDefault();
            if (po != null)
            {
                Sdc.Entry(po.ProofStyle).Collection(t => t.ProofFiles).Query().Where(t => !t.IsDelete).Load();
                Sdc.Entry(po).Collection(t => t.ProofTasks).Query().Include(t => t.Process).Include(t => t.Worker).Load();
                po.ProofTasks = po.ProofTasks.Where(p => !p.IsDelete).ToList();
            }

            return po;
        }
        public bool DeleteProof(string proofOrderId)
        {
            ProofOrder po = Sdc.ProofOrders.Include(t => t.ProofStyle).Include(t => t.ProofStyle.ProofFiles).Include(t => t.ProofStyle.ProofType).Where(p => p.ProofOrderId == proofOrderId).SingleOrDefault();
            po.Delete(_user.UserName);
            po.ProofStyle.Delete(_user.UserName);
            po.ProofStyle.ProofFiles.ForEach(p =>
            {
                p.Delete(_user.UserName);
            });
            // Sdc.SaveChanges();

            return true;
        }
        public void SetApprove(ProofOrder po, string ddApprovalCode)
        {
            po.DdApprovalCode = ddApprovalCode;
            po.ProofStatus = ProofStatus.审批;
            //  Sdc.SaveChanges();
        }

        public void SetFinshApprove(ProofOrder po, string ddApprovalCode)
        {
            po.DdFinshApprovalCode = ddApprovalCode;
            po.ProofStatus = ProofStatus.交样;
            // Sdc.SaveChanges();
        }
        public void SaveChange()
        {
            Sdc.SaveChanges();
        }

        #region IDisposable Support
        private bool disposedValue = false; // 要检测冗余调用

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: 释放托管状态(托管对象)。
                }

                // TODO: 释放未托管的资源(未托管的对象)并在以下内容中替代终结器。
                // TODO: 将大型字段设置为 null。
                Sdc.Dispose();
                disposedValue = true;
            }
        }

        // TODO: 仅当以上 Dispose(bool disposing) 拥有用于释放未托管资源的代码时才替代终结器。
        // ~ProofOrderOper()
        // {
        //   // 请勿更改此代码。将清理代码放入以上 Dispose(bool disposing) 中。
        //   Dispose(false);
        // }

        // 添加此代码以正确实现可处置模式。
        public void Dispose()
        {
            // 请勿更改此代码。将清理代码放入以上 Dispose(bool disposing) 中。
            Dispose(true);
            // TODO: 如果在以上内容中替代了终结器，则取消注释以下行。
            // GC.SuppressFinalize(this);
        }
        #endregion


    }
}
