namespace Policy.Framework.Data.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using System.Linq;
    using System.Threading.Tasks;
    using Policy.Framework.Data.Entities;
    using Policy.Framework.Data.Interface;

    public class VehicleRepository : IVehicleRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly DbSet<VehicleEntity> _vehicleEntity;

        public VehicleRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _vehicleEntity = _dbContext.Set<VehicleEntity>();
        }

        public async Task<VehicleEntity> Read(int vehicleId)
        {
            return await _vehicleEntity.AsNoTracking()
                .FirstOrDefaultAsync(e => e.VehicleId == vehicleId);
        }

        public VehicleEntity Create(VehicleEntity vehicle)
        {
            _vehicleEntity.Add(vehicle);
            _dbContext.SaveChanges();
            return vehicle;
        }
    }
}
