using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SG.Interface.Sample;
using SG.Model.Sample;
using SG.Model.Product;
using SampleDataOper;
using SG.Utilities;
using SG.Interface.Product;
namespace SampleBLL
{
    /// <summary>
    /// 生成客户端指定对象
    /// </summary>
    public class SampleHelper
    {
        public static dynamic GetDdLenOutObj(ILendRecord p)
        {
            object obj = null;
            using (SampleContext sc = new SampleContext())
            {
                ISampleBaseInfo sb = sc.SampleBaseInfos.SingleOrDefault(item => item.StyleId == p.StyleId);
                if (sb != null)
                {
                    var pic = sc.StyleFiles.FirstOrDefault(f => f.SytleId == p.StyleId && f.FileType == FileType.Pic);
                    obj = new
                    {
                        p.Id,
                        sb.StyleId,
                        sb.StyleNo,
                        Pic = pic.FileName,
                        sb.Gauge,
                        sb.Weight,
                        sb.Material,
                        sb.Counts,
                        p.LendOutNo,
                        sb.State,
                        sb.CanLendOut,
                        LendState =p.State,
                        AsLend = sb.State == SampleState.在库,
                        StatsText = sb.State.ToString(),
                    };
                }
                return obj;
            }
        }

        public static dynamic GetReturnObj(ISampleBaseInfo baseinfo)
        {
            using (SampleContext sc = new SampleContext())
            {

                IProofing pr = sc.Proofings.SingleOrDefault(p => p.StyleId == baseinfo.StyleId);
                if (pr == null) pr = new Proofing();
                IProductionRecord pd = sc.ProductionRecords.SingleOrDefault(p => p.StyleId == baseinfo.StyleId);
                if (pd == null) pd = new ProductionRecord();
                var Files = sc.StyleFiles.Where(p => !p.IsDelete && p.SytleId == baseinfo.StyleId).Select(p => new { p.DisplayName, p.FileName, p.FileType }).ToList();
                var FirstPic = Files.FirstOrDefault(p => p.FileType == FileType.Pic);
                var StockData = sc.GarmentStocks.Where(p => !p.IsDelete && p.StyleId == baseinfo.StyleId).Select(p => new { size = p.Size, color = p.Color, num = p.Num }).ToList();
                string Pic = FirstPic != null ? FirstPic.FileName : "";

                return new
                {
                    baseinfo.Id,
                    baseinfo.StyleId,
                    baseinfo.StyleNo,
                    baseinfo.Color,
                    baseinfo.Weight,
                    baseinfo.Gauge,
                    baseinfo.Size,
                    baseinfo.Kinds,
                    baseinfo.CanLendOut,
                    baseinfo.HaveStock,
                    User = baseinfo.CreateUser,
                    baseinfo.State,
                    baseinfo.CostPrice,
                    baseinfo.FactoryPrice,
                    baseinfo.SalePrice,
                    baseinfo.DiscountPrice,
                    baseinfo.Counts,
                    StateText = baseinfo.State.ToString(),
                    StyleTag = JsonHelper.ToObj(baseinfo.StyleTag),
                    Material = JsonHelper.ToObj(baseinfo.Material),
                    CreateDate = baseinfo.CreateDate != null ? baseinfo.CreateDate.Value.Date.ToShortDateString() : "",
                    pr.ProofingCompany,
                    pr.ProgamPeople,
                    pr.TechnologyPeople,
                    ProofingDate = pr.ProofingDate != null ? pr.ProofingDate.Value.Date.ToShortDateString() : "",
                    pd.ClientName,
                    pd.ProductFactory,
                    pd.ProductNum,
                    pd.Price,
                    ProductDate = pd.ProductDate != null ? pd.ProductDate.Value.ToShortDateString() : "",
                    StockData,
                    Pic,
                    Files
                };
            }
        }

        public static dynamic GetEditObj(ISampleBaseInfo baseinfo)
        {
            using (SampleContext sc = new SampleContext())
            {

                IProofing pr = sc.Proofings.SingleOrDefault(p => p.StyleId == baseinfo.StyleId);
                if (pr == null) pr = new Proofing();
                IProductionRecord pd = sc.ProductionRecords.SingleOrDefault(p => p.StyleId == baseinfo.StyleId);
                if (pd == null) pd = new ProductionRecord();
                var FileList = sc.StyleFiles.Where(p => !p.IsDelete && p.SytleId == baseinfo.StyleId && p.FileType == FileType.File).Select(p => new { name = p.DisplayName, reallyName = p.FileName }).ToList();
                var PicList = sc.StyleFiles.Where(p => !p.IsDelete && p.SytleId == baseinfo.StyleId && p.FileType == FileType.Pic).Select(p => new { name = p.FileName, reallyName = p.FileName }).ToList();
                var StockData = sc.GarmentStocks.Where(p => !p.IsDelete && p.StyleId == baseinfo.StyleId).Select(p=>new { size=p.Size,color=p.Color,num=p.Num}).ToList();
                return new
                {
                    baseinfo.Id,
                    baseinfo.StyleId,
                    baseinfo.StyleNo,
                    baseinfo.Color,
                    baseinfo.Weight,
                    baseinfo.Gauge,
                    baseinfo.Size,
                    User=baseinfo.CreateUser,
                    baseinfo.Kinds,
                    baseinfo.Counts,
                    baseinfo.CanLendOut,
                    baseinfo.HaveStock,
                    baseinfo.State,
                    baseinfo.CostPrice,
                    baseinfo.FactoryPrice,
                    baseinfo.SalePrice,
                    baseinfo.DiscountPrice,
                    StateText = baseinfo.State.ToString(),
                    StyleTag = JsonHelper.ToObj(baseinfo.StyleTag),
                    Material = JsonHelper.ToObj(baseinfo.Material),
                    pr.ProofingCompany,
                    pr.ProgamPeople,
                    pr.TechnologyPeople,
                    ProofingDate = pr.ProofingDate != null ? pr.ProofingDate.Value.Date.ToShortDateString() : "",
                    pd.ClientName,
                    pd.ProductFactory,
                    pd.ProductNum,
                    pd.Price,
                    ProductDate=pd.ProductDate!=null?pd.ProductDate.Value.ToShortDateString():"",
                    StockData,
                    FileList,
                    PicList,
                };
            }

        }
    }
}
