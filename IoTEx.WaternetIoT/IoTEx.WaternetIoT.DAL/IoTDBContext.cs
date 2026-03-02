using IoTEx.WaternetIoT.Model.PortalModels;
using Microsoft.EntityFrameworkCore;

namespace IoTEx.WaternetIoT.DAL
{
    public class IoTDBContext : DbContext
    {
        
        public IoTDBContext(DbContextOptions<IoTDBContext> options) : base(options)
        {
            //LL
            //this.Database.connec.conn.Connection.ConnectionString = connectionstring;
            //this.ChangeTracker.LazyLoadingEnabled = true;
        }
        public IoTDBContext() 
        {  

        }
        
        public static IoTDBContext Create()
        {
            return new IoTDBContext();
        }

        public DbSet<ServiceModel> Services { get; set; }
        public DbSet<User2ServiceModel> User2Services { get; set; }
        public DbSet<User2ProjectModel> User2Projects { get; set; }
        public DbSet<AppUserModel> AppUsers { get; set; }
        public DbSet<DeviceModel> Devices { get; set; }
        public DbSet<ProjectModel> Projects { get; set; }
        public DbSet<DeviceTypeModel> DeviceTypes { get; set; }
        public DbSet<EventStateTypeModel> EventStateTypes { get; set; }
        public DbSet<SubEventStateTypeModel> SubEventStateTypes { get; set; }
        public DbSet<UnitTypeModel> UnitTypes { get; set; }
        public DbSet<MeasurementTypeModel> MeasurementTypes { get; set; }
        public DbSet<SupplierModel> Suppliers { get; set; }
        public DbSet<DeviceTypeFirmwareMeasurementTypeModel> DeviceTypeFirmware2MeasurementTypes { get; set; }
        public DbSet<DeviceTypeFirmwareEventStateTypeModel> DeviceTypeFirmware2EventStateTypes { get; set; }
        public DbSet<AppConfigurationModel> AppConfigurations { get; set; }
        public DbSet<DeviceBatchModel> DeviceBatchs { get; set; }
        public DbSet<DeviceTypeEventState2SubStateTypeModel> DeviceTypeEventState2SubStateTypes { get; set; }
        public DbSet<DeviceOutputModel> Device2Outputs { get; set; }
        public DbSet<ParserModel> Parsers { get; set; }
        public DbSet<DeviceCalibrationModel> Device2Calibrations { get; set; }
        public DbSet<Device2ProjectModel> Device2Projects { get; set; }
        public DbSet<DeviceConfigurationModel> Device2Configurations { get; set; }
        public DbSet<DeviceTypeFirmwareConfigurationModel> DeviceTypeFirmware2Configurations { get; set; }
        public DbSet<DeviceType2NetworkAPIModel> DeviceType2NetworkAPIs { get; set; }
        public DbSet<NetworkAPIModel> NetworkAPIs { get; set; }
        public DbSet<NetworkAPISettingModel> NetworkAPISettings { get; set; }
        public DbSet<DeviceTypeFirmwareModel> DeviceTypeFirmwares { get; set; }
        public DbSet<Device2SNetworkAPISettingModel> Device2SNetworkAPISettings { get; set; }
        public DbSet<AttachmentModel> Attachments { get; set; }
        public DbSet<UserTaskModel> UserTasks { get; set; }
        public DbSet<TargetDBModel> TargetDBs { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.con.Conventions.Remove<PluralizingTableNameConvention>();
            //modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Entity<ServiceModel>();
            modelBuilder.Entity<User2ServiceModel>();
            modelBuilder.Entity<AppUserModel>();
            modelBuilder.Entity<ProjectModel>();
            modelBuilder.Entity<DeviceModel>();
            modelBuilder.Entity<User2ProjectModel>();
            modelBuilder.Entity<DeviceTypeModel>();
            modelBuilder.Entity<EventStateTypeModel>();
            modelBuilder.Entity<SubEventStateTypeModel>();
            modelBuilder.Entity<UnitTypeModel>();
            modelBuilder.Entity<MeasurementTypeModel>();
            modelBuilder.Entity<SupplierModel>();
            modelBuilder.Entity<DeviceTypeFirmwareMeasurementTypeModel>();
            modelBuilder.Entity<DeviceTypeFirmwareEventStateTypeModel>();
            modelBuilder.Entity<AppConfigurationModel>();
            modelBuilder.Entity<DeviceBatchModel>();
            modelBuilder.Entity<DeviceTypeEventState2SubStateTypeModel>();
            modelBuilder.Entity<DeviceOutputModel>();
            modelBuilder.Entity<ParserModel>();
            modelBuilder.Entity<Device2ProjectModel>();
            modelBuilder.Entity<DeviceConfigurationModel>();
            modelBuilder.Entity<DeviceTypeFirmwareConfigurationModel>();
            modelBuilder.Entity<DeviceType2NetworkAPIModel>();
            modelBuilder.Entity<NetworkAPIModel>();
            modelBuilder.Entity<NetworkAPISettingModel>();
            modelBuilder.Entity<DeviceTypeFirmwareModel>();
            modelBuilder.Entity<Device2SNetworkAPISettingModel>();
            modelBuilder.Entity<AttachmentModel>();
            modelBuilder.Entity<TargetDBModel>();
            //modelBuilder.Entity<AppUserModel>().HasMany(c => c.User2Services).WithRequired().HasForeignKey(c => c.UserId).WillCascadeOnDelete();
            //modelBuilder.Entity<AppUserModel>().HasRequired(c => c.Created).WithMany().HasForeignKey(c => c.Id).WillCascadeOnDelete();
            //modelBuilder.Entity<AppUserModel>().HasRequired(c => c.Updated)..WithRequired().HasForeignKey(c => c.UserId).WillCascadeOnDelete();

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }
    }
}