using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SG.Model.Sys;
using SG.Model.Sample;
using SG.Interface.Sys;
using SG.Model.Proof;

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
              new Permission {  CnName = "查看", Name = "Sample_MySample_View", Key = "P010201", UpKey = "P010200" },
              new Permission {  CnName = "新增样衣", Name = "Sample_MySample_NewSample", Key = "P010202", UpKey = "P010200" },

              new Permission {  CnName = "入库管理", Name = "Sample_InOutMange", Key = "P010300", UpKey = "P010000" },
              new Permission {  CnName = "已入库样衣管理", Name = "Sample_InOutMange_InStockMange", Key = "P010301", UpKey = "P010300" },
              new Permission {  CnName = "入库审批", Name = "Sample_InOutMange_PassInStock", Key = "P010302", UpKey = "P010300" },

              new Permission {  CnName = "借用管理", Name = "Sample_LendMange", Key = "P010400", UpKey = "P010000" },
              new Permission {  CnName = "借用审批", Name = "Sample_LendMange_LendAudit", Key = "P010401", UpKey = "P010400" },
              new Permission {  CnName = "已借出样衣", Name = "Sample_LendMange_LendOutView", Key = "P010402", UpKey = "P010400" },

              new Permission {  CnName = "手机端权限", Name = "Sample_Dd", Key = "P015000", UpKey = "P010000" },
              new Permission {  CnName = "查看所有信息", Name = "Sample_Dd_ViewAllInfo", Key = "P015001", UpKey = "P015000" },
              new Permission {  CnName = "样衣借用", Name = "Sample_Dd_SampleLend", Key = "P015002", UpKey = "P015000" },

              new Permission {  CnName = "打样中心", Name = "Proof", Key = "P020000", UpKey = "P000000" },
              new Permission {  CnName = "我的打样", Name = "Proof_MyProof", Key = "P020100", UpKey = "P020000" },
              new Permission {  CnName = "我的任务", Name = "Proof_MyTask", Key = "P020300", UpKey = "P020000" },
              new Permission {  CnName = "打样管理", Name = "Proof_ProofMange", Key = "P020200", UpKey = "P020000" },


              new Permission {  CnName = "系统设置", Name = "SystemMange", Key = "P990000", UpKey = "P000000" },
              new Permission {  CnName = "角色权限配置", Name = "SystemMange_RoleUserMange", Key = "P990100", UpKey = "P990000" },
              new Permission {  CnName = "样衣系统配置", Name = "SystemMange_SampleMange", Key = "P990300", UpKey = "P990000" }

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

        public static List<Unit> GetUnitList()
        {
            return new List<Unit>()
            {
                new Unit{Cnname="公斤",EnName="kg"},
                new Unit{Cnname="克",EnName="g"},
                new Unit{Cnname="件",EnName="Piece"}
            };
        }

        public static List<Code> GetCodeList()
        {
            return new List<Code>()
            {
                new Code {  Type = CodeType.Color, CodeName = "红色" },
                new Code {  Type = CodeType.Color, CodeName = "黄色" },
                new Code {  Type = CodeType.Color, CodeName = "白色" },
                new Code {  Type = CodeType.Color, CodeName = "黑色" },
                new Code {  Type = CodeType.Color, CodeName = "蓝色" },
                new Code {  Type = CodeType.Color, CodeName = "绿色" },
                new Code {  Type = CodeType.Color, CodeName = "紫色" },
                new Code {  Type = CodeType.Size, CodeName = "XL" },
                new Code {  Type = CodeType.Size, CodeName = "L" },
                new Code {  Type = CodeType.Size, CodeName = "M" },
                new Code {  Type = CodeType.Size, CodeName = "S" },
                new Code {  Type = CodeType.Size, CodeName = "XS" },
                new Code {  Type = CodeType.Size, CodeName = "肥婆码" },
                new Code {  Type = CodeType.Gauge, CodeName = "粗针" },
                new Code {  Type = CodeType.Gauge, CodeName = "细针" },
                new Code {  Type = CodeType.Gauge, CodeName = "3G" },
                new Code {  Type = CodeType.Gauge, CodeName = "5G" },
                new Code {  Type = CodeType.Gauge, CodeName = "7G" },
                new Code {  Type = CodeType.Gauge, CodeName = "12G" },
                new Code {  Type = CodeType.Gauge, CodeName = "14G" },
                new Code {  Type = CodeType.Tag, CodeName = "男装", Value1 = "#7B68EE" },
                new Code {  Type = CodeType.Tag, CodeName = "女装", Value1 = "#2F4F4F" },
                new Code {  Type = CodeType.Tag, CodeName = "童装", Value1 = "#C71585" },
                new Code {  Type = CodeType.Tag, CodeName = "春季", Value1 = "#FFA2D3" },
                new Code {  Type = CodeType.Tag, CodeName = "秋季", Value1 = "#DC143C" },
                new Code {  Type = CodeType.Tag, CodeName = "冬季", Value1 = "#48D1CC" },
                new Code {  Type = CodeType.Tag, CodeName = "流行款", Value1 = "#A52A2A" },
                new Code {  Type = CodeType.Tag, CodeName = "基本款", Value1 = "#8FBC8F" },
                new Code {  Type = CodeType.Tag, CodeName = "欧美风格", Value1 = "#00FF00" },
                new Code {  Type = CodeType.Kinds, CodeName = "初样" },
                new Code {  Type = CodeType.Kinds, CodeName = "开发样" },
                new Code {  Type = CodeType.Kinds, CodeName = "生产样" },
                new Code {  Type = CodeType.Kinds, CodeName = "合同样" },
                new Code {  Type = CodeType.Kinds, CodeName = "推销样留底" },
                new Code {  Type = CodeType.Kinds, CodeName = "复办" },
                new Code {  Type = CodeType.Kinds, CodeName = "外购" },
                new Code {  Type = CodeType.Size, CodeName = "均码" }

            };
        }

        public static List<Km> GetKmList()
        {
            return new List<Km>
            {
                new Km{KeyName="SampleLend",KeyValue=10000001,BeginKey="SL",Comment="样衣借用单"},
                new Km{KeyName="SampleInfo",KeyValue=10000001,BeginKey="SI",Comment="样衣信息"},
                new Km{KeyName="Stock",KeyValue=10000001,BeginKey="ST",Comment="样衣库存信息"},
                new Km{KeyName="ProofOrder",KeyValue=10000001,BeginKey="PO",Comment="打样申请单"},
                new Km{KeyName="ProofStyle",KeyValue=10000001,BeginKey="PS",Comment="打样款式信息"},


            };

        }
        public static List<ProofType> GetProofTypeList()
        {
            return new List<ProofType>
            {
                new ProofType{TypeName="初样",ProofPrice=0},
                new ProofType{TypeName="修正样",ProofPrice=0},
                new ProofType{TypeName="齐码样",ProofPrice=0},
                new ProofType{TypeName="测试样",ProofPrice=0},
                new ProofType{TypeName="试身样",ProofPrice=0},
                new ProofType{TypeName="黑板",ProofPrice=0},
                new ProofType{TypeName="白板",ProofPrice=0},
                new ProofType{TypeName="齐色样",ProofPrice=0},
                new ProofType{TypeName="颜色样",ProofPrice=0}

            };
        }

        public static List<Process> GetProcessList()
        {
            return new List<Process>
            {
                new Process{ProcessName="工艺"},
                new Process{ProcessName="程序"},
                new Process{ProcessName="织片"},
                new Process{ProcessName="套口"},
                new Process{ProcessName="车唛"},
                new Process{ProcessName="钉扣"},
                new Process{ProcessName="大烫"},
                new Process{ProcessName="洗水"},
                new Process{ProcessName="检验"},
                new Process{ProcessName="初检"},
                new Process{ProcessName="终检"},
                new Process{ProcessName="包装"},
                
        };
        }

        public static List<WorkerDept> GetWorkerDepts()
        {
            return new List<WorkerDept>
            {
                new WorkerDept{DeptName="样品部"},
                new WorkerDept{DeptName="电机部"},
                new WorkerDept{DeptName="洗水部"},
                new WorkerDept{DeptName="套口部"},
                new WorkerDept{DeptName="整烫部"},
                new WorkerDept{DeptName="检验部"},
                new WorkerDept{DeptName="包装部"},
           };
        }

        public static List<Job> GetJobs()
        {
            return new List<Job>
            {
             new Job{JobName="工艺员"},
             new Job{JobName="程序员"},
             new Job{JobName="电机工"},
             new Job{JobName="手摇机工"},
             new Job{JobName="套口工"},
             new Job{JobName="洗水工"},
             new Job{JobName="烫工"},
             new Job{JobName="检验工"},

           };
        }

    }
}
