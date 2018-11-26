using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SG.Model.Sys;
using SG.Model.Sample;
using SG.Interface.Sys;

namespace SampleDataOper.Migrations
{
    public class DataDefaultList
    {
        public static List<Permission> GetPermissionsList()
        {
            return new List<Permission>(){
              new Permission {  CnName = "样衣库", Name = "Sample", Key = "P010000", UpKey = "P000000" },
              new Permission {  CnName = "找样衣", Name = "Sample_FindSample", Key = "P010100", UpKey = "P010000" },
              new Permission {  CnName = "我的样衣", Name = "Sample_MySample", Key = "P010200", UpKey = "P010000" },
              new Permission {  CnName = "样衣库管理", Name = "SampleMange", Key = "P020000", UpKey = "P000000" },
              new Permission {  CnName = "入库管理", Name = "SampleMange_InStock", Key = "P020100", UpKey = "P020000" },
              new Permission {  CnName = "已入库样衣管理", Name = "SampleMange_InStock_MangeInStock", Key = "P020101", UpKey = "P020100" },
              new Permission {  CnName = "入库审批", Name = "SampleMange_InStock_PassInStock", Key = "P020102", UpKey = "P020100" },
              new Permission {  CnName = "借用管理", Name = "SampleMange_LendStock", Key = "P020200", UpKey = "P020000" },
              new Permission {  CnName = "系统设置", Name = "SampleMange_SystemMange", Key = "P030000", UpKey = "P000000" },
              new Permission {  CnName = "色色权限配置", Name = "SampleMange_SystemMange", Key = "P030100", UpKey = "P030000" },
              new Permission {  CnName = "样衣系统配置", Name = "SampleMange_SystemMange", Key = "P030300", UpKey = "P030000" }


            };
           
        }

        public static List<Material> GetMaterialList()
        {
            return new List<Material>(){
                new Material {  CnName = "腈纶", EnName = "Acrylic" },
                new Material {  CnName = "尼龙", EnName = "Nylon" },
                new Material {  CnName = "兔绒", EnName = "Angora" },
                new Material {  CnName = "羊毛", EnName = "Wool" },
                new Material {  CnName = "羊绒", EnName = "Cashmere" },
                new Material {  CnName = "金银线", EnName = "Lurex" },
                new Material {  CnName = "锦纶", EnName = "Polyamide" },
                new Material {  CnName = "羊驼毛", EnName = "Alpaca" },
                new Material {  CnName = "棉", EnName = "Cotton" },
                new Material {  CnName = "人造丝", EnName = "Rayon" },
                new Material {  CnName = "驼绒", EnName = "Camelhair" },
                new Material {  CnName = "苎麻", EnName = "Famine" },
                new Material {  CnName = "兔毛", EnName = "Rabbithair" },
                new Material {  CnName = "真丝", EnName = "Silk" },
                new Material {  CnName = "大麻", EnName = "Hemp" },
                new Material {  CnName = "氨纶", EnName = "Spandex" },
                new Material {  CnName = "黄麻", EnName = "Jute" },
                new Material {  CnName = "涤纶", EnName = "Polyester" },
                new Material {  CnName = "天丝", EnName = "Tencel" },
                new Material {  CnName = "亚麻", EnName = "Unen" },
                new Material {  CnName = "柞蚕丝", EnName = "Tussahsilk" },
                new Material {  CnName = "羊仔毛", EnName = "Lambswool" },
                new Material {  CnName = "粘胶", EnName = "Viscose" },
                new Material {  CnName = "莱卡", EnName = "Lycra" },
                new Material {  CnName = "马海毛", EnName = "Mohair" },
                new Material {  CnName = "莫代尔", EnName = "Model" },
                new Material {  CnName = "桑蚕丝", EnName = "Mulberrysilk" },
                new Material {  CnName = "牦牛毛", EnName = "Yarkhair" },
                new Material {  CnName = "大豆蛋白纤维", EnName = "Soybeanproteinfibre" }

            };
        }

        public static List<Code> GetCodeList()
        {
            return new List<Code>()
            {
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

            };
        }
    }
}
