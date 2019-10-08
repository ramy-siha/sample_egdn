namespace Policy.Framework.Services.Interface
{
    using System.Threading.Tasks;
    using Policy.Framework.Domain;

    public interface IPolicyService
    {
        Task<Policy> Create(Policy policy);
       
    }
}

