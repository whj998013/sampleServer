﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using SG.Model.Product;
using SG.Model.Sample;
using SG.Model.Stock;
using SG.Model.Sys;
using SG.Model.Proof;

using SG.Interface;
namespace SampleDataOper
{
    public class SunginDataContext : DbContext
    {
        
        /// <summary>
        /// 样品信息表
        /// </summary>
        public DbSet<SampleBaseInfo> SampleBaseInfos { get; set; }
        /// <summary>
        /// 样衣附件表
        /// </summary>
        public DbSet<StyleFile> StyleFiles { get; set; }
        /// <summary>
        /// 打样信息表
        /// </summary>
        public DbSet<Proofing> Proofings { get; set; }
        /// <summary>
        /// 生产信息表
        /// </summary>
        public DbSet<ProductionRecord> ProductionRecords { get; set; }
        /// <summary>
        /// 借出记录表
        /// </summary>
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
        public DbSet<GarmentStock> GarmentStocks { get; set; }
               
        /// <summary>
        /// 成份表
        /// </summary>
        public DbSet<Material> Materials { get; set; }
        /// <summary>
        /// 用户表
        /// </summary>
        public DbSet<User> Users { get; set; }
        /// <summary>
        /// 部门表
        /// </summary>
        public DbSet<Dept> Depts { get; set; }
        /// <summary>
        /// 角色表
        /// </summary>
        public DbSet<Role> Roles { get; set; }
        /// <summary>
        /// 用户角色表，1用户对应多角色
        /// </summary>
        public DbSet<UserRole> UserRoles { get; set; }
        /// <summary>
        /// 权限点表
        /// </summary>
        public DbSet<Permission> Permissions { get; set; }
        /// <summary>
        /// 用户角色权限对应表
        /// </summary>
        public DbSet<UserRolePermission> UserRolePermissions { get; set; }
        /// <summary>
        /// 单位表
        /// </summary>
        public DbSet<Unit> Units { get; set; }
        // <summary>
        // 打样申请单
        //</summary>
        public DbSet<ProofOrder> ProofOrders { get; set; }
        /// <summary>
        /// 打样款式表
        /// </summary>
        public DbSet<ProofStyle> ProofStyles { get; set; }
        /// <summary>
        /// 打样类别表
        /// </summary>
        public DbSet<ProofType> ProofTypes { get; set; }
        /// <summary>
        /// 打样文件表
        /// </summary>
        public DbSet<ProofFile> ProofFiles { get; set; }
        /// <summary>
        /// 打样任务表
        /// </summary>
        public DbSet<ProofTask> ProofTasks { get; set; }

        /// <summary>
        /// 工序表
        /// </summary>
        public DbSet<Process> Processlist { get; set; }

        /// <summary>
        /// 生产人员部门
        /// </summary>
        /// <param name="modelBuilder"></param>
        public DbSet<WorkerDept> WorkerDepts { get; set; }
        /// <summary>
        /// 生产人员
        /// </summary>
        public DbSet<Worker> Workers { get; set; }

        /// <summary>
        /// 岗位表
        /// </summary>
        public DbSet<Job> jobs { get; set; }

        /// <summary>
        /// 工厂角色员工表
        /// </summary>
        public DbSet<FactryRoleWorker> FactryRolesWorker { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
          
            base.OnModelCreating(modelBuilder);
        }

    }

}
