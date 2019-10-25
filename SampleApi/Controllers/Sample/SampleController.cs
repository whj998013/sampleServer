using SunginData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SG.SessionManage;
using System.Web;
using System.IO;
using SG.Utilities;
using System.Linq.Expressions;
using SampleBLL;
using SampleBLL.Model;
using SG.Interface.Sample;
using SG.Interface.Sys;
using SG.Model.Sys;
using SysBLL;
namespace SampleApi.Controllers.Sample
{

    [Author]
    public class SampleController : ApiController
    {
        [HttpPost]
        public object GetSampleList(SeachObjSample seachObj)
        {


            var exp = PredicateBuilder.True<ISampleBaseInfo>().And(p => !p.IsDelete && (int)p.State > 2);
            if (seachObj.State != SampleState.所有)
            {
                exp = exp.And(p => p.State == seachObj.State);
            };
            if (seachObj.BeginDate != null && seachObj.EndDate != null)
            {
                var d1 = (DateTime)seachObj.BeginDate;
                var d2 = ((DateTime)seachObj.EndDate).AddDays(1);
                exp = exp.And(p => p.CreateDate >= d1 & p.CreateDate < d2);
            };
            if (seachObj.Key != null && seachObj.Key != "")
            {
                exp = exp.And(p => p.SeachStr.Contains(seachObj.Key));
            }
            var expc = exp.Compile();
            var re = SampleOper.GetSampleListOrderByDesc(expc, t => t.State, seachObj.PageId, seachObj.PageSize);
            return Ok(re);
        }
        [HttpGet]
        public object GetSample([FromUri]string styleId)
        {
            if (styleId != "")
            {
                var obj = SampleOper.GetSample(styleId);
                if (obj != null)
                {
                    return Ok(obj);
                }
                else return BadRequest("找到不指定ID的样衣信息");
            }
            return NotFound();
        }
        [HttpGet]
        public IHttpActionResult GetSampleInfo(string Id)
        {
            if (Id != "")
            {
                var obj = SampleOper.GetSampleInfo(Id);
                if (obj != null)
                {
                    return Ok(obj);
                }
                else return BadRequest("找到不指定ID的样衣信息");
            }
            return NotFound();

        }

        [HttpGet]
        public object GetEditSample([FromUri]string styleId)
        {
            if (styleId != "")
            {
                var obj = SampleOper.GetSample(styleId);
                if (obj != null)
                {
                    SessionManage.CurrentSample = new SampleInfo(SessionManage.CurrentUser);
                    SessionManage.CurrentSample.LoadSampleById(styleId);

                    return Ok(obj);
                }
                else return BadRequest("找到不指定ID的样衣信息");
            }
            return NotFound();
        }
        [HttpGet]
        public object CreateSample()
        {
            var newsample = SessionManage.CurrentSample;
            if (newsample == null || !newsample.IsNewSample)
            {
                string id = KeyMange.GetKey("SampleInfo");
                newsample = new SampleInfo(SessionManage.CurrentUser);
                newsample.BaseInfo.StyleId = id;
                newsample.BaseInfo.State = SampleState.草拟;
                SessionManage.CurrentSample = newsample;
            }
            return Ok(new { newsample.StyleId });
        }

        public object SaveSample(SampleFullInfoModel sample)
        {

            var newsample = SessionManage.CurrentSample;
            if (newsample != null && newsample.StyleId == sample.StyleId)
            {
                newsample.SaveSample(sample);
                SessionManage.CurrentSample = null;
                //添加新的code数据

                //添加TAG
                List<Code> codelist = new List<Code>();
                foreach (var m in sample.StyleTagItems)
                {
                    string name = (string)m.Name;
                    string color = (string)m.Color;
                    codelist.Add(new Code { CodeName = name, Value1 = color, Type = CodeType.Tag });
                };
                CodeOper.AddCode(codelist);
                //添加颜色
                CodeOper.AddCode(new Code { CodeName = newsample.BaseInfo.Color, Type = CodeType.Color });
                SessionManage.CurrentSample = null;
                return Ok();
            }
            else
            {
                return BadRequest("没有登录信息");
            }

        }

        public object UpLoadPic()
        {

            //string minPicPath = Config.MinPicPath;
            string webPath = HttpContext.Current.Server.MapPath("~") + Config.GetSampleConfig().SampleFilePath;
            string picPath = webPath + @"pic\";
            string minPicPath = webPath + @"pic\MinPic\";
            HttpFileCollection files = HttpContext.Current.Request.Files;
            string filename = "";
            foreach (string key in files.AllKeys)
            {
                HttpPostedFile file = files[key];//file.ContentLength文件长度
                if (string.IsNullOrEmpty(file.FileName) == false)
                {

                    string fname = DirFileHelper.GetFileName(file.FileName);
                    fname = fname.Replace("(", string.Empty).Replace(")", string.Empty).Replace(" ", string.Empty);
                    filename = SessionManage.CurrentSample.StyleId + "_" + fname;
                    string filepath = picPath + fname;

                    UploadHelper.FileUpload(file, picPath, fname);
                    //原始文件压缩
                    ImageHelper.MakeSmallImg(filepath, picPath + filename, 1500, 1500);

                    //压缩文件再压缩
                    ImageHelper.MakeSmallImg(filepath, minPicPath + filename, 300, 300);
                    DirFileHelper.DeleteFile(filepath);

                    SessionManage.CurrentSample.AddFile(filename, "", fname, FileType.Pic);
                }
            }
            return Ok(new { name = filename });

        }


        public object UpLoadFile()
        {

            //string filePath = Config.FilePath;
            string webPath = HttpContext.Current.Server.MapPath("~") + Config.GetSampleConfig().SampleFilePath;
            string filePath = webPath + @"uploadfile\";
            HttpFileCollection files = HttpContext.Current.Request.Files;
            string filename = "";
            foreach (string key in files.AllKeys)
            {
                HttpPostedFile file = files[key];//file.ContentLength文件长度
                if (string.IsNullOrEmpty(file.FileName) == false)
                {
                    //file.SaveAs(HttpContext.Current.Server.MapPath("~/App_Data/Image/") + file.FileName);
                    filename = SessionManage.CurrentSample.StyleId + file.FileName;
                    UploadHelper.FileUpload(file, filePath, filename);
                    //file.SaveAs(filePath + filename);
                    SessionManage.CurrentSample.AddFile(filename, "", file.FileName, FileType.File);
                }
            }
            return Ok(new { name = filename });

        }

        /// <summary>
        /// 删除临时文件
        /// </summary>
        /// <param name="_filename"></param>
        /// <returns></returns>
        public object RemoveFile(dynamic _filename)
        {
            string filename = (string)_filename.filename;

            var result = SessionManage.CurrentSample.RemoveFile(filename);
            if (result) return Ok();
            else return NotFound();

        }


    }

}
