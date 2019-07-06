namespace tempClass
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class tt : DbContext
    {
        public tt()
            : base("name=tt")
        {
        }

        public virtual DbSet<Admin> Admin { get; set; }
        public virtual DbSet<BadReport> BadReport { get; set; }
        public virtual DbSet<BadReportDetail> BadReportDetail { get; set; }
        public virtual DbSet<CheckData> CheckData { get; set; }
        public virtual DbSet<CheckStock> CheckStock { get; set; }
        public virtual DbSet<CheckStockInfo> CheckStockInfo { get; set; }
        public virtual DbSet<CloneHistory> CloneHistory { get; set; }
        public virtual DbSet<CloneTemp> CloneTemp { get; set; }
        public virtual DbSet<Color> Color { get; set; }
        public virtual DbSet<CusAddress> CusAddress { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Equipment> Equipment { get; set; }
        public virtual DbSet<InStorage> InStorage { get; set; }
        public virtual DbSet<InStorDetail> InStorDetail { get; set; }
        public virtual DbSet<InventoryBook> InventoryBook { get; set; }
        public virtual DbSet<LocalProduct> LocalProduct { get; set; }
        public virtual DbSet<Location> Location { get; set; }
        public virtual DbSet<Measure> Measure { get; set; }
        public virtual DbSet<MeasureRel> MeasureRel { get; set; }
        public virtual DbSet<MoveOrder> MoveOrder { get; set; }
        public virtual DbSet<MoveOrderDetail> MoveOrderDetail { get; set; }
        public virtual DbSet<OutStoDetail> OutStoDetail { get; set; }
        public virtual DbSet<OutStorage> OutStorage { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductCategory> ProductCategory { get; set; }
        public virtual DbSet<ReportParams> ReportParams { get; set; }
        public virtual DbSet<Reports> Reports { get; set; }
        public virtual DbSet<ReturnDetail> ReturnDetail { get; set; }
        public virtual DbSet<ReturnOrder> ReturnOrder { get; set; }
        public virtual DbSet<Sequence> Sequence { get; set; }
        public virtual DbSet<Storage> Storage { get; set; }
        public virtual DbSet<Supplier> Supplier { get; set; }
        public virtual DbSet<SysDepart> SysDepart { get; set; }
        public virtual DbSet<SysRelation> SysRelation { get; set; }
        public virtual DbSet<SysResource> SysResource { get; set; }
        public virtual DbSet<SysRole> SysRole { get; set; }
        public virtual DbSet<TNum> TNum { get; set; }
        public virtual DbSet<InOrderView> InOrderView { get; set; }
        public virtual DbSet<LocalProductView> LocalProductView { get; set; }
        public virtual DbSet<OutStorageView> OutStorageView { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<Admin>()
                .Property(e => e.PassWord)
                .IsUnicode(false);

            modelBuilder.Entity<Admin>()
                .Property(e => e.UserCode)
                .IsUnicode(false);

            modelBuilder.Entity<Admin>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Admin>()
                .Property(e => e.Mobile)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Admin>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Admin>()
                .Property(e => e.CreateIp)
                .IsUnicode(false);

            modelBuilder.Entity<Admin>()
                .Property(e => e.DepartNum)
                .IsUnicode(false);

            modelBuilder.Entity<Admin>()
                .Property(e => e.ParentCode)
                .IsUnicode(false);

            modelBuilder.Entity<Admin>()
                .Property(e => e.RoleNum)
                .IsUnicode(false);

            modelBuilder.Entity<BadReport>()
                .Property(e => e.OrderNum)
                .IsUnicode(false);

            modelBuilder.Entity<BadReport>()
                .Property(e => e.StorageNum)
                .IsUnicode(false);

            modelBuilder.Entity<BadReport>()
                .Property(e => e.ContractOrder)
                .IsUnicode(false);

            modelBuilder.Entity<BadReport>()
                .Property(e => e.EquipmentNum)
                .IsUnicode(false);

            modelBuilder.Entity<BadReport>()
                .Property(e => e.EquipmentCode)
                .IsUnicode(false);

            modelBuilder.Entity<BadReportDetail>()
                .Property(e => e.SnNum)
                .IsUnicode(false);

            modelBuilder.Entity<BadReportDetail>()
                .Property(e => e.OrderNum)
                .IsUnicode(false);

            modelBuilder.Entity<BadReportDetail>()
                .Property(e => e.BarCode)
                .IsUnicode(false);

            modelBuilder.Entity<BadReportDetail>()
                .Property(e => e.ProductNum)
                .IsUnicode(false);

            modelBuilder.Entity<BadReportDetail>()
                .Property(e => e.StorageNum)
                .IsUnicode(false);

            modelBuilder.Entity<BadReportDetail>()
                .Property(e => e.FromLocalNum)
                .IsUnicode(false);

            modelBuilder.Entity<BadReportDetail>()
                .Property(e => e.ToLocalNum)
                .IsUnicode(false);

            modelBuilder.Entity<CheckData>()
                .Property(e => e.OrderNum)
                .IsUnicode(false);

            modelBuilder.Entity<CheckData>()
                .Property(e => e.LocalNum)
                .IsUnicode(false);

            modelBuilder.Entity<CheckData>()
                .Property(e => e.StorageNum)
                .IsUnicode(false);

            modelBuilder.Entity<CheckData>()
                .Property(e => e.ProductNum)
                .IsUnicode(false);

            modelBuilder.Entity<CheckData>()
                .Property(e => e.BarCode)
                .IsUnicode(false);

            modelBuilder.Entity<CheckData>()
                .Property(e => e.FirstUser)
                .IsUnicode(false);

            modelBuilder.Entity<CheckData>()
                .Property(e => e.SecondUser)
                .IsUnicode(false);

            modelBuilder.Entity<CheckStock>()
                .Property(e => e.OrderNum)
                .IsUnicode(false);

            modelBuilder.Entity<CheckStock>()
                .Property(e => e.StorageNum)
                .IsUnicode(false);

            modelBuilder.Entity<CheckStock>()
                .Property(e => e.ContractOrder)
                .IsUnicode(false);

            modelBuilder.Entity<CheckStock>()
                .Property(e => e.EquipmentNum)
                .IsUnicode(false);

            modelBuilder.Entity<CheckStock>()
                .Property(e => e.EquipmentCode)
                .IsUnicode(false);

            modelBuilder.Entity<CheckStockInfo>()
                .Property(e => e.OrderNum)
                .IsUnicode(false);

            modelBuilder.Entity<CheckStockInfo>()
                .Property(e => e.StorageNum)
                .IsUnicode(false);

            modelBuilder.Entity<CheckStockInfo>()
                .Property(e => e.TargetNum)
                .IsUnicode(false);

            modelBuilder.Entity<CloneHistory>()
                .Property(e => e.OrderNum)
                .IsUnicode(false);

            modelBuilder.Entity<CloneHistory>()
                .Property(e => e.Sn)
                .IsUnicode(false);

            modelBuilder.Entity<CloneHistory>()
                .Property(e => e.StorageNum)
                .IsUnicode(false);

            modelBuilder.Entity<CloneHistory>()
                .Property(e => e.LocalNum)
                .IsUnicode(false);

            modelBuilder.Entity<CloneHistory>()
                .Property(e => e.ProductNum)
                .IsUnicode(false);

            modelBuilder.Entity<CloneHistory>()
                .Property(e => e.BarCode)
                .IsUnicode(false);

            modelBuilder.Entity<CloneHistory>()
                .Property(e => e.CreateUser)
                .IsUnicode(false);

            modelBuilder.Entity<CloneTemp>()
                .Property(e => e.OrderNum)
                .IsUnicode(false);

            modelBuilder.Entity<CloneTemp>()
                .Property(e => e.Sn)
                .IsUnicode(false);

            modelBuilder.Entity<CloneTemp>()
                .Property(e => e.StorageNum)
                .IsUnicode(false);

            modelBuilder.Entity<CloneTemp>()
                .Property(e => e.LocalNum)
                .IsUnicode(false);

            modelBuilder.Entity<CloneTemp>()
                .Property(e => e.ProductNum)
                .IsUnicode(false);

            modelBuilder.Entity<CloneTemp>()
                .Property(e => e.BarCode)
                .IsUnicode(false);

            modelBuilder.Entity<CloneTemp>()
                .Property(e => e.CreateUser)
                .IsUnicode(false);

            modelBuilder.Entity<CusAddress>()
                .Property(e => e.SnNum)
                .IsUnicode(false);

            modelBuilder.Entity<CusAddress>()
                .Property(e => e.CusNum)
                .IsUnicode(false);

            modelBuilder.Entity<CusAddress>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<CusAddress>()
                .Property(e => e.CreateUser)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.CusNum)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Fax)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.CreateUser)
                .IsUnicode(false);

            modelBuilder.Entity<Equipment>()
                .Property(e => e.SnNum)
                .IsUnicode(false);

            modelBuilder.Entity<Equipment>()
                .Property(e => e.EquipmentNum)
                .IsUnicode(false);

            modelBuilder.Entity<Equipment>()
                .Property(e => e.CreateUser)
                .IsUnicode(false);

            modelBuilder.Entity<InStorage>()
                .Property(e => e.OrderNum)
                .IsUnicode(false);

            modelBuilder.Entity<InStorage>()
                .Property(e => e.StorageNum)
                .IsUnicode(false);

            modelBuilder.Entity<InStorage>()
                .Property(e => e.SupNum)
                .IsUnicode(false);

            modelBuilder.Entity<InStorage>()
                .Property(e => e.SupName)
                .IsUnicode(false);

            modelBuilder.Entity<InStorage>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<InStorage>()
                .Property(e => e.ContractOrder)
                .IsUnicode(false);

            modelBuilder.Entity<InStorage>()
                .Property(e => e.EquipmentNum)
                .IsUnicode(false);

            modelBuilder.Entity<InStorage>()
                .Property(e => e.EquipmentCode)
                .IsUnicode(false);

            modelBuilder.Entity<InStorDetail>()
                .Property(e => e.SnNum)
                .IsUnicode(false);

            modelBuilder.Entity<InStorDetail>()
                .Property(e => e.OrderNum)
                .IsUnicode(false);

            modelBuilder.Entity<InStorDetail>()
                .Property(e => e.BarCode)
                .IsUnicode(false);

            modelBuilder.Entity<InStorDetail>()
                .Property(e => e.ProductNum)
                .IsUnicode(false);

            modelBuilder.Entity<InStorDetail>()
                .Property(e => e.ContractOrder)
                .IsUnicode(false);

            modelBuilder.Entity<InStorDetail>()
                .Property(e => e.LocalNum)
                .IsUnicode(false);

            modelBuilder.Entity<InStorDetail>()
                .Property(e => e.StorageNum)
                .IsUnicode(false);

            modelBuilder.Entity<InventoryBook>()
                .Property(e => e.ProductNum)
                .IsUnicode(false);

            modelBuilder.Entity<InventoryBook>()
                .Property(e => e.BarCode)
                .IsUnicode(false);

            modelBuilder.Entity<InventoryBook>()
                .Property(e => e.ContactOrder)
                .IsUnicode(false);

            modelBuilder.Entity<InventoryBook>()
                .Property(e => e.FromLocalNum)
                .IsUnicode(false);

            modelBuilder.Entity<InventoryBook>()
                .Property(e => e.ToLocalNum)
                .IsUnicode(false);

            modelBuilder.Entity<InventoryBook>()
                .Property(e => e.StoreNum)
                .IsUnicode(false);

            modelBuilder.Entity<InventoryBook>()
                .Property(e => e.CreateUser)
                .IsUnicode(false);

            modelBuilder.Entity<LocalProduct>()
                .Property(e => e.Sn)
                .IsUnicode(false);

            modelBuilder.Entity<LocalProduct>()
                .Property(e => e.StorageNum)
                .IsUnicode(false);

            modelBuilder.Entity<LocalProduct>()
                .Property(e => e.LocalNum)
                .IsUnicode(false);

            modelBuilder.Entity<LocalProduct>()
                .Property(e => e.ProductNum)
                .IsUnicode(false);

            modelBuilder.Entity<LocalProduct>()
                .Property(e => e.BarCode)
                .IsUnicode(false);

            modelBuilder.Entity<LocalProduct>()
                .Property(e => e.CreateUser)
                .IsUnicode(false);

            modelBuilder.Entity<Location>()
                .Property(e => e.LocalNum)
                .IsUnicode(false);

            modelBuilder.Entity<Location>()
                .Property(e => e.LocalBarCode)
                .IsUnicode(false);

            modelBuilder.Entity<Location>()
                .Property(e => e.StorageNum)
                .IsUnicode(false);

            modelBuilder.Entity<Location>()
                .Property(e => e.UnitNum)
                .IsUnicode(false);

            modelBuilder.Entity<Location>()
                .Property(e => e.UnitName)
                .IsUnicode(false);

            modelBuilder.Entity<Measure>()
                .Property(e => e.SN)
                .IsUnicode(false);

            modelBuilder.Entity<MeasureRel>()
                .Property(e => e.SN)
                .IsUnicode(false);

            modelBuilder.Entity<MoveOrder>()
                .Property(e => e.OrderNum)
                .IsUnicode(false);

            modelBuilder.Entity<MoveOrder>()
                .Property(e => e.StorageNum)
                .IsUnicode(false);

            modelBuilder.Entity<MoveOrder>()
                .Property(e => e.ContractOrder)
                .IsUnicode(false);

            modelBuilder.Entity<MoveOrder>()
                .Property(e => e.EquipmentNum)
                .IsUnicode(false);

            modelBuilder.Entity<MoveOrder>()
                .Property(e => e.EquipmentCode)
                .IsUnicode(false);

            modelBuilder.Entity<MoveOrderDetail>()
                .Property(e => e.SnNum)
                .IsUnicode(false);

            modelBuilder.Entity<MoveOrderDetail>()
                .Property(e => e.OrderNum)
                .IsUnicode(false);

            modelBuilder.Entity<MoveOrderDetail>()
                .Property(e => e.BarCode)
                .IsUnicode(false);

            modelBuilder.Entity<MoveOrderDetail>()
                .Property(e => e.ProductNum)
                .IsUnicode(false);

            modelBuilder.Entity<MoveOrderDetail>()
                .Property(e => e.StorageNum)
                .IsUnicode(false);

            modelBuilder.Entity<MoveOrderDetail>()
                .Property(e => e.FromLocalNum)
                .IsUnicode(false);

            modelBuilder.Entity<MoveOrderDetail>()
                .Property(e => e.ToLocalNum)
                .IsUnicode(false);

            modelBuilder.Entity<OutStoDetail>()
                .Property(e => e.SnNum)
                .IsUnicode(false);

            modelBuilder.Entity<OutStoDetail>()
                .Property(e => e.OrderNum)
                .IsUnicode(false);

            modelBuilder.Entity<OutStoDetail>()
                .Property(e => e.BarCode)
                .IsUnicode(false);

            modelBuilder.Entity<OutStoDetail>()
                .Property(e => e.ProductNum)
                .IsUnicode(false);

            modelBuilder.Entity<OutStoDetail>()
                .Property(e => e.LocalNum)
                .IsUnicode(false);

            modelBuilder.Entity<OutStoDetail>()
                .Property(e => e.StorageNum)
                .IsUnicode(false);

            modelBuilder.Entity<OutStoDetail>()
                .Property(e => e.ContractOrder)
                .IsUnicode(false);

            modelBuilder.Entity<OutStoDetail>()
                .Property(e => e.ContractSn)
                .IsUnicode(false);

            modelBuilder.Entity<OutStoDetail>()
                .Property(e => e.Count)
                .IsUnicode(false);

            modelBuilder.Entity<OutStoDetail>()
                .Property(e => e.Color)
                .IsUnicode(false);

            modelBuilder.Entity<OutStoDetail>()
                .Property(e => e.Size)
                .IsUnicode(false);

            modelBuilder.Entity<OutStorage>()
                .Property(e => e.OrderNum)
                .IsUnicode(false);

            modelBuilder.Entity<OutStorage>()
                .Property(e => e.StorageNum)
                .IsUnicode(false);

            modelBuilder.Entity<OutStorage>()
                .Property(e => e.CusNum)
                .IsUnicode(false);

            modelBuilder.Entity<OutStorage>()
                .Property(e => e.CusName)
                .IsUnicode(false);

            modelBuilder.Entity<OutStorage>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<OutStorage>()
                .Property(e => e.ContractOrder)
                .IsUnicode(false);

            modelBuilder.Entity<OutStorage>()
                .Property(e => e.EquipmentNum)
                .IsUnicode(false);

            modelBuilder.Entity<OutStorage>()
                .Property(e => e.EquipmentCode)
                .IsUnicode(false);

            modelBuilder.Entity<OutStorage>()
                .Property(e => e.UserID)
                .IsUnicode(false);

            modelBuilder.Entity<OutStorage>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<OutStorage>()
                .Property(e => e.DeptName)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.SnNum)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.BarCode)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.UnitNum)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.UnitName)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.CateNum)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.PicUrl)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.StorageNum)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.CusNum)
                .IsUnicode(false);

            modelBuilder.Entity<ProductCategory>()
                .Property(e => e.CateNum)
                .IsUnicode(false);

            modelBuilder.Entity<ReportParams>()
                .Property(e => e.ParamNum)
                .IsUnicode(false);

            modelBuilder.Entity<ReportParams>()
                .Property(e => e.ReportNum)
                .IsUnicode(false);

            modelBuilder.Entity<ReportParams>()
                .Property(e => e.InputNo)
                .IsUnicode(false);

            modelBuilder.Entity<ReportParams>()
                .Property(e => e.ParamName)
                .IsUnicode(false);

            modelBuilder.Entity<ReportParams>()
                .Property(e => e.ParamType)
                .IsUnicode(false);

            modelBuilder.Entity<ReportParams>()
                .Property(e => e.ParamData)
                .IsUnicode(false);

            modelBuilder.Entity<ReportParams>()
                .Property(e => e.DefaultValue)
                .IsUnicode(false);

            modelBuilder.Entity<ReportParams>()
                .Property(e => e.ParamElement)
                .IsUnicode(false);

            modelBuilder.Entity<Reports>()
                .Property(e => e.ReportNum)
                .IsUnicode(false);

            modelBuilder.Entity<ReturnDetail>()
                .Property(e => e.SnNum)
                .IsUnicode(false);

            modelBuilder.Entity<ReturnDetail>()
                .Property(e => e.OrderNum)
                .IsUnicode(false);

            modelBuilder.Entity<ReturnDetail>()
                .Property(e => e.ContractOrder)
                .IsUnicode(false);

            modelBuilder.Entity<ReturnDetail>()
                .Property(e => e.BarCode)
                .IsUnicode(false);

            modelBuilder.Entity<ReturnDetail>()
                .Property(e => e.ProductNum)
                .IsUnicode(false);

            modelBuilder.Entity<ReturnDetail>()
                .Property(e => e.LocalNum)
                .IsUnicode(false);

            modelBuilder.Entity<ReturnDetail>()
                .Property(e => e.StorageNum)
                .IsUnicode(false);

            modelBuilder.Entity<ReturnOrder>()
                .Property(e => e.OrderNum)
                .IsUnicode(false);

            modelBuilder.Entity<ReturnOrder>()
                .Property(e => e.StorageNum)
                .IsUnicode(false);

            modelBuilder.Entity<ReturnOrder>()
                .Property(e => e.CusNum)
                .IsUnicode(false);

            modelBuilder.Entity<ReturnOrder>()
                .Property(e => e.CusName)
                .IsUnicode(false);

            modelBuilder.Entity<ReturnOrder>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<ReturnOrder>()
                .Property(e => e.ContractOrder)
                .IsUnicode(false);

            modelBuilder.Entity<ReturnOrder>()
                .Property(e => e.EquipmentNum)
                .IsUnicode(false);

            modelBuilder.Entity<ReturnOrder>()
                .Property(e => e.EquipmentCode)
                .IsUnicode(false);

            modelBuilder.Entity<Sequence>()
                .Property(e => e.SN)
                .IsUnicode(false);

            modelBuilder.Entity<Sequence>()
                .Property(e => e.TabName)
                .IsUnicode(false);

            modelBuilder.Entity<Sequence>()
                .Property(e => e.JoinChar)
                .IsUnicode(false);

            modelBuilder.Entity<Storage>()
                .Property(e => e.StorageNum)
                .IsUnicode(false);

            modelBuilder.Entity<Supplier>()
                .Property(e => e.SupNum)
                .IsUnicode(false);

            modelBuilder.Entity<Supplier>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Supplier>()
                .Property(e => e.Fax)
                .IsUnicode(false);

            modelBuilder.Entity<Supplier>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Supplier>()
                .Property(e => e.CreateUser)
                .IsUnicode(false);

            modelBuilder.Entity<Supplier>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Supplier>()
                .Property(e => e.ContractNum)
                .IsUnicode(false);

            modelBuilder.Entity<SysDepart>()
                .Property(e => e.DepartNum)
                .IsUnicode(false);

            modelBuilder.Entity<SysDepart>()
                .Property(e => e.ParentNum)
                .IsUnicode(false);

            modelBuilder.Entity<SysRelation>()
                .Property(e => e.RoleNum)
                .IsUnicode(false);

            modelBuilder.Entity<SysRelation>()
                .Property(e => e.ResNum)
                .IsUnicode(false);

            modelBuilder.Entity<SysResource>()
                .Property(e => e.ResNum)
                .IsUnicode(false);

            modelBuilder.Entity<SysResource>()
                .Property(e => e.ParentNum)
                .IsUnicode(false);

            modelBuilder.Entity<SysResource>()
                .Property(e => e.ParentPath)
                .IsUnicode(false);

            modelBuilder.Entity<SysResource>()
                .Property(e => e.Url)
                .IsUnicode(false);

            modelBuilder.Entity<SysResource>()
                .Property(e => e.CssName)
                .IsUnicode(false);

            modelBuilder.Entity<SysResource>()
                .Property(e => e.CreateIp)
                .IsUnicode(false);

            modelBuilder.Entity<SysResource>()
                .Property(e => e.UpdateIp)
                .IsUnicode(false);

            modelBuilder.Entity<SysRole>()
                .Property(e => e.RoleNum)
                .IsUnicode(false);

            modelBuilder.Entity<TNum>()
                .Property(e => e.Day)
                .IsUnicode(false);

            modelBuilder.Entity<TNum>()
                .Property(e => e.TabName)
                .IsUnicode(false);

            modelBuilder.Entity<InOrderView>()
                .Property(e => e.SnNum)
                .IsUnicode(false);

            modelBuilder.Entity<InOrderView>()
                .Property(e => e.OrderNum)
                .IsUnicode(false);

            modelBuilder.Entity<InOrderView>()
                .Property(e => e.BarCode)
                .IsUnicode(false);

            modelBuilder.Entity<InOrderView>()
                .Property(e => e.ProductNum)
                .IsUnicode(false);

            modelBuilder.Entity<InOrderView>()
                .Property(e => e.LocalNum)
                .IsUnicode(false);

            modelBuilder.Entity<InOrderView>()
                .Property(e => e.StorageNum)
                .IsUnicode(false);

            modelBuilder.Entity<InOrderView>()
                .Property(e => e.SupNum)
                .IsUnicode(false);

            modelBuilder.Entity<InOrderView>()
                .Property(e => e.SupName)
                .IsUnicode(false);

            modelBuilder.Entity<LocalProductView>()
                .Property(e => e.Sn)
                .IsUnicode(false);

            modelBuilder.Entity<LocalProductView>()
                .Property(e => e.StorageNum)
                .IsUnicode(false);

            modelBuilder.Entity<LocalProductView>()
                .Property(e => e.LocalNum)
                .IsUnicode(false);

            modelBuilder.Entity<LocalProductView>()
                .Property(e => e.ProductNum)
                .IsUnicode(false);

            modelBuilder.Entity<LocalProductView>()
                .Property(e => e.BarCode)
                .IsUnicode(false);

            modelBuilder.Entity<LocalProductView>()
                .Property(e => e.CreateUser)
                .IsUnicode(false);

            modelBuilder.Entity<OutStorageView>()
                .Property(e => e.SnNum)
                .IsUnicode(false);

            modelBuilder.Entity<OutStorageView>()
                .Property(e => e.OrderNum)
                .IsUnicode(false);

            modelBuilder.Entity<OutStorageView>()
                .Property(e => e.BarCode)
                .IsUnicode(false);

            modelBuilder.Entity<OutStorageView>()
                .Property(e => e.ProductNum)
                .IsUnicode(false);

            modelBuilder.Entity<OutStorageView>()
                .Property(e => e.LocalNum)
                .IsUnicode(false);

            modelBuilder.Entity<OutStorageView>()
                .Property(e => e.StorageNum)
                .IsUnicode(false);

            modelBuilder.Entity<OutStorageView>()
                .Property(e => e.ContractOrder)
                .IsUnicode(false);

            modelBuilder.Entity<OutStorageView>()
                .Property(e => e.ContractSn)
                .IsUnicode(false);

            modelBuilder.Entity<OutStorageView>()
                .Property(e => e.Count)
                .IsUnicode(false);

            modelBuilder.Entity<OutStorageView>()
                .Property(e => e.Color)
                .IsUnicode(false);

            modelBuilder.Entity<OutStorageView>()
                .Property(e => e.Size)
                .IsUnicode(false);

            modelBuilder.Entity<OutStorageView>()
                .Property(e => e.OutUName)
                .IsUnicode(false);

            modelBuilder.Entity<OutStorageView>()
                .Property(e => e.OutDName)
                .IsUnicode(false);

            modelBuilder.Entity<OutStorageView>()
                .Property(e => e.OutUid)
                .IsUnicode(false);

            modelBuilder.Entity<OutStorageView>()
                .Property(e => e.CusName)
                .IsUnicode(false);
        }
    }
}
