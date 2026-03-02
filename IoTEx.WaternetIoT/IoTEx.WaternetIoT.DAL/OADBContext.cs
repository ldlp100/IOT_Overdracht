using IoTEx.WaternetIoT.Model.DTOs;
using IoTEx.WaternetIoT.Model.PortalModels;
using Microsoft.EntityFrameworkCore;


namespace IoTEx.WaternetIoT.DAL
{
    public class OADBContext : DbContext
    {

        public OADBContext(DbContextOptions<OADBContext> options) : base(options)
        {

        }


        public DbSet<DeviceTelemetryDTO> OAMessages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<DeviceTelemetryDTO>();

        }

    }
}