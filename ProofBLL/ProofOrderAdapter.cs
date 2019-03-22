using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SG.Model.Proof;
using SG.Model.Sys;
using SampleDataOper;
using SG.Interface.Sys;

namespace ProofBLL
{
    public class ProofOrderAdapter
    {
        private ProofOrder _proofOrder { get; set; } = new ProofOrder();
        private ProofStyle _proofSryle { get; set; } = new ProofStyle();
        private ProofObj _proofObj { get; set; }
        private User _user { get; set; }
        private SampleContext sc = new SampleContext();
        public ProofOrderAdapter(User user)
        {
            _user = user;
        }
        public bool CreateProofOrder(ProofObj obj)
        {
            if (CheckObj(obj))
            {
                _proofSryle.ProofStyleId = obj.ProofStyleId;
                _proofSryle.ProofType = DataQuery.GetSingle<ProofType>(p => p.TypeName == obj.ProofType);
                _proofSryle.ProofStyleNo = obj.ProofStyleNo;
                _proofSryle.ClentName = obj.ClentName;
                _proofSryle.ClientNo = obj.ClientNo;
                _proofSryle.StyleName = obj.StyleName;
                _proofSryle.Counts = obj.Counts;
                _proofSryle.Material = obj.Material;
                _proofSryle.Weight = obj.Weight;
                _proofSryle.Gauge = obj.Gauge;
                _proofSryle.ProofOrderId = obj.ProofOrderId;
                obj.FileListItems.ForEach(f =>
                {
                    ProofFile npf = new ProofFile
                    {
                        FullName = f.FullName,
                        DisplayName = f.Name,
                        Url = f.Url,
                        ProofStyleId = _proofSryle.ProofStyleId,
                        FileType = FileType.ClientFile
                    };
                    npf.SetCreateUser(_user.UserName);
                    _proofSryle.ProofFiles.Add(npf);

                });

                _proofOrder.ProofStyle = _proofSryle;
                _proofOrder.ProofOrderId = obj.ProofStyleId;
                _proofOrder.ProofApplyUserDdId = _user.DdId;
                _proofOrder.ProofApplyUserName = _user.UserName;
                _proofOrder.ProofApplyDeptName = _user.DepartName;
                _proofOrder.ProofStatus = ProofStatus.草拟;
                _proofOrder.RequiredDate = obj.FinshDate;
                _proofOrder.ProofNum = obj.ProofNum;
                _proofSryle.SetCreateUser(_user.UserName);
                _proofSryle.SetCreateUser(_user.UserName);
            }

            return true;
        }

        private bool CheckObj(ProofObj obj)
        {
            bool re = true;
            if (obj.ClentName == "" || obj.ProofStyleNo == "" || obj.ProofType == "" || obj.ProofNum < 1) re = false;
            if (obj.FileListItems.Count < 1) re = false;
            return re;
        }

        public bool SaveProofOrder()
        {
            sc.ProofStyles.Add(_proofSryle);
            sc.ProofOrders.Add(_proofOrder);
            sc.SaveChanges();
            return true;
        }

    }
}
