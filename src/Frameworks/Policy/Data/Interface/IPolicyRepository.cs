using Policy.Framework.Data.Entities;

namespace Policy.Framework.Data.Interface
{
    using System.Threading.Tasks;
    using Policy.Framework.Data.Entities;

    public interface IPolicyRepository
    {
        Task Create(PolicyEntity policyEntity, VehicleEntity vehicleEntity, ServiceEntity serviceEntity);

        Task<PolicyEntity> Create(PolicyEntity policyEntity);
    }
}
