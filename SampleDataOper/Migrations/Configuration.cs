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
                new Code { Id = 1, Type = CodeType.Color, CodeName = "��ɫ" },
                new Code { Id = 2, Type = CodeType.Color, CodeName = "��ɫ" },
                new Code { Id = 3, Type = CodeType.Color, CodeName = "��ɫ" },
                new Code { Id = 4, Type = CodeType.Color, CodeName = "��ɫ" },
                new Code { Id = 5, Type = CodeType.Color, CodeName = "��ɫ" },
                new Code { Id = 6, Type = CodeType.Color, CodeName = "��ɫ" },
                new Code { Id = 7, Type = CodeType.Color, CodeName = "��ɫ" },
                new Code { Id = 8, Type = CodeType.Size, CodeName = "XL" },
                new Code { Id = 9, Type = CodeType.Size, CodeName = "L" },
                new Code { Id = 10, Type = CodeType.Size, CodeName = "M" },
                new Code { Id = 11, Type = CodeType.Size, CodeName = "S" },
                new Code { Id = 12, Type = CodeType.Size, CodeName = "XS" },
                new Code { Id = 13, Type = CodeType.Size, CodeName = "������" },
                new Code { Id = 14, Type = CodeType.Gauge, CodeName = "����" },
                new Code { Id = 15, Type = CodeType.Gauge, CodeName = "ϸ��" },
                new Code { Id = 16, Type = CodeType.Gauge, CodeName = "3G" },
                new Code { Id = 17, Type = CodeType.Gauge, CodeName = "5G" },
                new Code { Id = 18, Type = CodeType.Gauge, CodeName = "7G" },
                new Code { Id = 19, Type = CodeType.Gauge, CodeName = "12G" },
                new Code { Id = 20, Type = CodeType.Gauge, CodeName = "14G" },
                new Code { Id = 21, Type = CodeType.Material, CodeName = "��" },
                new Code { Id = 22, Type = CodeType.Material, CodeName = "����" },
                new Code { Id = 23, Type = CodeType.Material, CodeName = "��ë" },
                new Code { Id = 24, Type = CodeType.Material, CodeName = "������" },
                new Code { Id = 25, Type = CodeType.Tag, CodeName = "��װ", Value1 = "#7B68EE" },
                new Code { Id = 26, Type = CodeType.Tag, CodeName = "Ůװ", Value1 = "#2F4F4F" },
                new Code { Id = 27, Type = CodeType.Tag, CodeName = "ͯװ", Value1 = "#C71585" },
                new Code { Id = 28, Type = CodeType.Tag, CodeName = "����", Value1 = "#FFA2D3" },
                new Code { Id = 29, Type = CodeType.Tag, CodeName = "�＾", Value1 = "#DC143C" },
                new Code { Id = 30, Type = CodeType.Tag, CodeName = "����", Value1 = "#48D1CC" },
                new Code { Id = 31, Type = CodeType.Tag, CodeName = "���п�", Value1 = "#A52A2A" },
                new Code { Id = 32, Type = CodeType.Tag, CodeName = "������", Value1 = "#8FBC8F" },
                new Code { Id = 33, Type = CodeType.Tag, CodeName = "ŷ�����", Value1 = "#00FF00" },
                new Code { Id = 34, Type = CodeType.Kinds, CodeName = "����" },
                new Code { Id = 35, Type = CodeType.Kinds, CodeName = "������" },
                new Code { Id = 36, Type = CodeType.Kinds, CodeName = "������" },
                new Code { Id = 37, Type = CodeType.Kinds, CodeName = "��ͬ��" },
                new Code { Id = 38, Type = CodeType.Kinds, CodeName = "����������" },
                new Code { Id = 39, Type = CodeType.Kinds, CodeName = "����" },
                new Code { Id = 40, Type = CodeType.Kinds, CodeName = "�⹺" },
                new Code { Id = 41, Type = CodeType.Size, CodeName = "����" }
                );
            context.Materials.AddOrUpdate(m => m.Id,
                new Material { Id = 1, CnName = "����", EnName = "Acrylic" },
                new Material { Id = 2, CnName = "����", EnName = "Nylon" },
                new Material { Id = 3, CnName = "����", EnName = "Angora" },
                new Material { Id = 4, CnName = "��ë", EnName = "Wool" },
                new Material { Id = 5, CnName = "����", EnName = "Cashmere" },
                new Material { Id = 6, CnName = "������", EnName = "Lurex" },
                new Material { Id = 7, CnName = "����", EnName = "Polyamide" },
                new Material { Id = 8, CnName = "����ë", EnName = "Alpaca" },
                new Material { Id = 9, CnName = "��", EnName = "Cotton" },
                new Material { Id = 10, CnName = "����˿", EnName = "Rayon" },
                new Material { Id = 11, CnName = "����", EnName = "Camelhair" },
                new Material { Id = 12, CnName = "����", EnName = "Famine" },
                new Material { Id = 13, CnName = "��ë", EnName = "Rabbithair" },
                new Material { Id = 14, CnName = "��˿", EnName = "Silk" },
                new Material { Id = 15, CnName = "����", EnName = "Hemp" },
                new Material { Id = 16, CnName = "����", EnName = "Spandex" },
                new Material { Id = 17, CnName = "����", EnName = "Jute" },
                new Material { Id = 18, CnName = "����", EnName = "Polyester" },
                new Material { Id = 19, CnName = "��˿", EnName = "Tencel" },
                new Material { Id = 20, CnName = "����", EnName = "Unen" },
                new Material { Id = 21, CnName = "����˿", EnName = "Tussahsilk" },
                new Material { Id = 22, CnName = "����ë", EnName = "Lambswool" },
                new Material { Id = 23, CnName = "ճ��", EnName = "Viscose" },
                new Material { Id = 24, CnName = "����", EnName = "Lycra" },
                new Material { Id = 25, CnName = "��ë", EnName = "Mohair" },
                new Material { Id = 26, CnName = "Ī����", EnName = "Model" },
                new Material { Id = 27, CnName = "ɣ��˿", EnName = "Mulberrysilk" },
                new Material { Id = 28, CnName = "��ţë", EnName = "Yarkhair" },
                new Material { Id = 29, CnName = "�󶹵�����ά", EnName = "Soybeanproteinfibre" }

            );
            context.SaveChanges();
        }
    }
}
