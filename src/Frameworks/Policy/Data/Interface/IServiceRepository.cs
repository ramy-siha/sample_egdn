namespace Policy.Framework.Data.Interface
{
    using System.Threading.Tasks;
    using Policy.Framework.Data.Entities;
    using System.Collections.Generic;

    public interface IServiceRepository
    {
        Task<ServiceEntity> Read(int serviceId);

        Task<ICollection<ServiceEntity>> List();
    }
}
