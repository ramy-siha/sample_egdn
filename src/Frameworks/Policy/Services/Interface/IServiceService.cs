namespace Policy.Framework.Services.Interface
{
    using System.Threading.Tasks;
    using Policy.Framework.Domain;
    using System.Collections.Generic;

    public interface IServiceService
    {
        Task<ICollection<Service>> List();
       
    }
}

