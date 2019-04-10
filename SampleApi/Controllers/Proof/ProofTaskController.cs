using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SG.SessionManage;
using SG.Model.Sys;
using SG.Model.Proof;
using ProofBLL;
using System.Web;
using SG.Utilities;

namespace SampleApi.Controllers.Proof
{
    [Author]
    public class ProofTaskController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetMyTasks()
        {

            ProofTaskOper pto = new ProofTaskOper(SessionManage.CurrentUser);
            var re = pto.GetMyProofTask();

            return Ok(re);

        }
        public IHttpActionResult GetTasks(string id)
        {
            ProofOrderOper poo = new ProofOrderOper(SessionManage.CurrentUser);
            var re = poo.GetProof(id);
            return Ok(re);
        }
        public IHttpActionResult UpLoadFile()
        {
            string webPath = HttpContext.Current.Server.MapPath("~") + Config.GetSampleConfig().ProofFilePath;
            string filePath = webPath + @"tempfile\";
            HttpFileCollection files = HttpContext.Current.Request.Files;
            string proofId = HttpContext.Current.Request.Form["ProofOrderId"];
            string TaskId = HttpContext.Current.Request.Form["TaskId"];
            string ProcessName = HttpContext.Current.Request.Form["ProcessName"];

            if (proofId != "")
            {
                string filename = "";
                foreach (string key in files.AllKeys)
                {
                    HttpPostedFile file = files[key];//file.ContentLength文件长度
                    if (string.IsNullOrEmpty(file.FileName) == false)
                    {
                        filename = proofId + "_" + DateTimeHelper.GetDataSecStr() + "_" + file.FileName;
                        UploadHelper.FileUpload(file, filePath, filename);
                    }
                }
                var re = new { name = filename, url = @"\src\proof\tempfile\" + filename };
                return Ok(re);
            }
            else return BadRequest("申请单号不能为空!");

        }
    }
}
