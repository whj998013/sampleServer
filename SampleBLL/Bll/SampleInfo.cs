using System.Collections.Generic;
using System.IO;
using System.Linq;
using SG.Utilities;
using SampleDataOper;
using SampleBLL;
using SampleBLL.Model;
using System;
using SG.Interface.Sample;
using SG.Model.Sys;
using SG.Model.Sample;
using SG.Model.Stock;
using SG.Model.Product;

namespace SampleBLL
{
    public class SampleInfo
    {

        private User currentUser { get; set; } = new User();
        public bool IsNewSample { get; set; } = true;
        public SampleBaseInfo BaseInfo { get; set; } = new SampleBaseInfo();
        public Proofing ProofingInfo { get; set; } = new Proofing();
        public ProductionRecord ProductInfo { get; set; } = new ProductionRecord();
        public List<StyleFile> Files { get; set; } = new List<StyleFile>();
        public List<Stock> StockList { get; set; } = new List<Stock>();
        public SampleInfo(User user)
        {
            currentUser = user;
        }

        public bool LoadSampleById(string styleId)
        {
            try
            {
                using (SampleContext sc = new SampleContext())
                {
                    BaseInfo = sc.SampleBaseInfos.SingleOrDefault(p => p.StyleId == styleId);
                    ProofingInfo = sc.Proofings.SingleOrDefault(p => p.StyleId == styleId);
                    if (ProofingInfo == null) ProofingInfo = new Proofing();
                    ProductInfo = sc.ProductionRecords.SingleOrDefault(p => p.StyleId == styleId);
                    if (ProductInfo == null) ProductInfo = new ProductionRecord();
                    StockList = sc.Stocks.Where(p => p.StyleId == styleId).ToList();
                    Files = sc.StyleFiles.Where(p => p.SytleId == BaseInfo.StyleId).ToList();
                    IsNewSample = false;
                    return true;
                }

            }
            catch
            {
                return false;
            }

        }

        public int Id
        {
            get
            {
                return BaseInfo.Id;
            }
        }

        public string StyleId
        {
            get
            {
                return BaseInfo.StyleId;
            }

        }
        public string StyleNo
        {
            get
            {
                return BaseInfo.StyleNo;
            }
        }


        public void AddFile(string filename, string fileUrl, string displayName, FileType filetype)
        {
            var file = Files.Where(p => p.FileName == filename).SingleOrDefault();
            if (file == null)
            {
                var f = new StyleFile()
                {
                    SytleId = StyleId,
                    FileName = filename,
                    FileUrl = fileUrl,
                    FileType = filetype,
                    DisplayName = displayName
                };
                f.SetCreateUser(currentUser.UserName);
                Files.Add(f);
            }
            else
            {
                file.IsDelete = false;
            }
        }

