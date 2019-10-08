using AutoMapper;
using Policy.Framework.Domain;
using Policy.WebApi.Models;

namespace Policy.WebApi.Mappers
{
    public class ModelMappingProfile : Profile
    {
        public ModelMappingProfile()
        {
            CreateMap<VehicleModel, Vehicle>().ForAllMembers(opt => opt.Ignore());

            CreateMap<PolicyModel, Policy.Framework.Domain.Policy>().ForMember( dest => dest.VehicleId, opt => opt.MapFrom(o => o.VehicleId) )
            .ForMember( dest => dest.StartDate, opt => opt.MapFrom(o => o.StartDate) )
            .ForMember( dest => dest.EndtDate, opt => opt.MapFrom(o => o.EndtDate) )
            .ForMember( dest => dest.Amount, opt => opt.MapFrom(o => o.Amount) )
            .ForAllOtherMembers(opt => opt.Ignore());

            CreateMap<Policy.Framework.Domain.Policy, PolicyModel>().ForMember( dest => dest.VehicleId, opt =>  opt.MapFrom(o => o.VehicleId) )
            .ForMember( dest => dest.StartDate, opt => opt.MapFrom(o => o.StartDate) )
            .ForMember( dest => dest.EndtDate, opt => opt.MapFrom(o => o.EndtDate) )
            .ForMember( dest => dest.Amount, opt => opt.MapFrom(o => o.Amount) )
            .ForAllOtherMembers(opt => opt.Ignore());

            CreateMap<Policy.Framework.Domain.Service, ServiceModel>().ForMember( dest => dest.ServiceId, opt =>  opt.MapFrom(o => o.ServiceId) )
            .ForMember( dest => dest.Name , opt => opt.MapFrom(o => o.Name) )
            .ForMember( dest => dest.Price, opt => opt.MapFrom(o => o.Price) )
            .ForMember( dest => dest.Period, opt => opt.MapFrom(o => o.Period) )
            .ForAllOtherMembers(opt => opt.Ignore());
        }
    }
}
