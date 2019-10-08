namespace Policy.Framework.Data.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Threading.Tasks;
    using Policy.Framework.Data.Entities;
    using Policy.Framework.Data.Interface;

    public class PolicyRepository : IPolicyRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly DbSet<VehicleEntity> _vehicleEntity;
        private readonly DbSet<ServiceEntity> _serviceEntity;   

        private readonly DbSet<PolicyEntity> _policyEntity;   

        public PolicyRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _vehicleEntity = _dbContext.Set<VehicleEntity>();
            _serviceEntity = _dbContext.Set<ServiceEntity>();
            _policyEntity = _dbContext.Set<PolicyEntity>();
        }

        public async Task Create(PolicyEntity policyEntity, VehicleEntity vehicleEntity, ServiceEntity serviceEntity)
        {
            _serviceEntity.Add(serviceEntity);
            _vehicleEntity.Update(vehicleEntity);


                    
        }
        public async Task<PolicyEntity> Create(PolicyEntity policyEntity) 
        {
            _policyEntity.Add(policyEntity);
            _dbContext.SaveChanges();
            return policyEntity;
        }
    }
}
