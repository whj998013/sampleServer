using SG.DdApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SunginData;
using SG.DdApi.Approve;
using SG.Utilities;
using SG.Model.Proof;
using System.IO;
using System.Configuration;

namespace ProofBLL
{
    public class ProofOrderFinsh
    {
        private IDdOper _oper;
        SunginDataContext sdc = new SunginDataContext();

        public ProofOrderFinsh(IDdOper ddOper)
        {
            _oper = ddOper;
        }
        public string SysPath { get; set; }
        private readonly string PicPath = ConfigurationManager.AppSettings["ProofFilePath"] + "pic\\";
        public void AgreeFinsh(string pid)
        {
            ApproveOper ao = new ApproveOper(_oper);
            var re = ao.GetApprove(pid);
            var po = sdc.ProofOrders.SingleOrDefault(p => p.DdFinshApprovalCode == pid);
            if (po != null)
            {
                re.FormComponentValues.ForEach(p =>
                    {
                        if (p.Name == "评分")
                        {
                            int Rating = 3;
                            if (p.Value != null)
                            {
                                if (p.Value.IndexOf('1') > 0) Rating = 1;
                                else if (p.Value.IndexOf('2') > 0) Rating = 2;
                                else if (p.Value.IndexOf('3') > 0) Rating = 3;
                                else if (p.Value.IndexOf('4') > 0) Rating = 4;
                                else if (p.Value.IndexOf('5') > 0) Rating = 5;
                            };
                            po.Rating = Rating;
                            po.ProofTasks.ForEach(pt => pt.Rating = Rating);
                        }

                        if (p.Name == "样衣图片")
                        {
                            var picList = JsonHelper.JsonToList<string>(p.Value);
                            if (picList != null)
                            {
                                picList.ForEach(f =>
                                        {
                                            var fdata = HttpHelper.DownloadData(f);
                                            string name = f.Substring(f.LastIndexOf('/') + 1);
                                            string fullname = po.ProofStyle.ProofStyleId + "_" + name;
                                            File.WriteAllBytes(SysPath + PicPath + fullname, fdata);
                                            ProofFile pf = new ProofFile
                                            {
                                                FullName = fullname,
                                                DisplayName = name,
                                                Url = PicPath + fullname,
                                                FileType = SG.Interface.Sys.FileType.Pic,
                                                ProofStyleId = po.ProofStyle.ProofStyleId,
                                            };
                                            pf.SetCreateUser("钉钉审批");
                                            po.ProofStyle.ProofFiles.Add(pf);
                                        });

                            }


                        }

                    });
                po.ProofStatus = ProofStatus.完成;
                sdc.SaveChanges();
            }

        }

        public void RefuseFinsh(string pid)
        {
            var po = sdc.ProofOrders.SingleOrDefault(p => p.DdFinshApprovalCode == pid);
            po.ProofStatus = ProofStatus.打样中;
            sdc.SaveChanges();
            // throw new NotImplementedException();
        }
    }
}
