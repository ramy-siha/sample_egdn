namespace Policy.Framework.Data.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using System.Linq;
    using System.Threading.Tasks;
    using Policy.Framework.Data.Entities;
    using Policy.Framework.Data.Interface;
    using System.Collections.Generic;

    public class ServiceRepository : IServiceRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly DbSet<ServiceEntity> _serviceEntity;

        public ServiceRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _serviceEntity = _dbContext.Set<ServiceEntity>();
        }

        public async Task<ServiceEntity> Read(int serviceId)
        {
            return await _serviceEntity.AsNoTracking()
                .FirstOrDefaultAsync(e => e.ServiceId == serviceId);
        }

        public async Task<ICollection<ServiceEntity>> List() 
        {
            return await _serviceEntity.AsNoTracking().ToListAsync();
        }
    }
}
