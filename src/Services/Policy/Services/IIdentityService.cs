namespace Policy.WebApi.Services
{
    using Policy.WebApi.Models;

    public interface IIdentityService
    {
        IdentityModel GetIdentity();
    }
}
