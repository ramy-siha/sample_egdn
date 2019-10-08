namespace Policy.Framework.Services.Interface
{
    using System.Threading.Tasks;
    using Policy.Framework.Domain;

    public interface IVehicleService
    {
        Vehicle Create(Vehicle vehicle);
       
    }
}