        public bool RemoveFile(string filename)
        {
            var file = Files.FirstOrDefault(p => p.FileName == filename);
            if (file != null)
            {
                file.IsDelete = true;
                file.SetEditUser(currentUser.UserName);
                return true;
            }
            else return false;

        }
        public bool SaveSample(SampleFullInfoModel sample)
        {
            using (SampleContext sc = new SampleContext())
            {

                //基本信息
                //BaseInfo.StyleId = (string)sample.styleId;
                BaseInfo.StyleNo = sample.StyleNo;
                BaseInfo.Color = sample.Color;
                BaseInfo.Size = sample.Size;
                BaseInfo.Gauge = sample.Gauge;
                BaseInfo.Weight = sample.Weight;
                BaseInfo.CanLendOut = sample.CanLendOut;
                BaseInfo.Kinds = sample.Kinds;
                BaseInfo.Counts = sample.Counts;
                BaseInfo.Material = JsonHelper.ToJson(sample.MaterialItems);
                BaseInfo.StyleTag = JsonHelper.ToJson(sample.StyleTagItems);
                if (IsNewSample) BaseInfo.DdId = currentUser.DdId;
                BaseInfo.HaveStock = sample.HaveStock;
                BaseInfo.CostPrice = sample.CostPrice;
                BaseInfo.FactoryPrice = sample.FactoryPrice;
                BaseInfo.SalePrice = sample.SalePrice;
                BaseInfo.DiscountPrice = sample.DiscountPrice;
                //大货信息
                ProductInfo.StyleId = BaseInfo.StyleId;
                ProductInfo.ClientName = sample.ClientName;
                ProductInfo.ProductFactory = sample.ProductFactory;
                ProductInfo.ProductNum = sample.ProductNum;
                ProductInfo.Price = sample.Price;
                if (sample.ProductDate != "")
                {
                    ProductInfo.ProductDate = DateTime.Parse(sample.ProductDate);
                }


                //打样信息
                ProofingInfo.StyleId = BaseInfo.StyleId;
                ProofingInfo.ProofingCompany = (string)sample.ProofingCompany;
                ProofingInfo.TechnologyPeople = (string)sample.TechnologyPeople;
                ProofingInfo.ProgamPeople = (string)sample.ProgamPeople;
                if (sample.ProofingDate != "")
                {
                    ProofingInfo.ProofingDate = DateTime.Parse(sample.ProofingDate);
                }

                //开始保存
                //库存信息

                if (BaseInfo.HaveStock && sample.StockDataItems.Count > 0)
                {
                    //如已有数据，则更新，如无则删除
                    StockList.ForEach(p =>
                    {
                        var re = sample.StockDataItems.SingleOrDefault(w => w.Size == p.Size && w.Color == p.Color);
                        if (re != null)
                        {
                            p.Num = re.Num;
                        }
                        else p.IsDelete = true;
                        sc.Entry(p).State = System.Data.Entity.EntityState.Modified;
                        sample.StockDataItems.Remove(re);
                    });

                    //新增数据 
                    sample.StockDataItems.ForEach(p =>
                    {
                        sc.Stocks.Add(new Stock
                        {
                            Color = p.Color,
                            Size = p.Size,
                            Num = p.Num,
                            StyleId = BaseInfo.StyleId,
                            StockId = KeyMange.GetKey("Stock")
                        });
                    });
                }

                if (IsNewSample)
                {
                    Files.ForEach(p =>
                    {
                        if (p.IsDelete)
                        {
                            File.Delete(p.FileUrl);
                        }
                    });
                    Files.RemoveAll(p => p.IsDelete);
                    BaseInfo.SetCreateUser(currentUser.UserName);
                    sc.SampleBaseInfos.Add(BaseInfo);
                    //写入打样信息
                    ProofingInfo.SetCreateUser(currentUser.UserName);
                    sc.Proofings.Add(ProofingInfo);
                    //写入文件信息
                    sc.StyleFiles.AddRange(Files);
                    //写入大货信息
                    ProductInfo.SetCreateUser(currentUser.UserName);
                    sc.ProductionRecords.Add(ProductInfo);

                }
                else
                {
                    Files.ForEach(p =>
                    {
                        if (p.Id == 0)
                        {
                            sc.StyleFiles.Add(p);
                        }
                        else if (p.IsDelete == true) sc.Entry(p).State = System.Data.Entity.EntityState.Modified;

                    });

                    BaseInfo.SetEditUser(currentUser.UserName);
                    ProofingInfo.SetEditUser(currentUser.UserName);
                    ProductInfo.SetEditUser(currentUser.UserName);
                    sc.Entry(BaseInfo).State = System.Data.Entity.EntityState.Modified;
                    if (ProofingInfo.Id > 0) sc.Entry(ProofingInfo).State = System.Data.Entity.EntityState.Modified;
                    else sc.Entry(ProofingInfo).State = System.Data.Entity.EntityState.Added;
                    if (ProductInfo.Id > 0) sc.Entry(ProductInfo).State = System.Data.Entity.EntityState.Modified;
                    else sc.Entry(ProductInfo).State = System.Data.Entity.EntityState.Added;
                };
                SetSeachStr();
                sc.SaveChanges();
            }
            return true;
        }



        private void SetSeachStr()
        {
            string str = BaseInfo.StyleId + "_" + BaseInfo.StyleNo;
            str += "_" + BaseInfo.Gauge;
            str += "_" + BaseInfo.Size;
            str += "_" + BaseInfo.Color;
            str += "_" + BaseInfo.CreateUser;
            var material = JsonHelper.JsonToList<material>(BaseInfo.Material);
            if (material != null)
            {
                foreach (var p in material)
                {
                    str += "_" + p.materials;
                }
            }

            var styletag = JsonHelper.JsonToList<styleTag>(BaseInfo.StyleTag);
            if (styletag != null)
            {
                foreach (var p in styletag)
                {
                    str += "_" + p.name;
                }
            }

            BaseInfo.SeachStr = str;
        }


        private class material
        {
            public string materials { get; set; }
            public int percent { get; set; }
            public int index { get; set; }
        }

        private class styleTag
        {
            public string name { get; set; }
            public string color { get; set; }
        }
    }


}
