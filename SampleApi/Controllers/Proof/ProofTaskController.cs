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
using ProofData.Bll;

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
        public IHttpActionResult SubmitTask(dynamic request)
        {
            string taskId = request.TaskId;
            string proofId = request.ProofId;
            if (taskId == "" || proofId == "") return BadRequest();
            return Ok();
        }
        [HttpGet]
        public IHttpActionResult DeleteTask(string id)
        {
            if (id != "")
            {
                int Id = int.Parse(id);
                ProofTaskOper pto = new ProofTaskOper(SessionManage.CurrentUser);
                if (pto.DeleteTask(Id))
                {
                    pto.SaveChanges();
                    return Ok();
                }
                else
                {
                    return NotFound();
                }

            }
            else return BadRequest();


        }

        public IHttpActionResult UpdateTask(Task task)
        {
            ProofTaskOper pto = new ProofTaskOper(SessionManage.CurrentUser);
            var pt = pto.UpDateTask(task);
            if (pt != null)
            {
                //更新打样管理系统信息
                if (task.ProcessName == "工艺") new GyOper().AddOrUpdataGlRecord(pt);
                return Ok();
            }
            return NotFound();
        }

        public IHttpActionResult AddTask(Task task)
        {
            ProofTaskOper pto = new ProofTaskOper(SessionManage.CurrentUser);
            var pt = pto.AddTask(task);
            if (pt != null)
            {
                if (task.ProcessName == "工艺") new GyOper().AddOrUpdataGlRecord(pt);
                return Ok();
            }
            return BadRequest();
        }

        [HttpGet]
        public IHttpActionResult DeleteTaskFile(string id)
        {
            if (id != "")
            {
                int fid = int.Parse(id);
                if (new ProofFileOper(SessionManage.CurrentUser).DeleteProofFile(fid))
                    return Ok("ok");
                else return NotFound();
            }
            else
            {
                return BadRequest("请传送ID");
            }

        }
        public IHttpActionResult UpLoadFile()
        {
            string webPath = HttpContext.Current.Server.MapPath("~") + Config.GetSampleConfig().ProofFilePath;
            string filePath = webPath + @"gyzb\";
            HttpFileCollection files = HttpContext.Current.Request.Files;
            string proofId = HttpContext.Current.Request.Form["ProofOrderId"];
            string TaskId = HttpContext.Current.Request.Form["TaskId"];
            string ProcessName = HttpContext.Current.Request.Form["ProcessName"];
            ProofFile pf = new ProofFile();
            if (proofId != "" && TaskId != "" && ProcessName != "")
            {
                string filename = "";
                string url = "";
                foreach (string key in files.AllKeys)
                {
                    HttpPostedFile file = files[key];//file.ContentLength文件长度
                    if (string.IsNullOrEmpty(file.FileName) == false)
                    {
                        string DisplayName = file.FileName;
                        filename = proofId + "_" + ProcessName + "_" + DateTimeHelper.GetDataSecStr() + "_" + file.FileName;
                        UploadHelper.FileUpload(file, filePath, filename);
                        url = @"\src\proof\gyzb\" + filename;
                        ProofTaskOper pto = new ProofTaskOper(SessionManage.CurrentUser);
                        int tid = int.Parse(TaskId);
                        pf = pto.AddProofFile(tid, proofId, filename, DisplayName, url, ProcessName);
                    }
                }

                return Ok(pf);
            }
            else return BadRequest("上传文件参数错误!");

        }
    }
}
