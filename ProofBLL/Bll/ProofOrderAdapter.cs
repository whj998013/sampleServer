﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SG.Model.Proof;
using SG.Model.Sys;
using SampleDataOper;
using SG.Interface.Sys;
using System.Data.Entity;
namespace ProofBLL
{
    public class ProofOrderAdapter
    {

        private ProofObj _proofObj { get; set; }
        private User _user { get; set; }
        private SunginDataContext sdc = new SunginDataContext();
        public ProofOrderAdapter(User user)
        {
            _user = user;
        }
        public bool CreateProofOrder(ProofObj obj)
        {
            ProofOrder _proofOrder = new ProofOrder();
            ProofStyle _proofSryle = new ProofStyle();
            if (CheckObj(obj))
            {
                _proofSryle.ProofStyleId = obj.ProofStyleId;
                _proofSryle.ProofType = sdc.ProofTypes.SingleOrDefault(p => p.TypeName == obj.ProofType);
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
                        DisplayName = f.DisplayName,
                        Url = f.Url,
                        ProofStyleId = _proofSryle.ProofStyleId,
                        FileType = FileType.ClientFile
                    };
                    npf.SetCreateUser(_user.UserName);
                    _proofSryle.ProofFiles.Add(npf);

                });

                _proofOrder.ProofStyle = _proofSryle;
                _proofOrder.ProofOrderId = obj.ProofOrderId;
                _proofOrder.ProofApplyUserDdId = _user.DdId;
                _proofOrder.DesignatedCX = obj.DesignatedCX;
                _proofOrder.DesignatedGY = obj.DesignatedGY;
                _proofOrder.Remark = obj.Remark;
                _proofOrder.Urgency = obj.Urgency;
                _proofOrder.ProofApplyUserName = _user.UserName;
                _proofOrder.ProofApplyDeptName = _user.DepartName;
                _proofOrder.ProofStatus = ProofStatus.草拟;
                _proofOrder.RequiredDate = obj.FinshDate;
                _proofOrder.ProofNum = obj.ProofNum;
                _proofSryle.SetCreateUser(_user.UserName);
                _proofOrder.SetCreateUser(_user.UserName);
            }
            sdc.ProofStyles.Add(_proofSryle);
            sdc.ProofOrders.Add(_proofOrder);
            return true;
        }

        public bool UpdateProofOrder(ProofObj obj)
        {
            ProofOrder po = sdc.ProofOrders.Include(t => t.ProofStyle).Include(t => t.ProofStyle.ProofFiles).Include(t => t.ProofStyle.ProofType).Where(p => p.ProofOrderId == obj.ProofOrderId).SingleOrDefault();

            if (po != null)
            {
                ProofOrder _proofOrder = po;
                ProofStyle _proofSryle = po.ProofStyle;
                if (CheckObj(obj))
                {
                    _proofSryle.ProofStyleId = obj.ProofStyleId;
                    _proofSryle.ProofType = sdc.ProofTypes.SingleOrDefault<ProofType>(p => p.TypeName == obj.ProofType);
                    _proofSryle.ProofStyleNo = obj.ProofStyleNo;
                    _proofSryle.ClentName = obj.ClentName;
                    _proofSryle.ClientNo = obj.ClientNo;
                    _proofSryle.StyleName = obj.StyleName;
                    _proofSryle.Counts = obj.Counts;
                    _proofSryle.Material = obj.Material;
                    _proofSryle.Weight = obj.Weight;
                    _proofSryle.Gauge = obj.Gauge;
                    _proofSryle.ProofOrderId = obj.ProofOrderId;

                    _proofSryle.ProofFiles.ForEach(f =>
                    {
                        if (obj.FileListItems.Count(p => p.Id == f.Id) == 0) f.Delete(_user.UserName);

                    });

                    obj.FileListItems.ForEach(f =>
                    {
                        if (f.Id == 0)
                        {
                            ProofFile npf = new ProofFile
                            {
                                FullName = f.FullName,
                                DisplayName = f.DisplayName,
                                Url = f.Url,
                                ProofStyleId = _proofSryle.ProofStyleId,
                                FileType = FileType.ClientFile
                            };
                            npf.SetCreateUser(_user.UserName);
                            _proofSryle.ProofFiles.Add(npf);
                        }


                    });
                    _proofOrder.ProofOrderId = obj.ProofOrderId;
                    _proofOrder.ProofApplyUserDdId = _user.DdId;
                    _proofOrder.ProofApplyUserName = _user.UserName;
                    _proofOrder.ProofApplyDeptName = _user.DepartName;
                    _proofOrder.DesignatedCX = obj.DesignatedCX;
                    _proofOrder.DesignatedGY = obj.DesignatedGY;
                    _proofOrder.Remark = obj.Remark;
                    _proofOrder.Urgency = obj.Urgency;
                    _proofOrder.ProofStatus = ProofStatus.草拟;
                    _proofOrder.RequiredDate = obj.FinshDate;
                    _proofOrder.ProofNum = obj.ProofNum;
                    _proofSryle.SetEditUser(_user.UserName);
                    _proofOrder.SetEditUser(_user.UserName);
                }

                return true;

            }
            return false;
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

            sdc.SaveChanges();
            return true;
        }

    }
}
