using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using SG.Utilities;
using SysBLL;
using SampleApi.Models;
using SG.Model.Proof;
using ProofBLL;
using SG.SessionManage;
using SG.Model.Sys;


namespace SampleApi.Controllers.Proof
{
    [Author]
    public class NewProofController : ApiController
    {
        public IHttpActionResult GetProofNo()
        {
            string newProofOrderId = KeyMange.GetKey("ProofOrder");
            string newProofStyleId = KeyMange.GetKey("ProofStyle");

            return Ok(new { newProofOrderId, newProofStyleId });
        }
        public IHttpActionResult UpLoadFile()
        {
            string webPath = HttpContext.Current.Server.MapPath("~") + Config.GetSampleConfig().ProofFilePath;
            string filePath = webPath + @"tempfile\";
            HttpFileCollection files = HttpContext.Current.Request.Files;
            string proofId = HttpContext.Current.Request.Form["ProofStyleId"];
            string filename = "";
            foreach (string key in files.AllKeys)
            {
                HttpPostedFile file = files[key];//file.ContentLength文件长度
                if (string.IsNullOrEmpty(file.FileName) == false)
                {
                    filename = proofId + "_" + file.FileName;
                    UploadHelper.FileUpload(file, filePath, filename);
                }
            }
            var re = new { name = filename, url = @"\src\proof\tempfile\" + filename };
            return Ok(re);
        }
        public IHttpActionResult RemoveFile(FileItemModel obj)
        {
            if (obj != null)
            {
                string webPath = HttpContext.Current.Server.MapPath("~") + Config.GetSampleConfig().ProofFilePath;

                bool re = DirFileHelper.DeleteFile(webPath + obj.Url);
                if (!re) return NotFound();
                return Ok();
            }
            else return BadRequest();
        }

        public IHttpActionResult SaveProof(ProofObj obj)
        {
            User u = SessionManage.CurrentUser;
            if (u != null)
            {
                string webPath = Config.GetSampleConfig().ProofFilePath;
                ProofOrderAdapter poa = new ProofOrderAdapter(u);
                poa.CreateProofOrder(obj);
                obj.FileListItems.ForEach(p =>
                {
                    string path1 = p.Url;
                    string path2 = webPath + @"gy\" + p.FullName;
                    DirFileHelper.MoveFile(path1, path2);
                    p.Url = path2;

                });
                poa.SaveProofOrder();
               
            }

            return Ok();
        }
    }
}
