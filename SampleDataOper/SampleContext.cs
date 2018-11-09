using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using SampleDataOper.Model;

namespace SampleDataOper
{
    public class SampleContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<SampleBaseInfo> SampleBaseInfos { get; set; }

        public DbSet<StyleFile> StyleFiles { get; set; }

        public DbSet<Proofing> Proofings { get; set; }

        public DbSet<ProductionRecord> ProductionRecords { get; set; }

        public DbSet<LendRecord> LendRecords { get; set; }
             
        /// <summary>
        /// 数据代码表
        /// </summary>
        public DbSet<Code> Codes { get; set; }

        /// <summary>
        /// 数据序号记录表
        /// </summary>
        public DbSet<Km> KMs { get; set; }
        /// <summary>
        /// 库存记录
        /// </summary>
        public DbSet<Stock> Stocks { get; set; }

        /// <summary>
        /// 入库记录
        /// </summary>
        public DbSet<InStockRecord> InstockRecords { get; set; }
        /// <summary>
        /// 成份表
        /// </summary>
        public DbSet<Material> Materials { get; set; }

    }
}
