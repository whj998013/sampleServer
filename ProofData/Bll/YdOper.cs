﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SG.Model.Proof;
namespace ProofData.Bll
{
    public class YdOper
    {
        ProofDataContext pdc = new ProofDataContext();
        public string AddYd(ProofOrder proof)
        {
            try
            {
                var nyd = pdc.ypgl_yd.FirstOrDefault(p => p.proofId == proof.ProofOrderId);
                if (nyd == null)
                {
                    var obj = GetNewIdBh();
                     nyd = new ypgl_yd()
                    {
                        id = obj.id,
                        id_dept = 1,
                        dydbh = obj.dydbh,
                        id_kh = 0,
                        kh = proof.ProofStyle.ProofStyleNo,
                        km = proof.ProofStyle.StyleName,
                        cf = proof.ProofStyle.Material,
                        szi = proof.ProofStyle.Counts,
                        khkh = proof.ProofStyle.ClientNo,
                        cpz = (short)proof.ProofStyle.Weight,
                        yplb = proof.ProofStyle.ProofTypeText,
                        id_khb = new ClientOper().GetOrAddClient(proof.ProofStyle.ClentName),
                        rq_dj = proof.ReceivedDate == null ? DateTime.Now : (DateTime)proof.ReceivedDate,
                        rq_jh = proof.RequiredDate == null ? DateTime.Now : (DateTime)proof.RequiredDate,
                        ry_jb = "钉钉打样",
                        ry_gy = "",
                        ry_zb = "",
                        ry_sj = "",
                        ry_yw = proof.ProofApplyUserName,
                        zx = proof.ProofStyle.Gauge,
                        tprq = proof.CreateDate == null ? DateTime.Now : (DateTime)proof.CreateDate,
                        tkbz = 0,
                        gytprq = DateTime.Now,
                        proofId = proof.ProofOrderId,
                    };
                    pdc.ypgl_yd.Add(nyd);
                }
                else
                {
                    nyd.kh = proof.ProofStyle.ProofStyleNo;
                    nyd.km = proof.ProofStyle.StyleName;
                    nyd.cf = proof.ProofStyle.Material;
                    nyd.szi = proof.ProofStyle.Counts;
                    nyd.khkh = proof.ProofStyle.ClientNo;
                    nyd.cpz = (short)proof.ProofStyle.Weight;
                    nyd.yplb = proof.ProofStyle.ProofTypeText;
                    nyd.id_khb = new ClientOper().GetOrAddClient(proof.ProofStyle.ClentName);
                    nyd.rq_dj = proof.ReceivedDate == null ? DateTime.Now : (DateTime)proof.ReceivedDate;
                    nyd.rq_jh = proof.RequiredDate == null ? DateTime.Now : (DateTime)proof.RequiredDate;
                    nyd.ry_yw = proof.ProofApplyUserName;
                    nyd.zx = proof.ProofStyle.Gauge;
                    nyd.tprq = proof.CreateDate == null ? DateTime.Now : (DateTime)proof.CreateDate;
                    nyd.proofId = proof.ProofOrderId;
                   
                }

                pdc.SaveChanges();
                return nyd.dydbh;
            }
            catch
            {
                return "";
            }


        }

        public dynamic GetNewIdBh()
        {

            int bigId = pdc.ypgl_yd.Max(p => p.id);
            var obj = pdc.ypgl_yd.SingleOrDefault(p => p.id == bigId).dydbh.Split('-');
            string y = "Y" + DateTime.Now.Year.ToString().Substring(2, 2);
            int newBh = int.Parse(obj[1]) + 1;
            string dydbh = y + "-" + newBh;
            while (pdc.ypgl_yd.Count(p => p.dydbh == dydbh) > 0)
            {
                newBh++;
                dydbh = y + "-" + newBh;
            }

            return new { id = ++bigId, dydbh };

        }
    }
}
