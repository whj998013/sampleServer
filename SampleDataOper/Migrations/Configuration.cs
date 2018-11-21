namespace SampleDataOper.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using IBLL.Sys;
    using Model.Sample;
    using Model.Sys;
     

    internal sealed class Configuration : DbMigrationsConfiguration<SampleDataOper.SampleContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "SampleDataOper.SampleContext";
        }

        protected override void Seed(SampleDataOper.SampleContext context)
        {
            //  This method will be called after migrating to the latest version.
            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            context.Codes.AddOrUpdate(
                m => m.Id,
                new Code { Id = 1, Type = CodeType.Color, CodeName = "红色" },
                new Code { Id = 2, Type = CodeType.Color, CodeName = "黄色" },
                new Code { Id = 3, Type = CodeType.Color, CodeName = "白色" },
                new Code { Id = 4, Type = CodeType.Color, CodeName = "黑色" },
                new Code { Id = 5, Type = CodeType.Color, CodeName = "蓝色" },
                new Code { Id = 6, Type = CodeType.Color, CodeName = "绿色" },
                new Code { Id = 7, Type = CodeType.Color, CodeName = "紫色" },
                new Code { Id = 8, Type = CodeType.Size, CodeName = "XL" },
                new Code { Id = 9, Type = CodeType.Size, CodeName = "L" },
                new Code { Id = 10, Type = CodeType.Size, CodeName = "M" },
                new Code { Id = 11, Type = CodeType.Size, CodeName = "S" },
                new Code { Id = 12, Type = CodeType.Size, CodeName = "XS" },
                new Code { Id = 13, Type = CodeType.Size, CodeName = "肥婆码" },
                new Code { Id = 14, Type = CodeType.Gauge, CodeName = "粗针" },
                new Code { Id = 15, Type = CodeType.Gauge, CodeName = "细针" },
                new Code { Id = 16, Type = CodeType.Gauge, CodeName = "3G" },
                new Code { Id = 17, Type = CodeType.Gauge, CodeName = "5G" },
                new Code { Id = 18, Type = CodeType.Gauge, CodeName = "7G" },
                new Code { Id = 19, Type = CodeType.Gauge, CodeName = "12G" },
                new Code { Id = 20, Type = CodeType.Gauge, CodeName = "14G" },
                new Code { Id = 21, Type = CodeType.Material, CodeName = "棉" },
                new Code { Id = 22, Type = CodeType.Material, CodeName = "羊绒" },
                new Code { Id = 23, Type = CodeType.Material, CodeName = "羊毛" },
                new Code { Id = 24, Type = CodeType.Material, CodeName = "金银线" },
                new Code { Id = 25, Type = CodeType.Tag, CodeName = "男装", Value1 = "#7B68EE" },
                new Code { Id = 26, Type = CodeType.Tag, CodeName = "女装", Value1 = "#2F4F4F" },
                new Code { Id = 27, Type = CodeType.Tag, CodeName = "童装", Value1 = "#C71585" },
                new Code { Id = 28, Type = CodeType.Tag, CodeName = "春季", Value1 = "#FFA2D3" },
                new Code { Id = 29, Type = CodeType.Tag, CodeName = "秋季", Value1 = "#DC143C" },
                new Code { Id = 30, Type = CodeType.Tag, CodeName = "冬季", Value1 = "#48D1CC" },
                new Code { Id = 31, Type = CodeType.Tag, CodeName = "流行款", Value1 = "#A52A2A" },
                new Code { Id = 32, Type = CodeType.Tag, CodeName = "基本款", Value1 = "#8FBC8F" },
                new Code { Id = 33, Type = CodeType.Tag, CodeName = "欧美风格", Value1 = "#00FF00" },
                new Code { Id = 34, Type = CodeType.Kinds, CodeName = "初样" },
                new Code { Id = 35, Type = CodeType.Kinds, CodeName = "开发样" },
                new Code { Id = 36, Type = CodeType.Kinds, CodeName = "生产样" },
                new Code { Id = 37, Type = CodeType.Kinds, CodeName = "合同样" },
                new Code { Id = 38, Type = CodeType.Kinds, CodeName = "推销样留底" },
                new Code { Id = 39, Type = CodeType.Kinds, CodeName = "复办" },
                new Code { Id = 40, Type = CodeType.Kinds, CodeName = "外购" },
                new Code { Id = 41, Type = CodeType.Size, CodeName = "均码" }
                );
            context.Materials.AddOrUpdate(m => m.Id,
                new Material { Id = 1, CnName = "腈纶", EnName = "Acrylic" },
                new Material { Id = 2, CnName = "尼龙", EnName = "Nylon" },
                new Material { Id = 3, CnName = "兔绒", EnName = "Angora" },
                new Material { Id = 4, CnName = "羊毛", EnName = "Wool" },
                new Material { Id = 5, CnName = "羊绒", EnName = "Cashmere" },
                new Material { Id = 6, CnName = "金银线", EnName = "Lurex" },
                new Material { Id = 7, CnName = "锦纶", EnName = "Polyamide" },
                new Material { Id = 8, CnName = "羊驼毛", EnName = "Alpaca" },
                new Material { Id = 9, CnName = "棉", EnName = "Cotton" },
                new Material { Id = 10, CnName = "人造丝", EnName = "Rayon" },
                new Material { Id = 11, CnName = "驼绒", EnName = "Camelhair" },
                new Material { Id = 12, CnName = "苎麻", EnName = "Famine" },
                new Material { Id = 13, CnName = "兔毛", EnName = "Rabbithair" },
                new Material { Id = 14, CnName = "真丝", EnName = "Silk" },
                new Material { Id = 15, CnName = "大麻", EnName = "Hemp" },
                new Material { Id = 16, CnName = "氨纶", EnName = "Spandex" },
                new Material { Id = 17, CnName = "黄麻", EnName = "Jute" },
                new Material { Id = 18, CnName = "涤纶", EnName = "Polyester" },
                new Material { Id = 19, CnName = "天丝", EnName = "Tencel" },
                new Material { Id = 20, CnName = "亚麻", EnName = "Unen" },
                new Material { Id = 21, CnName = "柞蚕丝", EnName = "Tussahsilk" },
                new Material { Id = 22, CnName = "羊仔毛", EnName = "Lambswool" },
                new Material { Id = 23, CnName = "粘胶", EnName = "Viscose" },
                new Material { Id = 24, CnName = "莱卡", EnName = "Lycra" },
                new Material { Id = 25, CnName = "马海毛", EnName = "Mohair" },
                new Material { Id = 26, CnName = "莫代尔", EnName = "Model" },
                new Material { Id = 27, CnName = "桑蚕丝", EnName = "Mulberrysilk" },
                new Material { Id = 28, CnName = "牦牛毛", EnName = "Yarkhair" },
                new Material { Id = 29, CnName = "大豆蛋白纤维", EnName = "Soybeanproteinfibre" }

            );
            context.SaveChanges();
        }
    }
}
