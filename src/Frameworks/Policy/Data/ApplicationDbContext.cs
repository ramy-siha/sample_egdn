using System.Data;

namespace Policy.Framework.Data
{
    using Microsoft.EntityFrameworkCore;
    using Policy.Framework.Data.Entities;

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options)
        {
             this.Database.EnsureCreated();
         }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var vBuilder = modelBuilder.Entity<VehicleEntity>();
            
            vBuilder.HasKey(p => p.VehicleId);
            vBuilder.Property(p => p.EngineSize).IsRequired();
            vBuilder.ToTable("Vehicle");

            var pBuilder = modelBuilder.Entity<PolicyEntity>();
            
            pBuilder.HasKey(p => p.PolicyId);
            pBuilder.ToTable("Policy");

            var sBuilder = modelBuilder.Entity<ServiceEntity>();
            
            sBuilder.HasKey(p => p.ServiceId);
            sBuilder.ToTable("Service");
            sBuilder.HasData(new ServiceEntity() {Name = "Service1", Price = 5.0, Period = 10, ServiceId = 1}, new ServiceEntity() {Name = "Service2", Price = 6.0, Period = 20, ServiceId = 2}, new ServiceEntity() {Name = "Service3", Price = 4.0, Period = 25, ServiceId = 3});
            

           
        }
    }
}
