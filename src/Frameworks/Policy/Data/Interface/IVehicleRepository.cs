namespace Policy.Framework.Data.Interface
{
    using System.Threading.Tasks;
    using Policy.Framework.Data.Entities;

    public interface IVehicleRepository
    {
        Task<VehicleEntity> Read(int vehicleId);

        VehicleEntity Create(VehicleEntity vehicle);
    }
}
